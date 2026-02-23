using Aps.net_Ef_Core_book_store.Data;
using Aps.net_Ef_Core_book_store.Interface;
using Aps.net_Ef_Core_book_store.Models.DataModels;

namespace Aps.net_Ef_Core_book_store.Repository
{
    public class CommentRepository : IComment
    {
        private readonly ApplicationContext _context;

        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(Comments comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}