using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Ashby.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Year is required")]
        [RegularExpression(@"^(188[8-9]|18[9][0-9]|19[0-9]{2}|20[0-9]{2}|21[0-9]{2})$", ErrorMessage = "Year must be 1888 or later")]
        public string Year { get; set; } = string.Empty;
        
        public string? Director { get; set; }
        
        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please specify if the movie is edited")]
        public bool Edited { get; set; }
        
        public string? LentTo { get; set; }
        
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; }
        
        [Required(ErrorMessage = "Please specify if copied to Plex")]
        public bool CopiedToPlex { get; set; }
        
        [NotMapped]
        public string? Category { get; set; }
    }
}
