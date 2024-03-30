namespace E_Library_API.Model
{
    public class BorrowedBook
    {
        public string? UserId { get; set; }
        public User? User { get; set; }
        public Guid? BookGuid { get; set; }
        public Book? Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BorrowedBook()
        {
            
        }
        public BorrowedBook(User user, Book book, DateTime borrowDate, DateTime? returnDate)
        {
            User = user;
            Book = book;
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
        }
    }
}
