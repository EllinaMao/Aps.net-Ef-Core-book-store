using Aps.net_Ef_Core_book_store.Models.DataModels;

namespace Aps.net_Ef_Core_book_store.Models.RelationshipModels
{
    public class BookGenre
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BookId { get; set; }
        public Guid GenreId { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
