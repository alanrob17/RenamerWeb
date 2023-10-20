using System.ComponentModel.DataAnnotations;

namespace RenamerWeb.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Folder { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

    }
}
