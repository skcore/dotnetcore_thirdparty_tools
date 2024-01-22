using datatable_js_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace datatable_js_web.Controllers
{
    /// <summary>
    /// Not completed ... few changes are required 
    /// </summary>
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            Customer customer = new Customer();
            return View(customer.GetCustomers());
        }
        [HttpGet]
        public IActionResult GetData(int page, int pageSize)
        {
            Customer customer = new Customer();
            var results = customer.GetCustomers().Skip(page - 1 * pageSize).Take(pageSize).ToList();
            return Json(new { data = results });

        }
    }
}
