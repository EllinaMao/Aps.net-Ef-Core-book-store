using System.ComponentModel.DataAnnotations;

namespace Aps.net_Ef_Core_book_store.Models.DataModels
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
