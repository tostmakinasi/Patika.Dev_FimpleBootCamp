using System.ComponentModel.DataAnnotations;

namespace Assignment.API.Models
{
    public class Product
    {
        [Required(ErrorMessage ="ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue,ErrorMessage =$"Price must be greater than or equal to 0.")]
        public double Price { get; set; }

    }
}
