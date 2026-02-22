using Aps.net_Ef_Core_book_store.Models.DataModels;

namespace Aps.net_Ef_Core_book_store.Interface
{
    public interface IBook
    {
        IEnumerable<Book> GetAllBooks();
        void AddBook(Book book);

        Book GetBook(int id);
        void UpdateBook(Book book);
        void DeleteBook(Book book);


    }
}
