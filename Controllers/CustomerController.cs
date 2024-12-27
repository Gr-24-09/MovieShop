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
            if (existingCustomer == null)
            {
                TempData["Error"] = "Customer not found.";
                return RedirectToAction("Index");
            }
            return View(existingCustomer);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer existingCustomer)
        {
            if (!ModelState.IsValid)
            {
                return View(existingCustomer); 
            }
            bool isEdited = _customerService.Update(existingCustomer);
            if (isEdited)
            {
                TempData["Message"] = "Updait successfull!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to edit . It might already be deleted or does not exist.";
                return View(existingCustomer);
            }

        }

        public IActionResult AllOrderByCustomer(int id)
        {
            var orders = _customerService.GetAllOrdersByCustomer(id);
            if (orders == null || orders.Count == 0)
            {
                ViewBag.Message = "No orders found for this customer.";
                return View(new List<Order>()); 
            }
            return View(orders);
        }
    }
}
