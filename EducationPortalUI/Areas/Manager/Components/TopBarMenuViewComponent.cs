using Microsoft.AspNetCore.Mvc;

namespace EducationPortalUI.Areas.Manager.Components;

    public class TopBarMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

