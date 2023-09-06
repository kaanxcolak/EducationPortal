using Microsoft.AspNetCore.Mvc;

namespace EducationPortalUI.Areas.Student.Components;

    public class StudentTopBarMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

