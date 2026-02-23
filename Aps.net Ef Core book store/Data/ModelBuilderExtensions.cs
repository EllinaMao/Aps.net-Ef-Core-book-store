using Aps.net_Ef_Core_book_store.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Aps.net_Ef_Core_book_store.Data
{
    public static class ModelBuilderExtensions
    {
        extension(ModelBuilder modelBuilder)
        {
            public void Seed()
            {
                modelBuilder.Entity<Genre>().HasData(
                    new Genre { Id = 1, Name = "Фантастика" },
                    new Genre { Id = 2, Name = "Фэнтези" },
                    new Genre { Id = 3, Name = "Детектив" },
                    new Genre { Id = 4, Name = "Роман" },
                    new Genre { Id = 5, Name = "Приключения" },
                    new Genre { Id = 6, Name = "Ужасы и Мистика" }
                );

                modelBuilder.Entity<Author>().HasData(
                    new Author { Id = 1, Name = "Айзек Азимов", Bio = "Американский писатель-фантаст." },
                    new Author { Id = 2, Name = "Стивен Кинг", Bio = "Американский писатель." },
                    new Author { Id = 3, Name = "Агата Кристи", Bio = "Английская писательница." }
                );

                modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, Name = "Основание", Description = "Сага о распаде Империи.", Price = 550.00m },
                    new Book { Id = 2, Name = "Сияние", Description = "Роман о писателе в отеле.", Price = 450.00m },
                    new Book { Id = 3, Name = "Убийство в Восточном экспрессе", Description = "Детектив Эркюля Пуаро.", Price = 350.00m }
                );

                modelBuilder.Entity("AuthorBook").HasData(
                    new { AuthorsId = 1, BooksId = 1 },
                    new { AuthorsId = 2, BooksId = 2 },
                    new { AuthorsId = 3, BooksId = 3 }
                );

                modelBuilder.Entity("BookGenre").HasData(
                    new { GenresId = 1, BooksId = 1 },
                    new { GenresId = 6, BooksId = 2 },
                    new { GenresId = 3, BooksId = 3 }
                );

                modelBuilder.Entity<User>().HasData(
                    new User { Id = new Guid("7F523A0A-43D7-4F7F-A86E-EB401CCB0362"), Name = "Тестовый Читатель" }
                );

                modelBuilder.Entity<Comments>().HasData(
                    new Comments { Id = 1, BookId = 1, UserId = new Guid("7F523A0A-43D7-4F7F-A86E-EB401CCB0362"), Rating = 5, Comment = "Классика жанра!" },
                    new Comments { Id = 2, BookId = 2, UserId = new Guid("7F523A0A-43D7-4F7F-A86E-EB401CCB0362"), Rating = 4, Comment = "Очень страшно." }
                );
            }
        }
    }
}
