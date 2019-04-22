using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.EducationalCenterFounderArea
{
    public class EducationalCenterFounderAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EducationalCenterFounderArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EducationalCenterFounderArea_default",
                "EducationalCenterFounderArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}