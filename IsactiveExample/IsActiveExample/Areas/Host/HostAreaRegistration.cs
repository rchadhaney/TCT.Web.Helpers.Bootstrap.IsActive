using System.Web.Mvc;

namespace IsActiveExample.Areas.Host
{
    public class HostAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Host";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Host_default",
                "Host/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "IsActiveExample.Areas.Host.Controllers" }
            );
        }
    }
}