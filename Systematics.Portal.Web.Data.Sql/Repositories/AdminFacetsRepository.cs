using Systematics.Portal.Web.Data;
using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using Systematics.Portal.Web.Data.Interfaces;

namespace Systematics.Portal.Web.Data.Sql.Repositories {
    public class AdminFacetsRepository : IAdminFacetsRepository {

        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public List<AdminFacet> GetAll() {
            try {
                List<AdminFacet> lst = new List<AdminFacet>();

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprLAdminFacet";

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows) {
                            AdminFacet config = new AdminFacet() {
                                AdminFacetId = (int)row["FacetId"],
                                FacetGroup = (string)row["FacetGroup"],
                                Facet = (string)row["Facet"],
                                Type = (string)row["FacetType"],
                                SolrFieldName = (string)row["SolrFieldName"],
                                DisplayOrder = (int)row["DisplayOrder"]
                            };
                            lst.Add(config);
                        }
                    }

                    if (cnn.State != System.Data.ConnectionState.Closed) {
                        cnn.Close();
                    }
                }

                return lst;
            }
            catch (Exception e) {
                throw e;
            }
        }
    }
}
