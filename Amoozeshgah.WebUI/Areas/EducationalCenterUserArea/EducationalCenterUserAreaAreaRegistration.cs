using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.EducationalCenterUserArea
{
    public class EducationalCenterUserAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EducationalCenterUserArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EducationalCenterUserArea_default",
                "EducationalCenterUserArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}