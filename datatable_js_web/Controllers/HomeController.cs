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
        private List<Customer> customers = new List<Customer>();

        public IActionResult Index()
        {
            Customer customer = new Customer();
            customers = customer.GetCustomers();
            return View(customers);
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
