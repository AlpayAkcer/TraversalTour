﻿using Microsoft.AspNetCore.Mvc;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}