using Aps.net_Ef_Core_book_store.Interface;
using Aps.net_Ef_Core_book_store.Models.DataModels;
using Aps.net_Ef_Core_book_store.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aps.net_Ef_Core_book_store.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook _bookRepository;
        private readonly IComment _commentRepository;
        private readonly IImage _imageService;

        public BookController(
            IBook bookRepository,
            IComment commentRepository,
            IImage imageService)
        {
            _bookRepository = bookRepository;
            _commentRepository = commentRepository;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBook(id);
            if (book == null) return NotFound();

            var viewModel = new BookDetailsViewModel
            {
                Id = book.Id,
                Title = book.Name,
                Description = book.Description,
                Price = book.Price,
                AuthorNames = book.Authors?.Select(a => a.Name).ToList() ?? new List<string>(),
                GenreNames = book.Genres?.Select(g => g.Name).ToList() ?? new List<string>(),
                ExistingComments = book.Comments?.ToList() ?? new List<Comments>(),
                ImageUrls = book.Images?.OrderByDescending(i => i.IsMain).Select(i => i.Url).ToList() ?? new List<string>()
            };


            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(BookDetailsViewModel model)
        {
            var comment = new Comments
            {
                BookId = model.Id,
                Comment = model.NewCommentText,
                Rating = model.NewCommentRating,
                UserId = new Guid("7F523A0A-43D7-4F7F-A86E-EB401CCB0362")
            };

            await _commentRepository.AddCommentAsync(comment);

            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> UploadImages(int bookId, IFormFileCollection uploads)
        {
            var book = _bookRepository.GetBook(bookId);
            if (book == null) return NotFound();

            await _imageService.UploadImagesAsync(bookId, book.Name, uploads);

            return RedirectToAction("Details", new { id = bookId });
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new BookCreateViewModel
            {
                AvailableAuthors = _bookRepository.GetAllAuthors()
                    .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }),
                AvailableGenres = _bookRepository.GetAllGenres()
                    .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authors = _bookRepository.GetAuthorsByIds(model.SelectedAuthorIds) ?? new List<Author>();
                var genres = _bookRepository.GetGenresByIds(model.SelectedGenreIds) ?? new List<Genre>();

                if (!string.IsNullOrWhiteSpace(model.NewAuthorName))
                {
                    var newAuthor = new Author { Name = model.NewAuthorName.Trim() };
                    authors.Add(newAuthor);
                }

                var book = new Book
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Authors = authors,
                    Genres = genres
                };
                _bookRepository.AddBook(book);

                if (model.Uploads != null && model.Uploads.Count > 0)
                {
                    await _imageService.UploadImagesAsync(book.Id, book.Name, model.Uploads);

                }
                return RedirectToAction("Index");

            }
            model.AvailableAuthors = _bookRepository.GetAllAuthors()
        .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name });
            model.AvailableGenres = _bookRepository.GetAllGenres()
                .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name });

            return View(model);
        }
    }
}