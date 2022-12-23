using System.ComponentModel.DataAnnotations;

namespace ParcialTienditaUmU.Models
{
    public class User
    {
        [Key] public int idUser { get; set; }

        [Required]
        public string username { get; set; }
        
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        
        [Required]
        public string fullName { get; set; }
        
        [Required]
        public string rol { get; set; }
        
        [Required]       
        public bool isAdmin { get; set; }
    }
}
