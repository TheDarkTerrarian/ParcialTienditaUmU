using System.ComponentModel.DataAnnotations;

namespace ParcialTienditaUmU.Models
{
    public class Orders
    {
        [Key]
        public int orderId { get; set; }

        [Required]
        public string userId { get; set; }

        [Required]
        public DateTime orderDate { get; set; }

        [Required]
        public double totalPrice { get; set; }

        [Required]

        public IEnumerable<Products> productsList { get; set; }
    }
}
