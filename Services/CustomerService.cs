using MovieShop.Data;
using MovieShop.Models.DataBase;
using System.Net.Mail;

namespace MovieShop.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly MovieDbContext _db;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(MovieDbContext  movieDbContext , ILogger<CustomerService> logger)
        {
            _db = movieDbContext;
            _logger = logger;
        }

        public List<Customer> customersList()
        {
            return _db.Customers.ToList();
        }

        
        public Customer GetCustomerByEmail(string emailAddress)
        {
           return _db.Customers.FirstOrDefault(c => c.EmailAddress == emailAddress);
          
        }

        public bool Create(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return true;
        }

        public bool Update(Customer customer)
        {
            var existingCustomer = _db.Customers.FirstOrDefault(c => c.EmailAddress == customer.EmailAddress);
            if (existingCustomer == null)
            {
                _logger.LogError ( $"Customer {customer} is not Existing");
                return false;
            }
           
            existingCustomer.DeliveryAddress = customer.DeliveryAddress;
            existingCustomer.DeliverCity = customer.DeliverCity;
            existingCustomer.DeliverZip = customer.DeliverZip;
            existingCustomer.FirstNameDeliveryAddress = customer.FirstNameDeliveryAddress;
            existingCustomer.LastNameDeliveryAddress = customer.LastNameDeliveryAddress;
            existingCustomer.BillingAddress = customer.BillingAddress;
            existingCustomer.BillingCity = customer.BillingCity;
            existingCustomer.BillingZip = customer.BillingZip;
            existingCustomer.FirstNameBillingAddress = customer.FirstNameBillingAddress;
            existingCustomer.LastNameBillingAddress = customer.LastNameBillingAddress;
            existingCustomer.PhoneNo = customer.PhoneNo;

            _db.SaveChanges();
            return true;
        }

        public bool Delete (int id)
        {
            var customer = _db.Customers.FirstOrDefault(c=> c.Id == id);
            if (customer == null)
            {
                return false;
            }
            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return true;
        }
    }
}
