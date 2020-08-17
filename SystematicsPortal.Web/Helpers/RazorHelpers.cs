using Microsoft.AspNetCore.Html;
using SystematicsData.Utility.Helpers;

namespace SystematicsPortal.Web.Helpers
{
    static public class RazorHelpers
    {
        public static HtmlString GetApplicationVersion()
        {
            return new HtmlString(AssemblyInfoHelper.GetInformationalVersion());
        }
    }
}
