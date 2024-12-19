using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models.DataBase
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie's Title is required.")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = " Director of Movie is required.")]
        [StringLength(50)]
        public string Director { get; set; }

        [Required(ErrorMessage = "Release Year of Movie is required.")]
        [Display(Name ="Released Year")]
        [StringLength(10)]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Price of Movie is required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }


        public virtual ICollection<OrderRow> OrderRows { get; set; } = new List<OrderRow>();

    }
}
