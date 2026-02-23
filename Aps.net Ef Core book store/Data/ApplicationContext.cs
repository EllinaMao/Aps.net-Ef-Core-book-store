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

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Фантастика" },
                new Genre { Id = 2, Name = "Фэнтези" },
                new Genre { Id = 3, Name = "Детектив" },
                new Genre { Id = 4, Name = "Роман" },
                new Genre { Id = 5, Name = "Приключения" },
                new Genre { Id = 6, Name = "Ужасы и Мистика" },
                new Genre { Id = 7, Name = "Научно-популярная литература" },
                new Genre { Id = 8, Name = "Бизнес и психология" },
                new Genre { Id = 9, Name = "Исторический роман" },
                new Genre { Id = 10, Name = "Поэзия" }
            );
        }
    }
}
