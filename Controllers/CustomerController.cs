using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieShop.Models.DataBase;
using MovieShop.Services;

namespace MovieShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var CustomerList = _customerService.customersList();
            return View(CustomerList);
        }

        [HttpPost]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.Delete (id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer )
        {
            if (ModelState.IsValid)
            {
                bool isCreated = _customerService.Create(customer);
                if (isCreated)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(customer);
           
        }

        [HttpPost]
        public IActionResult FindCustomer (string emailAddress)
        {
           var existingCustomer = _customerService.GetCustomerByEmail(emailAddress);
            if (existingCustomer == null)
            {
                TempData["Error"] = "Failed to find . It might already be deleted or does not exist.";
                return View(emailAddress);
            }
            return View (existingCustomer);
        }

        [HttpGet]
        public IActionResult EditCustomer (string email)
        {
            var existingCustomer = _customerService.GetCustomerByEmail (email);
            return View(existingCustomer);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer existingCustomer)
        {
           bool isEdited = _customerService.Update(existingCustomer);
            if (isEdited)
            {
                TempData["Message"] = "Updait successfull!";
                return View(existingCustomer);
            }
            else
            {
                TempData["Error"] = "Failed to edit . It might already be deleted or does not exist.";
            }

            return View(existingCustomer);
            
        }
    }
}
