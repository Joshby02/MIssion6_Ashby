using System.ComponentModel.DataAnnotations;

namespace Mission6_Ashby.Models
{
    public class Director
    {
        public int DirectorId { get; set; }
        
        [Required]
        public string DirectorName { get; set; } = string.Empty;
        
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
