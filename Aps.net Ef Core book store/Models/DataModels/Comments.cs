using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aps.net_Ef_Core_book_store.Models.DataModels
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        [Range(0, 5)]
        public sbyte Rating { get; set; } = 0;
        public string Comment { get; set; }
        [ForeignKey(nameof(UserId))]
        public Guid? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
