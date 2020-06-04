using Systematics.Portal.Web.Data.Interfaces;
using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Data.Sql.Repositories
{
    public class DownloadPurposesRepository : IDownloadPurposesRepository
    {
        private string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public List<DownloadPurpose> GetAll()
        {
            try
            {
                List<DownloadPurpose> lst = new List<DownloadPurpose>();

                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprLDownloadPurpose";

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            DownloadPurpose dp = new DownloadPurpose()
                            {
                                DownloadPurposeId = (int)row["DownloadPurposeId"],
                                Purpose = (string)row["DownloadPurpose"]
                            };
                            if (!row["DisplayOrder"].Equals(DBNull.Value))
                            {
                                dp.DisplayOrder = (int)row["DisplayOrder"];
                            }
                            lst.Add(dp);
                        }
                    }

                    if (cnn.State != System.Data.ConnectionState.Closed)
                    {
                        cnn.Close();
                    }
                }

                return lst;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
