using Systematics.Portal.Web.Data.Interfaces;
using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Data.Sql.Repositories {
    public class DataRightsRepository : IDataRightsRepository {

        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public List<DataRight> GetAll() {
            try {
                List<DataRight> lst = new List<DataRight>();

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprLDataRight";

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows) {
                            DataRight dr = new DataRight() {
                                CollectionId = (Guid)row["CollectionId"],
                                Collection = (string)row["CollectionAcronym"],
                                Role = (string)row["RoleName"],
                                SecurityLevel = (int)row["SecurityLevel"]
                            };
                            lst.Add(dr);
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
