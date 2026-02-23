using Aps.net_Ef_Core_book_store.Models.DataModels;

namespace Aps.net_Ef_Core_book_store.Interface
{
    public interface IComment
    {
        Task AddCommentAsync(Comments comment);
    }
}