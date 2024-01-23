using datatable_js_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace datatable_js_web.Controllers
{
    /// <summary>
    /// Not working as expected ... few changes are required 
    /// </summary>
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John Doe", Position = "Developer", Department = "IT" },
        new Employee { Id = 2, Name = "Jane Doe", Position = "Designer", Department = "Marketing" },
    };

        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult GetData()
        {
            return Json(new { data = employees });
        }

        //public IActionResult Process([FromBody] EditorData editorData)
        //{
        //    try
        //    {
              
        //        return Json(new { success = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle exceptions as needed
        //        return Json(new { error = "An error occurred while processing the data." });
        //    }
        //}

        [HttpPost]
        public IActionResult Edit(Employee updatedEmployee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = updatedEmployee.Name;
                existingEmployee.Position = updatedEmployee.Position;
                existingEmployee.Department = updatedEmployee.Department;
            }

            return Json(new { success = true });
        }
    }

}
