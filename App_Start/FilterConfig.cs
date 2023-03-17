using System.Web;
using System.Web.Mvc;

namespace dummy_dot_net_framework_web_app
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
