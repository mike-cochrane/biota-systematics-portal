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
    public class SectionContentsRepository : ISectionContentsRepository {
        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public SectionContent Get(string pageType, string sectionType) {
            try {
                SectionContent content = null;

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprSSectionContent";
                        cmd.Parameters.Add("@PageType", SqlDbType.NVarChar).Value = pageType;
                        cmd.Parameters.Add("@SectionType", SqlDbType.NVarChar).Value = sectionType;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        DataRow row = ds.Tables[0].Rows[0];
                        content = new SectionContent();
                        content.SectionContentId = (int)row["SectionContentId"];
                        content.PageType = (string)row["PageType"];
                        content.SectionType = (string)row["SectionType"];
                        content.Content = (string)row["SectionContent"];
                        if (!row["ValidFrom"].Equals(DBNull.Value)) {
                            content.ValidFrom = (DateTime)row["ValidFrom"];
                        }
                        if (!row["ValidUntil"].Equals(DBNull.Value)) {
                            content.ValidUntil = (DateTime)row["ValidUntil"];
                        }
                    }

                    if (cnn.State != System.Data.ConnectionState.Closed) {
                        cnn.Close();
                    }
                }

                return content;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public SectionContent GetCurrent(string pageType, string sectionType) {
            try {
                SectionContent content = null;

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprSSectionContentCurrent";
                        cmd.Parameters.Add("@PageType", SqlDbType.NVarChar).Value = pageType;
                        cmd.Parameters.Add("@SectionType", SqlDbType.NVarChar).Value = sectionType;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        DataRow row = ds.Tables[0].Rows[0];
                        content = new SectionContent();
                        content.SectionContentId = (int)row["SectionContentId"];
                        content.PageType = (string)row["PageType"];
                        content.SectionType = (string)row["SectionType"];
                        content.Content = (string)row["SectionContent"];
                        if (!row["ValidFrom"].Equals(DBNull.Value)) {
                            content.ValidFrom = (DateTime)row["ValidFrom"];
                        }
                        if (!row["ValidUntil"].Equals(DBNull.Value)) {
                            content.ValidUntil = (DateTime)row["ValidUntil"];
                        }
                    }

                    if (cnn.State != System.Data.ConnectionState.Closed) {
                        cnn.Close();
                    }
                }

                return content;
            }
            catch (Exception e) {
                throw e;
            }
        }
    }
}
