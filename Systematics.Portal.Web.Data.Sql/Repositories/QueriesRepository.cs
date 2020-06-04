using Systematics.Portal.Web.Data.Interfaces;
using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Data.Sql.Repositories {
    public class QueriesRepository : IQueriesRepository {

        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public void Add(Query q) {
            using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                cnn.Open();
                using (SqlTransaction trn = cnn.BeginTransaction()) {
                    using (SqlCommand cmd = trn.Connection.CreateCommand()) {
                        try {
                            cmd.Transaction = trn;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandText = "dbo.sprIQuery";

                            cmd.Parameters.Add("@AppliedFacetValues", System.Data.SqlDbType.NVarChar).Value = q.AppliedFacetValues;
                            cmd.Parameters.Add("@AppliedRanges", System.Data.SqlDbType.NVarChar).Value = q.AppliedRanges;
                            cmd.Parameters.Add("@CollectionFilter", System.Data.SqlDbType.NVarChar).Value = q.CollectionFilter;
                            cmd.Parameters.Add("@QueryString", System.Data.SqlDbType.NVarChar).Value = q.QueryString;
                            cmd.Parameters.Add("@SpecimenCount", System.Data.SqlDbType.Int).Value = q.SpecimenCount;
                            cmd.Parameters.Add("@SubmittedTime", System.Data.SqlDbType.DateTime).Value = q.SubmittedTime;
                            cmd.Parameters.Add("@ReturnedTime", System.Data.SqlDbType.DateTime).Value = q.ReturnedTime;
                            cmd.Parameters.Add("@Success", System.Data.SqlDbType.Bit).Value = q.Success;
                            cmd.Parameters.Add("@UserId", System.Data.SqlDbType.UniqueIdentifier).Value = q.UserId;

                            cmd.ExecuteNonQuery();
                            trn.Commit();
                        }
                        catch (Exception e) {
                            trn.Rollback();
                            throw;
                        }
                    }
                }
                if (cnn.State != System.Data.ConnectionState.Closed) {
                    cnn.Close();
                }
            }
        }
    }
}
