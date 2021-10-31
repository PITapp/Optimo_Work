using System;
using Microsoft.AspNetCore.Mvc;

namespace OptimoWork.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
