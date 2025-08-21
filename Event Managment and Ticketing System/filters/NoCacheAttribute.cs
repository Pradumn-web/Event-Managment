using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event_Managment_and_Ticketing_System.filters
{
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            response.Cache.SetNoStore();
            response.AppendHeader("Pragma", "no-cache");
            response.AppendHeader("Cache-Control", "no-store, must-revalidate");
            response.AppendHeader("Expires", "0");

            base.OnResultExecuting(filterContext);
        }
    }
}