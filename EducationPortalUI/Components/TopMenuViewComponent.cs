using Microsoft.AspNetCore.Mvc;

namespace EducationPortalUI.Components
{
    public class TopMenuViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
