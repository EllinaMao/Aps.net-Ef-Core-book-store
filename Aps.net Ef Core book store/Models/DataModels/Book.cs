namespace Aps.net_Ef_Core_book_store.Models.DataModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
