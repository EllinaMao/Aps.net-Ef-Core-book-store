using Aps.net_Ef_Core_book_store.Data;
using Aps.net_Ef_Core_book_store.Interface;
using Aps.net_Ef_Core_book_store.Models.DataModels;

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
            return _context.Book;
        }

        public void AddBook(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
        }


        public Book GetBook(int id)
        {
            return _context.Book.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateBook(Book book)
        {
            Book book2 = GetBook(book.Id);
            book2.Name = book.Name;
            book2.Authors = book.Authors;
            book2.Description = book.Description;
            book2.Genres = book.Genres;
            book2.Comments = book.Comments;
            book2.Images = book.Images;

            _context.SaveChanges();
        }
        //practice
        public void UpdateAll(Book[] books)
        {
            Dictionary<int, Book> data = books.ToDictionary(e => e.Id);
            IEnumerable<Book> baseline = _context.Book.Where(e => data.Keys.Contains(e.Id));

            foreach (Book book in baseline)
            {
                Book requestBook = data[book.Id];
                book.Name = requestBook.Name;
                book.Description = requestBook.Description;
                book.Genres = requestBook.Genres;
                book.Comments = requestBook.Comments;
                book.Images = requestBook.Images;
                book.Authors = requestBook.Authors;

            }
            _context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _context.Book.Remove(book);
            _context.SaveChanges();
        }
    }
}

