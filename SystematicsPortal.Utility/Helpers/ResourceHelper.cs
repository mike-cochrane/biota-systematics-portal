using System;
using System.IO;
using System.Reflection;

namespace SystematicsPortal.Utility.Helpers
{
    public static class ResourceHelper
    {
        public static string GetResourceString(string resourceName)
        {
            var assembly = Assembly.GetCallingAssembly();

            return GetResourceString(assembly, resourceName);
        }

        public static string GetResourceString(Assembly assembly, string resourceName)
        {
            string resource = String.Empty;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var streamReader = new StreamReader(stream))
            {
                resource = streamReader.ReadToEnd();
            }

            return resource;
        }

        public static byte[] GetResourceBytes(string resourceName)
        {
            var assembly = Assembly.GetCallingAssembly();

            return GetResourceBytes(assembly, resourceName);
        }

        public static byte[] GetResourceBytes(Assembly assembly, string resourceName)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var streamReader = new MemoryStream())
            {
                stream.CopyTo(streamReader);

                return streamReader.ToArray();
            }
        }
    }
}
