using System.ComponentModel.DataAnnotations;
using Aps.net_Ef_Core_book_store.Models.DataModels;

namespace Aps.net_Ef_Core_book_store.Models.RelationshipModels
{
    public class BookAuthor
    {
        [Key]
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
