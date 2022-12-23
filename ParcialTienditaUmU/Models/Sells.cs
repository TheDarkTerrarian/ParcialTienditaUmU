using System.ComponentModel.DataAnnotations;

namespace ParcialTienditaUmU.Models
{
    public class Sells
    {
        [Key]
        public int sellId { get; set; }

        [Required]
        public string userId { get; set; }

        [Required]
        public DateTime sellDate { get; set; }

        [Required]
        public double totalToPay { get; set; }

        [Required]

        public IEnumerable<Products> productsList { get; set; }
    }
}
