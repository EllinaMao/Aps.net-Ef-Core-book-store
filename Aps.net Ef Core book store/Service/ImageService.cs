using Aps.net_Ef_Core_book_store.Data;
using Aps.net_Ef_Core_book_store.Interface;
using Aps.net_Ef_Core_book_store.Models.DataModels;

namespace Aps.net_Ef_Core_book_store.Service
{
    public class ImageService : IImage
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public ImageService(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public async Task UploadImagesAsync(int bookId, string bookName, IFormFileCollection uploads)
        {
            string folderPath = Path.Combine(_appEnvironment.WebRootPath, "images", bookName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            bool isFirstImage = true;

            foreach (var uploadedFile in uploads)
            {
                if (uploadedFile != null)
                {
                    string filePath = Path.Combine(folderPath, uploadedFile.FileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }

                    Image img = new Image
                    {
                        Name = uploadedFile.FileName,
                        Url = $"/images/{bookName}/{uploadedFile.FileName}",
                        BookId = bookId,
                        IsMain = isFirstImage
                    };

                    isFirstImage = false;
                    _context.Image.Add(img);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
