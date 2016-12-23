using System.Web.Mvc;

namespace TechHome.Webs.Areas.WebSpider
{
    public class WebSpiderAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WebSpider";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WebSpider_default",
                "WebSpider/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}