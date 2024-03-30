using E_Library_API.Model;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace E_Library_API.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        //public DbSet<BorrowedBook> BorrowedBooks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ALIALJAWAD\\SQLEXPRESS;Database=E_Library2.0;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BorrowedBook>().HasKey(bb => new {bb.UserId, bb.BookGuid});
            //builder.Entity<Book>()
            //       .HasMany(e => e.Users)
            //       .WithMany(e => e.Books)
            //       .UsingEntity<BorrowedBook>(
            //            l => l.HasOne<User>().WithMany().HasForeignKey(e => e.UserGuid),
            //            r => r.HasOne<Book>().WithMany().HasForeignKey(e => e.BookGuid));
            base.OnModelCreating(builder);
        }
    }
}
