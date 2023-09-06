using Microsoft.AspNetCore.Mvc;

namespace EducationPortalUI.Areas.Student.Components;
public class StudentSideBarMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }