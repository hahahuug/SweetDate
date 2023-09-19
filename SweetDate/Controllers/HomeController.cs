using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SweetDate.DAL.Interfaces;

namespace SweetDate.Controllers;

public class HomeController : Controller
    { 
        public IActionResult Index()
        {
            if (TempData.ContainsKey("RegisterErrors"))
            {
                var registerErrors = TempData["RegisterErrors"] as List<string>;
                if (registerErrors != null && registerErrors.Any())
                {
                    foreach (var error in registerErrors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View();
        }


    }