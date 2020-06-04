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
    public class SetsRepository : ISetsRepository {
        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public Set Get(int setId, Guid ownerId) {
            try {
                Set set = null;

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprSSet";
                        cmd.Parameters.Add("@SetId", SqlDbType.Int).Value = setId;
                        cmd.Parameters.Add("@OwnerId", SqlDbType.UniqueIdentifier).Value = ownerId;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        // Get set metadata
                        DataRow row = ds.Tables[0].Rows[0];
                        set = new Set();
                        set.SetId = (int)row["SetId"];
                        set.OwnerId = (Guid)row["OwnerId"];
                        set.DisplayName = (string)row["DisplayName"];
                        if (!row["Description"].Equals(DBNull.Value)) {
                            set.Description = (string)row["Description"];
                        }
                        set.CreatedDate = (DateTime)row["CreatedDate"];
                        if (!row["UpdatedDate"].Equals(DBNull.Value)) {
                            set.UpdatedDate = (DateTime)row["UpdatedDate"];
                        }

                        // Get specimen metadata
                        if (set.SetId >= 0) {
                            set.Specimens = GetSpecimens(cnn, setId, ownerId);
                        }
                    }
                }

                return set;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public List<Set> GetAll(Guid ownerId) {
            try {
                List<Set> sets = new List<Set>();

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprLSetsForOwner";
                        cmd.Parameters.Add("@OwnerId", SqlDbType.UniqueIdentifier).Value = ownerId;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows) {
                            Set set = new Set();
                            set.SetId = (int)row["SetId"];
                            set.OwnerId = (Guid)row["OwnerId"];
                            set.DisplayName = (string)row["DisplayName"];
                            if (!row["Description"].Equals(DBNull.Value)) {
                                set.Description = (string)row["Description"];
                            }
                            set.CreatedDate = (DateTime)row["CreatedDate"];
                            if (!row["UpdatedDate"].Equals(DBNull.Value)) {
                                set.UpdatedDate = (DateTime)row["UpdatedDate"];
                            }

                            // Get specimen metadata
                            if (set.SetId >= 0) {
                                GetSpecimens(cnn, set.SetId, ownerId);
                            }

                            sets.Add(set);
                        }
                    }
                }
                return sets;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void Add(Set set) {
            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlTransaction trn = cnn.BeginTransaction()) {
                        using (SqlCommand cmd = trn.Connection.CreateCommand()) {
                            cmd.Transaction = trn;
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                            cmd.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

                            cmd.CommandText = "dbo.sprISet";

                            cmd.Parameters.Add("@SetId", SqlDbType.Int);
                            cmd.Parameters["@SetId"].Direction = ParameterDirection.Output;

                            cmd.Parameters.Add("@OwnerId", SqlDbType.UniqueIdentifier).Value = set.OwnerId;
                            cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar).Value = set.DisplayName;
                            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = set.Description;

                            cmd.ExecuteNonQuery();

                            set.SetId = (int)cmd.Parameters["@SetId"].Value;
                        }
                        trn.Commit();
                    }
                    if (cnn.State != ConnectionState.Closed) {
                        cnn.Close();
                    }
                }
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void Update(int setId, Guid ownerId, string displayName, string description) {
            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlTransaction trn = cnn.BeginTransaction()) {
                        using (SqlCommand cmd = trn.Connection.CreateCommand()) {
                            cmd.Transaction = trn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "dbo.sprUSet";

                            cmd.Parameters.Add("@SetId", SqlDbType.Int).Value = setId;
                            cmd.Parameters.Add("@OwnerId", SqlDbType.UniqueIdentifier).Value = ownerId;
                            cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar).Value = displayName;
                            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;

                            cmd.ExecuteNonQuery();
                        }
                        trn.Commit();
                    }
                    if (cnn.State != ConnectionState.Closed) {
                        cnn.Close();
                    }
                }
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void Delete(int setId, Guid ownerId) {
            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlTransaction trn = cnn.BeginTransaction()) {
                        using (SqlCommand cmd = trn.Connection.CreateCommand()) {
                            cmd.Transaction = trn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "dbo.sprDSet";

                            cmd.Parameters.Add("@SetId", SqlDbType.Int).Value = setId;
                            cmd.Parameters.Add("@OwnerId", SqlDbType.UniqueIdentifier).Value = ownerId;

                            cmd.ExecuteNonQuery();
                        }
                        trn.Commit();
                    }
                    if (cnn.State != ConnectionState.Closed) {
                        cnn.Close();
                    }
                }
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void AddSpecimen(int setId, Guid specimenId, Guid ownerId) {
            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlTransaction trn = cnn.BeginTransaction()) {
                        AddSpecimen(trn, setId, specimenId, ownerId);
                        trn.Commit();
                    }
                    if (cnn.State != ConnectionState.Closed) {
                        cnn.Close();
                    }
                }
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void AddSpecimens(int setId, List<string> specimenIds, Guid ownerId) {
            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlTransaction trn = cnn.BeginTransaction()) {
                        foreach (string id in specimenIds) {
                            Guid specimenGuid = new Guid(id);
                            AddSpecimen(trn, setId, specimenGuid, ownerId);
                        }
                        trn.Commit();
                    }
                    if (cnn.State != ConnectionState.Closed) {
                        cnn.Close();
                    }
                }
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void RemoveSpecimen(int setId, Guid specimenId, Guid ownerId) {
            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlTransaction trn = cnn.BeginTransaction()) {
                        using (SqlCommand cmd = trn.Connection.CreateCommand()) {
                            cmd.Transaction = trn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "dbo.sprDSetSpecimen";

                            cmd.Parameters.Add("@SetId", SqlDbType.Int).Value = setId;
                            cmd.Parameters.Add("@OwnerId", SqlDbType.UniqueIdentifier).Value = ownerId;
                            cmd.Parameters.Add("@SpecimenId", SqlDbType.UniqueIdentifier).Value = specimenId;

                            cmd.ExecuteNonQuery();
                        }
                        trn.Commit();
                    }
                    if (cnn.State != ConnectionState.Closed) {
                        cnn.Close();
                    }
                }
            }
            catch (Exception e) {
                throw e;
            }
        }

        private void AddSpecimen(SqlTransaction trn, int setId, Guid specimenId, Guid ownerId) {
            using (SqlCommand cmd = trn.Connection.CreateCommand()) {
                cmd.Transaction = trn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.sprISetSpecimen";

                cmd.Parameters.Add("@SetId", SqlDbType.Int).Value = setId;
                cmd.Parameters.Add("@OwnerId", SqlDbType.UniqueIdentifier).Value = ownerId;
                cmd.Parameters.Add("@SpecimenId", SqlDbType.UniqueIdentifier).Value = specimenId;

                cmd.ExecuteNonQuery();
            }
        }

        private List<SetSpecimen> GetSpecimens(SqlConnection cnn, int setId, Guid ownerId) {
            List<SetSpecimen> specimens = new List<SetSpecimen>();

            using (SqlCommand cmd = cnn.CreateCommand()) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.sprLSetSpecimen";
                cmd.Parameters.Add("@SetId", SqlDbType.Int).Value = setId;
                cmd.Parameters.Add("@OwnerId", SqlDbType.UniqueIdentifier).Value = ownerId;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Get specimen metadata
                foreach (DataRow r in ds.Tables[0].Rows) {
                    SetSpecimen specimen = new SetSpecimen();
                    specimen.SetSpecimenId = (int)r["SetSpecimenId"];
                    specimen.SetId = (int)r["SetId"];
                    specimen.SpecimenGuid = (Guid)r["SpecimenGuid"];
                    specimen.AddedDate = (DateTime)r["AddedDate"];

                    specimens.Add(specimen);
                }
            }

            return specimens;
        }
    }
}
