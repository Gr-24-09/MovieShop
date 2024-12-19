using MovieShop.Models.DataBase;

namespace MovieShop.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerByEmail(string emailAddress);
        bool Create(Customer customer);
        bool Update(Customer customer);
        bool Delete(int id);
        List<Customer> customersList ();
    }
}
