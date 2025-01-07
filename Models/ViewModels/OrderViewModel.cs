namespace MovieShop.Models.ViewModels
{
    public class OrderViewModel
    {
        public  int OrderId { get; set; }
        public  string CustomerName { get; set; }= string.Empty;
        public DateTime  OrderDate { get; set; }
        public decimal Totalcost { get; set; }
        public List<MovieItemViewModel> Movies { get; set; } = new List<MovieItemViewModel>();
    }

    public class MovieItemViewModel
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
