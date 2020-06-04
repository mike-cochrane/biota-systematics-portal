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
    public class CollectionRolesRepository : ICollectionRolesRepository {
        
        private string ConnectionString {
            get { return ConfigurationManager.ConnectionStrings["CISWebConnectionString"].ConnectionString; }
        }

        public List<CollectionRole> GetByCollection(Guid collectionId) {
            try {
                List<CollectionRole> collectionRoles = new List<CollectionRole>();

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprLCollectionRoleForCollection";
                        cmd.Parameters.Add("@CollectionId", SqlDbType.UniqueIdentifier).Value = collectionId;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows) {
                            CollectionRole cr = new CollectionRole();
                            cr.CollectionRoleId = (int)row["CollectionRoleId"];
                            cr.CollectionId = (Guid)row["CollectionId"];
                            cr.RoleId = (int)row["RoleId"];
                            cr.RoleName = (string)row["RoleName"];
                            cr.ContactId = (int)row["ContactId"];
                            if (!row["ContactName"].Equals(DBNull.Value)) {
                                cr.ContactName = (string)row["ContactName"];
                            }
                            cr.ContactEmail = (string)row["ContactEmail"];

                            collectionRoles.Add(cr);
                        }
                    }
                }
                return collectionRoles;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public List<CollectionRole> GetByCollectionAcronym(string acronym) {
            try {
                List<CollectionRole> collectionRoles = new List<CollectionRole>();

                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    cnn.Open();
                    using (SqlCommand cmd = cnn.CreateCommand()) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.sprLCollectionRoleForCollectionAcronym";
                        cmd.Parameters.Add("@Acronym", SqlDbType.NVarChar).Value = acronym;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows) {
                            CollectionRole cr = new CollectionRole();
                            cr.CollectionRoleId = (int)row["CollectionRoleId"];
                            cr.CollectionId = (Guid)row["CollectionId"];
                            cr.RoleId = (int)row["RoleId"];
                            cr.RoleName = (string)row["RoleName"];
                            cr.ContactId = (int)row["ContactId"];
                            if (!row["ContactName"].Equals(DBNull.Value)) {
                                cr.ContactName = (string)row["ContactName"];
                            }
                            cr.ContactEmail = (string)row["ContactEmail"];

                            collectionRoles.Add(cr);
                        }
                    }
                }
                return collectionRoles;
            }
            catch (Exception e) {
                throw e;
            }
        }
    }
}
