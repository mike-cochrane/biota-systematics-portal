using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
