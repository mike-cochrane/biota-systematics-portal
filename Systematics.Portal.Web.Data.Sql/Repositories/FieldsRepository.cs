using Systematics.Portal.Web.Data.Interfaces;
using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Systematics.Portal.Web.Data.Sql.Repositories {
    public class FieldsRepository : IFieldsRepository {
        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public List<Field> GetAll() {
            try {
                List<Field> fields = new List<Field>();

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprLField";

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows) {
                            Field field = new Field();
                            field.FieldId = (int)row["FieldId"];
                            field.LoweredFieldName = (string)row["LoweredFieldName"];
                            field.SolrFieldName = (string)row["SolrFieldName"];

                            fields.Add(field);
                        }
                    }
                }
                return fields;
            }
            catch (Exception e) {
                throw e;
            }
        }
    }
}
