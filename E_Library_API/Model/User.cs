using Microsoft.AspNetCore.Identity;

namespace E_Library_API.Model
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Book> Books { get; set; } = [];
        public List<BorrowedBook> BorrowedBooks { get; set; } = [];

        public User()
        {

        }
    }
}
