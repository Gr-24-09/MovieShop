using MovieShop.Data;
using MovieShop.Models.DataBase;

namespace MovieShop.Services
{
    public class OrderService
    {
        private readonly MovieDbContext _db;

        public OrderService(MovieDbContext db)
        {
            _db = db;
        }

       public List <Order> AdminOrder()
        {
            var allOrdersAdmin = _db.Orders
                .OrderByDescending(c=>c.OrderDate).ToList();
            return allOrdersAdmin;


        }


        
        
        
        public List<Order> LatestFiveOrders()
        {
            var latestOrders = _db.Orders.OrderBy(d => d.OrderDate).Take(5).ToList();

            return latestOrders;

        }



    }
}
