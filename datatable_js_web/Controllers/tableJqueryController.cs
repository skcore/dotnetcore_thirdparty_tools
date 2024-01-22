using datatable_js_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace datatable_js_web.Controllers
{
    /// <summary>
    /// Working as expected 
    /// </summary>
    public class tableJqueryController : Controller
    {
        private List<Customer> customers = new List<Customer>();

        public IActionResult Index()
        {
            Customer customer = new Customer();
            customers = customer.GetCustomers();
            ViewBag.Citys = JsonSerializer.Serialize(SampleData.States);
            return View(customers);
        }
        public string DeleteData(int id)
        {
            return ""; 
        }
        [HttpPost]
        public string UpdateData(int id, string value, int rowId,int? columnPosition, int? columnId, string columnName)
        {
            return "";
        }
        public int AddData(string name, string address, string town, int? country) 
        { 
            return 0;
        }

    }
}
