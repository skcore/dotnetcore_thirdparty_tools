using datatable_js_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace datatable_js_web.Controllers
{
    public class mvcController : Controller
    {
        private List<Customer> filteredUsers = new List<Customer>();
        public IActionResult Index(string sortOrder, string nameFilter, int page = 1)
        {
            Customer customer = new Customer();

            filteredUsers = customer.GetCustomers();

            if (!string.IsNullOrEmpty(nameFilter))
            {
                filteredUsers = filteredUsers.Where(u => (u.EmpName.Contains(nameFilter, StringComparison.OrdinalIgnoreCase) || u.Department.Contains(nameFilter, StringComparison.OrdinalIgnoreCase))).ToList();
            }

            switch (sortOrder)
            {
                case "ID":
                    filteredUsers = filteredUsers.OrderBy(u => u.ID).ToList();
                    break;
                case "Name":
                    filteredUsers = filteredUsers.OrderBy(u => u.EmpName).ToList();
                    break;
                case "Department":
                    filteredUsers = filteredUsers.OrderBy(u => u.Department).ToList();
                    break;
                // Add more cases for additional columns if needed
                default:
                    filteredUsers = filteredUsers.OrderBy(u => u.ID).ToList();
                    break;
            }

            int pageSize = 5;
            int totalPages = (int)Math.Ceiling((double)filteredUsers.Count() / pageSize);

            filteredUsers = filteredUsers.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.Page = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SortOrder = sortOrder;
            ViewBag.NameFilter = nameFilter;

            return View(filteredUsers);
        }
        // Action for handling inline edit
        [HttpPost]
        public IActionResult Edit(int Id,string Name,string Department,string City)
        {
            // Perform update logic here
            // ...

            return RedirectToAction("Index");
        }

        // Action for handling delete
        [HttpPost]
        public IActionResult Delete(int customerId)
        {
            // Perform delete logic here
            // ...

            return RedirectToAction("Index");
        }

        // Action for handling add
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            // Perform add logic here
            // ...

            return RedirectToAction("Index");
        }
    }

}
