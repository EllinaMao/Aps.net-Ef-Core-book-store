using System.ComponentModel.DataAnnotations;

namespace Aps.net_Ef_Core_book_store.Models.DataModels
{
    public class User
    {
        [Key]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Comments> Comments { get; set; }
    }
}
