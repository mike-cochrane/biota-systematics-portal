using System.Data.Common;

namespace SystematicsPortal.Utility.Helpers
{
    public static class ConnectionStringHelper
    {
        public static string ReplacePassword(string connectionString, string replacementText)
        {
            var builder = new DbConnectionStringBuilder();

            builder.ConnectionString = connectionString;

            if (builder.ContainsKey("password")) { builder["password"] = replacementText; }
            if (builder.ContainsKey("pwd")) { builder["pwd"] = replacementText; }

            return builder.ConnectionString;
        }
    }
}
