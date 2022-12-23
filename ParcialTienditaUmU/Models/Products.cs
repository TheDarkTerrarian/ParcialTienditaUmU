using System.ComponentModel.DataAnnotations;

namespace ParcialTienditaUmU.Models
{
    public class Products
    {
        [Key]
        public int idProduct { get; set; }

        [Required]
        public string productName { get; set; }

        [Required]
        public double productPrice { get; set; }

        [Required]
        public int stock { get; set; }

        [Required]
        public string category { get; set; }
    }
}
