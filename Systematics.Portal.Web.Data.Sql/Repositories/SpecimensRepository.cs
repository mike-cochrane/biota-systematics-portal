using Systematics.Portal.Web.Data.Interfaces;
using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace Systematics.Portal.Web.Data.Sql.Repositories {
    public class SpecimensRepository : ISpecimensRepository {
        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public DisplaySpecimen Get(string accessionNumber, int securityLevel) {
            try {
                DisplaySpecimen specimen = null;

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprSSpecimen";
                        cmd.Parameters.Add("@AccessionNumber", SqlDbType.NVarChar).Value = accessionNumber;
                        cmd.Parameters.Add("@SecurityLevel", SqlDbType.Int).Value = securityLevel;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        DataRow row = ds.Tables[0].Rows[0];
                        specimen = new DisplaySpecimen();
                        specimen.SpecimenWebId = (int)row["SpecimenWebId"];
                        if (!row["SpecimenGuid"].Equals(DBNull.Value)) {
                            specimen.SpecimenGuid = (Guid)row["SpecimenGuid"];
                        }
                        specimen.SecurityLevel = (int)row["SecurityLevel"];
                        specimen.AccessionNumber = (string)row["AccessionNumber"];
                        specimen.Display = XElement.Parse((string)row["DisplayData"]);
                        if (!row["CollectionId"].Equals(DBNull.Value)) {
                            specimen.CollectionId = (Guid)row["CollectionId"];
                        }
                        if (!row["CollectionName"].Equals(DBNull.Value)) {
                            specimen.CollectionName = (string)row["CollectionName"];
                        }
                        if (!row["CollectionAcronym"].Equals(DBNull.Value))
                        {
                            specimen.CollectionAcronym = (string)row["CollectionAcronym"];
                        }
                    }

                    if (cnn.State != System.Data.ConnectionState.Closed) {
                        cnn.Close();
                    }
                }

                return specimen;
            }
            catch (Exception e) {
                throw e;
            }
            finally {
            }
        }

        public string GetSpecimenCollection(string accessionNumber) {
            try {
                string collection = string.Empty;

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprSSpecimenCollection";
                        cmd.Parameters.Add("@AccessionNumber", SqlDbType.NVarChar).Value = accessionNumber;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow row = ds.Tables[0].Rows[0];
                            collection = (string)row["Collection"];
                        }
                        else
                        {
                            collection = null;
                        }
                    }

                    if (cnn.State != System.Data.ConnectionState.Closed) {
                        cnn.Close();
                    }
                }

                return collection;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public string GetAccessionNumber(Guid specimenId) {
            try {
                string accessionNumber = string.Empty;

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprSSpecimenAccessionNumber";
                        cmd.Parameters.Add("@SpecimenId", SqlDbType.UniqueIdentifier).Value = specimenId;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        DataRow row = ds.Tables[0].Rows[0];
                        accessionNumber = (string)row["AccessionNumber"];
                    }

                    if (cnn.State != System.Data.ConnectionState.Closed) {
                        cnn.Close();
                    }
                }

                return accessionNumber;
            }
            catch (Exception e) {
                throw e;
            }
        }
    }
}
