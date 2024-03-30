using System.ComponentModel.DataAnnotations;

namespace E_Library_API.Model
{
    public class Genre
    {
        [Key]
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string? GenreName { get; set; }
    }

}
