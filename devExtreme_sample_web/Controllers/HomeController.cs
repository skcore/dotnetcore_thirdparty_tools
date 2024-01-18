using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using devExtreme_Sample_Grid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace devExtreme_Sample_Grid.Controllers
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
            return View();
        }
        [HttpGet]
        public object GetStates(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(SampleData.States, loadOptions);
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            Customer customer = new Customer();
            return DataSourceLoader.Load(customer.GetCustomers(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {


            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {


            return Ok();
        }

        [HttpDelete]
        public void Delete(int key)
        {

        }
    }
}
