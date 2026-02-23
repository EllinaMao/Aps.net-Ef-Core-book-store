using Aps.net_Ef_Core_book_store.Models.DataModels;
using System.ComponentModel.DataAnnotations;

namespace Aps.net_Ef_Core_book_store.ViewModels
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> AuthorNames { get; set; }
        public List<string> GenreNames { get; set; }
        public List<string> ImageUrls { get; set; }

        public List<Comments> ExistingComments { get; set; }

        public string NewCommentText { get; set; }
        public sbyte NewCommentRating { get; set; }
    }
}
