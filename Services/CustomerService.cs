﻿using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Models.DataBase;
using MovieShop.Models.ViewModels;
using System.Diagnostics.Metrics;
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
            var customer = _db.Customers.Include(c => c.Orders).ToList();
            return customer;
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
            var existingCustomer = _db.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer == null)
            {
                _logger.LogError ( $"Customer {customer} is not Existing");
                return false;
            }

            existingCustomer.EmailAddress = customer.EmailAddress;
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

        public List<OrderViewModel> GetAllOrdersByCustomer(int customerId)
        {
           var orders = _db.Orders.Where(o =>o.CustomerId == customerId)
                                  .Include(o=>o.OrderRows)
                                  .ThenInclude(or=>or.Movie)
                                  .OrderByDescending(o=>o.OrderDate)
                                  .Select(o=> new OrderViewModel
                                  {
                                      OrderId = o.Id,
                                      OrderDate = o.OrderDate,
                                      Totalcost = o.OrderRows.Sum(or => or.Quantity * or.Price),
                                      Movies = o.OrderRows.Select(or=> new MovieItemViewModel
                                      {
                                          PosterPath = or.Movie.PosterPath,
                                          Title = or.Movie.Title,
                                          Quantity = or.Quantity,
                                          Price = or.Price
                                      })
                                      .ToList()


                                  })
                                  .ToList();
            return orders;
        }

       


    }
}
