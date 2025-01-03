using System.ComponentModel.DataAnnotations;

namespace CelebrateIt.Models
{
    public class Users
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [MaxLength(15)]
        [Phone]
        public string ContactNumber { get; set; }

        [Required]
        public UserRole Role { get; set; }
    }
}

