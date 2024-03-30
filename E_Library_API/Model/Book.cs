

using System.ComponentModel.DataAnnotations;

namespace E_Library_API.Model
{
    public class Book
    {
        [Key]
        public Guid Guid { get; private set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? AvailabilityStatus { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int BorrowedQuantity { get; set; }
        public Genre? Genre { get; set; }
        public List<User> Users { get; set; } = [];
        public List<BorrowedBook> BorrowedBooks { get; set; } = [];
    }
}
