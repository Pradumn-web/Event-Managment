using System.Web;
using System.Web.Mvc;

namespace Event_Managment_and_Ticketing_System
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
