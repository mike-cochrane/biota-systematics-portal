using Systematics.Portal.Web.Data.Interfaces;
using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Data.Sql.Repositories
{
    public class DownloadLogsRepository : IDownloadLogsRepository
    {
        private string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public void Add(DownloadLog d)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                cnn.Open();
                using (SqlTransaction trn = cnn.BeginTransaction())
                {
                    using (SqlCommand cmd = trn.Connection.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = trn;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandText = "dbo.sprIDownloadLog";

                            cmd.Parameters.Add("@DownloadId", System.Data.SqlDbType.UniqueIdentifier).Value = d.DownloadId;
                            cmd.Parameters.Add("@UserId", System.Data.SqlDbType.UniqueIdentifier).Value = d.UserId;
                            cmd.Parameters.Add("@UserOrganisation", System.Data.SqlDbType.NVarChar).Value = d.UserOrganisation;
                            cmd.Parameters.Add("@RequestedSpecimens", System.Data.SqlDbType.NVarChar).Value = d.RequestedSpecimens.TrimEnd(';');
                            cmd.Parameters.Add("@FailedToRetrieveSpecimens", System.Data.SqlDbType.NVarChar).Value = d.FailedToRetrieveSpecimens.TrimEnd(';');
                            cmd.Parameters.Add("@DownloadPurposeId", System.Data.SqlDbType.Int).Value = d.DownloadPurposeId;
                            if (d.OtherPurposeText == null)
                            {
                                cmd.Parameters.Add("@OtherPurpose", System.Data.SqlDbType.NVarChar).Value = string.Empty;
                            }
                            else
                            {
                                cmd.Parameters.Add("@OtherPurpose", System.Data.SqlDbType.NVarChar).Value = d.OtherPurposeText;
                            }
                            cmd.Parameters.Add("@RequestDate", System.Data.SqlDbType.DateTime).Value = d.RequestDate;
                            cmd.Parameters.Add("@CHRRecordCount", System.Data.SqlDbType.Int).Value = d.CHRRecordCount;
                            cmd.Parameters.Add("@ICMPRecordCount", System.Data.SqlDbType.Int).Value = d.ICMPRecordCount;
                            cmd.Parameters.Add("@FLAXRecordCount", System.Data.SqlDbType.Int).Value = d.FLAXRecordCount;
                            cmd.Parameters.Add("@NZACRecordCount", System.Data.SqlDbType.Int).Value = d.NZACRecordCount;
                            cmd.Parameters.Add("@PDDRecordCount", System.Data.SqlDbType.Int).Value = d.PDDRecordCount;
                            cmd.Parameters.Add("@Success", System.Data.SqlDbType.Bit).Value = d.Success;

                            cmd.ExecuteNonQuery();
                            trn.Commit();
                        }
                        catch (Exception e)
                        {
                            trn.Rollback();
                            throw;
                        }
                    }
                }
                if (cnn.State != System.Data.ConnectionState.Closed)
                {
                    cnn.Close();
                }
            }
        }
    }
}
