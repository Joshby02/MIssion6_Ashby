using System.ComponentModel.DataAnnotations;

namespace Mission6_Ashby.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Year { get; set; } = string.Empty;

        [Required]
        public string Rating { get; set; } = string.Empty;

        public bool Edited { get; set; } = false;

        public string? LentTo { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int DirectorId { get; set; }

        public Category Category { get; set; } = null!;
        public Director Director { get; set; } = null!;
    }
}