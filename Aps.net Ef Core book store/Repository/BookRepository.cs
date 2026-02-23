using Aps.net_Ef_Core_book_store.Data;
using Aps.net_Ef_Core_book_store.Interface;
using Aps.net_Ef_Core_book_store.Models.DataModels;
using Microsoft.EntityFrameworkCore; 

namespace Aps.net_Ef_Core_book_store.Repository
{
    public class BookRepository : IBook
    {
        private ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Book
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Include(b => b.Images)
                .ToList();
        }

        public Book GetBook(int id)
        {
            return _context.Book
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Include(b => b.Images)
                .Include(b => b.Comments)
                .FirstOrDefault(e => e.Id == id);
        }


        public void AddBook(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            Book book2 = GetBook(book.Id);
            book2.Name = book.Name;
            book2.Price = book.Price;
            book2.Description = book.Description;
            book2.Authors = book.Authors;
            book2.Genres = book.Genres;
            book2.Images = book.Images;
            book2.Comments = book.Comments;
            


            _context.SaveChanges();

        }

        public void UpdateAll(Book[] books)
        {
            Dictionary<int, Book> data = books.ToDictionary(e => e.Id);
            IEnumerable<Book> baseline = _context.Book.Where(e => data.Keys.Contains(e.Id));
            foreach (Book book in baseline)
            {
                Book book2 = data[book.Id];
                book2.Name = book.Name;
                book2.Price = book.Price;
                book2.Description = book.Description;
                book2.Authors = book.Authors;
                book2.Genres = book.Genres;
                book2.Images = book.Images;
                book2.Comments = book.Comments;

            }
            _context.SaveChanges();
        }


        public void DeleteBook(Book product)
        {
            _context.Book.Remove(product);
            _context.SaveChanges();
        }


        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Author.ToList();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genre.ToList();
        }

        public List<Author> GetAuthorsByIds(List<int> authorIds)
        {
            return _context.Author.Where(a => authorIds.Contains(a.Id)).ToList();
        }

        public List<Genre> GetGenresByIds(List<int> genreIds)
        {
            return _context.Genre.Where(g => genreIds.Contains(g.Id)).ToList();
        }
    }
}