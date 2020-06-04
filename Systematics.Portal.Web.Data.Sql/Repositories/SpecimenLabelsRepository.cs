using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Systematics.Portal.Web.Data.Interfaces;

namespace Systematics.Portal.Web.Data.Sql.Repositories {
    public class SpecimenLabelsRepository : ISpecimenLabelsRepository {
        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public Dictionary<string, string> Get(string collection) {
            try {
                Dictionary<string, string> labels = new Dictionary<string,string>();

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprLSpecimenLabels";
                        cmd.Parameters.Add("@Collection", SqlDbType.NVarChar).Value = collection;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows) {
                            string tag = (string)row["labelTag"];
                            string label = (string)row["label"];

                            labels.Add(tag, label);
                        }
                    }

                    if (cnn.State != System.Data.ConnectionState.Closed) {
                        cnn.Close();
                    }
                }

                return labels;
            }
            catch (Exception e) {
                throw e;
            }
        }
    }
}
