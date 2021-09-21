using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}