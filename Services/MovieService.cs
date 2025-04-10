﻿
using MovieShop.Models.DataBase;
using MovieShop.Data;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MovieShop.Models.ViewModels;
using static NuGet.Packaging.PackagingConstants;
using MovieShop.Models;

namespace MovieShop.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _db;
        public MovieService(MovieDbContext db)
        {
            _db = db;

        }
        public void Create(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }
        public List<Movie> GetAllMovies()
        {
            return _db.Movies.ToList();
           
        }
        public List<TopCustomer> TopCustomerWhoMadeExpensiveOrder()
        {

            var topcustomer = _db.OrderRows.Join(_db.Orders, or => or.OrderId, o => o.Id,
                              (or, o) => new { or, o }).Join(_db.Customers, combined => combined.o.CustomerId,
                              c => c.Id, (combined, c) => new { combined.or, combined.o, c })
                              .Join(_db.Movies, combined => combined.or.MovieId, m => m.Id,
                              (combined, m) => new { combined.or, combined.o, combined.c, m })
                              .GroupBy(combined => combined.c.Id).
                              Select(g => new TopCustomer
                              {
                                  CustomerId = g.Key,
                                  CustomerName = g.FirstOrDefault().c.FirstNameBillingAddress + " " +g.FirstOrDefault().c.LastNameBillingAddress,
                                  TotalPrice = g.Sum(g => g.or.Price)
                              }).OrderByDescending(result => result.TotalPrice).Take(1).ToList();

            return topcustomer;
        }
        public List<Movie> OnDemandMoviesBasedOnOrders()
        {
            var onDemandMovies = _db.Movies.OrderByDescending(x => x.OrderRows.Count()).Take(10).ToList();
            return onDemandMovies;
        }
        public List<Movie> Top20Latest()
        {
            var results = _db.Movies.OrderByDescending(x => x.ReleaseYear).Take(20).ToList();

            return results;
        }
        public List<Movie> Top5Newest()
        {
            var resultNew = _db.Movies.OrderByDescending(x => x.ReleaseYear).Take(5).ToList();

            return resultNew;
        }
        public List<Movie> Top5Cheapest()
        {
            var resultCheap = _db.Movies.OrderBy(x => x.Price).Take(5).ToList();

            return resultCheap;

        }
        public List<Movie> Top5Oldest()
        {
            var resultOld = _db.Movies.OrderBy(x => x.ReleaseYear).Take(5).ToList();

            return resultOld;

        }
        public Movie GetMovieById(int id)
        {
            var movieS = _db.Movies.FirstOrDefault(x => x.Id == id);
            return movieS;
        }
       
        public void Copy(int id)
        {
            var data = _db.Movies.FirstOrDefault(x => x.Id == id);
            var movie = new Movie()
            {
                Title = data.Title,
                Director = data.Director,
                ReleaseYear = data.ReleaseYear,
                Price = data.Price
            };
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

       
    }
}
            
            
            

       
