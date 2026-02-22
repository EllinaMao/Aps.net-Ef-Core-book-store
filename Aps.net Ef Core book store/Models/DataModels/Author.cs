using System.ComponentModel.DataAnnotations;

namespace Aps.net_Ef_Core_book_store.Models.DataModels
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [StringLength(400)]
        public string? Bio { get; set; }

        
        
    }
}
