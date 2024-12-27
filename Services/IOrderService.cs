using MovieShop.Models.DataBase;

namespace MovieShop.Services
{
    public interface IOrderService
    {
        public List<Order> SpecificCustomerOrder();
        public List<Order> LatestFiveOrders();


    }
}
