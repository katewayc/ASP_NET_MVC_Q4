using System.Web;
using System.Web.Mvc;

namespace mvc_Q4_using_Fetch
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
