namespace Aps.net_Ef_Core_book_store.Models.DataModels
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Image> Images { get; set; }
    }
}
