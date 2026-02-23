using Aps.net_Ef_Core_book_store.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Aps.net_Ef_Core_book_store.Data
{
    public class ApplicationContext : DbContext

    {

        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)

        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
