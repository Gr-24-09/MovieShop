using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Models.DataBase
{
    public class OrderRow
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        [Required(ErrorMessage = "Order Id is required.")]
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }

        [ForeignKey("Movie")]
        [Required(ErrorMessage = "Movie Id is required.")]
        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }


        [Required(ErrorMessage = "Price of Movie is required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
