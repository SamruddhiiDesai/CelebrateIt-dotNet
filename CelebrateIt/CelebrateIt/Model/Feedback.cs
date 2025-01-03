using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CelebrateIt.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        [MaxLength(512)]
        public string Image { get; set; } // Optional, can store image paths or URLs.

        [Required]
        [Column(TypeName = "TEXT")]
        public string FeedbackMessage { get; set; }

        [Required]
        [Column(TypeName = "decimal(3,2)")]
        public decimal Rating { get; set; }

        // Foreign Key: UserId
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users Users { get; set; } // Navigation property
    }
}

