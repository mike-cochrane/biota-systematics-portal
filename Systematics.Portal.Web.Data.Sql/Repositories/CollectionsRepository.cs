using Systematics.Portal.Web.Data.Interfaces;
using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;

namespace Systematics.Portal.Web.Data.Sql.Repositories {
    public class CollectionsRepository : ICollectionsRepository {
        
        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public List<Collection> GetAll() {
            try {
                List<Collection> lst = new List<Collection>();

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprLCollection";

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows) {
                            Collection col = new Collection() {
                                CollectionId = (Guid)row["CollectionId"],
                                DisplayText = (string)row["DisplayText"]
                            };
                            if (!row["Acronym"].Equals(DBNull.Value)){
                                col.Acronym = (string)row["Acronym"];
                            }
                            if (!row["Deck"].Equals(DBNull.Value)){
                                col.Deck = (string)row["Deck"];
                            }
                            if (!row["ImageFileName"].Equals(DBNull.Value)) {
                                col.ImageFileName = (string)row["ImageFileName"];
                            }
                            if (!row["ReadMoreURl"].Equals(DBNull.Value)) {
                                col.ReadMoreURL = (string)row["ReadMoreURl"];
                            }
                            if (!row["ResearchURL"].Equals(DBNull.Value)) {
                                col.ResearchURL = (string)row["ResearchURL"];
                            }
                            if (!row["RecordCount"].Equals(DBNull.Value)) {
                                col.RecordCount = (int)row["RecordCount"];
                            }
                            if (!row["SpecimenCount"].Equals(DBNull.Value))
                            {
                                col.SpecimenCount = (int)row["SpecimenCount"];
                            }
                            lst.Add(col);
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
