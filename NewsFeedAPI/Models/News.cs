using NewsFeedAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsFeedAPI.Models
{
    public class News
    {
        public int NewsId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

        public string UrlImage { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "int")]
        public NewsCategory Category { get; set; } = NewsCategory.None;
    }
}
