using System.ComponentModel;
using System.Reflection;

namespace SystematicsPortal.Utility.Helpers
{
    public static class PropertyHelpers
    {
        public static string GetPropertyDisplayName<T>(string propertyString)
        {
            MemberInfo property = typeof(T).GetProperty(propertyString);

            var displayAttribute = property.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;

            return displayAttribute?.DisplayName;
        }
    }
}
