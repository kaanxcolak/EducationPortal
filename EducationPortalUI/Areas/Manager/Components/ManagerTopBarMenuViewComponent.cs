﻿using Microsoft.AspNetCore.Mvc;

namespace EducationPortalUI.Areas.Manager.Components;

    public class ManagerTopBarMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

