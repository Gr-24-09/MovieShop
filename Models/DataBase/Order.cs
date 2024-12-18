using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Models.DataBase
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Order Date is required.")]
        [Display(Name = "Order Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime OrderDate { get; init; } = DateTime.Now;

        [ForeignKey("Customer")]
        [Required(ErrorMessage = "Customer Id is required.")]
        [Display(Name = "Customer Id ")]
        public int CustomerId { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public Customer? Customer { get; set; }

        public List<OrderRow> OrderRows { get; set; } = new List<OrderRow>() ;

    }
}
