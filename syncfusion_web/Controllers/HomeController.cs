using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using Syncfusion_web.Models;
using System.Collections;
using System.Diagnostics;

namespace Syncfusion_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Customer customer = new Customer();

            ViewData["customers"] = customer.GetCustomers();
            ViewData["states"] = SampleData.States;

            return View();
        }

        public IActionResult UrlDatasource([FromBody] DataManagerRequest dm)
        {
            Customer customer = new Customer();

            IEnumerable DataSource = customer.GetCustomers();
            DataOperations operation = new DataOperations();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Customer>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new JsonResult(new { result = DataSource, count = count }) : new JsonResult(DataSource);
        }

        public ActionResult CrudUpdate([FromBody] ICRUDModel<Customer> value, string action)
        {
            if (value.action == "update")
            {

            }
            else if (value.action == "insert")
            {

            }
            else if (value.action == "remove")
            {

                return new JsonResult(value);
            }
            return new JsonResult(value.value);
        }

        public class ICRUDModel<T> where T : class
        {
            public string action { get; set; }

            public string table { get; set; }

            public string keyColumn { get; set; }

            public object key { get; set; }

            public T value { get; set; }

            public List<T> added { get; set; }

            public List<T> changed { get; set; }

            public List<T> deleted { get; set; }

            public IDictionary<string, object> @params { get; set; }
        }
    }
}
