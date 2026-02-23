namespace Aps.net_Ef_Core_book_store.Interface
{
    public interface IImage
    {
        Task UploadImagesAsync(int bookId, string bookName, IFormFileCollection uploads);
    }
}