using datatable_js_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace datatable_js_web.Controllers
{
    /// <summary>
    /// Working as expected 
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            return Json(new { success = true });
        }
    }
}
