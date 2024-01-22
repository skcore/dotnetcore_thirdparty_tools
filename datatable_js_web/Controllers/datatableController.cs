using datatable_js_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace datatable_js_web.Controllers
{
    /// <summary>
    /// Not working as expected ... few changes are required 
    /// </summary>
    public class datatableController : Controller
    {
        private List<Customer> customers = new List<Customer>();

        public IActionResult Index()
        {
            Customer customer = new Customer();
            customers = customer.GetCustomers();
            return View(customers);
        }

        [HttpPost]
        public IActionResult GetData()
        {
            Customer customer = new Customer();
            customers = customer.GetCustomers();
            return Json(new { data = customers });
        }

        [HttpPost("Process")]
        public IActionResult Process([FromBody] Editor editorData)
        {
            try
            {
                //// Return a success response
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                return Json(new { error = "An error occurred while processing the data." });
            }
        }
        public IActionResult Edit(Customer updatedCustomer)
        {
            return Json(new { success = true });
        }
        public IActionResult Delete(int id)
        {
            return Json(new { success = true });
        }

    }
}
