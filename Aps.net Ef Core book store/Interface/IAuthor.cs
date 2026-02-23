using Aps.net_Ef_Core_book_store.Models.DataModels;

namespace Aps.net_Ef_Core_book_store.Interface
{
    public interface IAuthor
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
