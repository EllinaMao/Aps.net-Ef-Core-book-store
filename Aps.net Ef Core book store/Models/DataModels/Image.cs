using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aps.net_Ef_Core_book_store.Models.DataModels
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string? AltText { get; set; }
        [Required]
        public string Url { get; set; }


        public bool IsMain { get; set; }  = false;

        [ForeignKey(nameof(BookId))]
        public Guid BookId { get; set; }
        public Book ImageBook { get; set; }


    }
}

/*
 in wwwrott create a folder with BookName and there upload image*/