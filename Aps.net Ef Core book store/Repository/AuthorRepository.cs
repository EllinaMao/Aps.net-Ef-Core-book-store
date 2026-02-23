using Aps.net_Ef_Core_book_store.Data;
using Aps.net_Ef_Core_book_store.Interface;
using Aps.net_Ef_Core_book_store.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Aps.net_Ef_Core_book_store.Repository
{
    public class AuthorRepository : IAuthor
    {
        private readonly ApplicationContext _context;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Author.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _context.Author
                .Include(a => a.Books)
                .FirstOrDefault(a => a.Id == id);
        }

        public void AddAuthor(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Author.Update(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(Author author)
        {
            _context.Author.Remove(author);
            _context.SaveChanges();
        }
    }
}
