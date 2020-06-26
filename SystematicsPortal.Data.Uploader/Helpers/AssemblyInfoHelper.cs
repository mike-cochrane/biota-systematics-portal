using System.Linq;
using System.Reflection;

namespace SystematicsPortal.Data.Uploader.Helpers
{
    public static class AssemblyInfoHelper
    {
        public static string GetInformationalVersion(string defaultValue = "-")
        {
            var assembly = Assembly.GetCallingAssembly();

            return GetInformationalVersion(assembly, defaultValue);
        }

        public static string GetInformationalVersion(Assembly assembly, string defaultValue = "-")
        {
            object[] attributes;

            attributes = assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);

            if (attributes.Any())
            {
                return ((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion;
            }
            else
            {
                return defaultValue;
            }
        }

        public static string GetDescription(Assembly assembly, string defaultValue = "-")
        {
            object[] attributes;

            attributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

            if (attributes.Any())
            {
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
            else
            {
                return defaultValue;
            }
        }

        public static string GetTitle(Assembly assembly, string defaultValue = "-")
        {
            object[] attributes;

            attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

            if (attributes.Any())
            {
                return ((AssemblyTitleAttribute)attributes[0]).Title;
            }
            else
            {
                return defaultValue;
            }
        }
    }
}
