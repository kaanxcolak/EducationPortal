using Microsoft.AspNetCore.Mvc;

namespace EducationPortalUI.Areas.Manager.Components;
public class ManagerSideBarMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }