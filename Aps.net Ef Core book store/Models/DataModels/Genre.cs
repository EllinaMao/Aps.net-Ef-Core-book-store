namespace Aps.net_Ef_Core_book_store.Models.DataModels
{
    public class Genre
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
