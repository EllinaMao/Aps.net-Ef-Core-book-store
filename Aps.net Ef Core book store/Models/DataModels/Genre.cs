using System.ComponentModel.DataAnnotations;

namespace Aps.net_Ef_Core_book_store.Models.DataModels
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
