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
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Price of Movie is required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        //public string? PosterPath { get; set; } = string.Empty; // Shows path to movie poster in local files or could be external link also (example: "/wwwroot/images/posters/1.jpg")
        public virtual ICollection<OrderRow> OrderRows { get; set; } = new List<OrderRow>();

    }
}
