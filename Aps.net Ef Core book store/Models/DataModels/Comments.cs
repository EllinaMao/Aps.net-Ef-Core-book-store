namespace Aps.net_Ef_Core_book_store.Models.DataModels
{
    public class Comments
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; }
        public sbyte Rating { get; set; }
        public string Comment { get; set; }

    }
}
