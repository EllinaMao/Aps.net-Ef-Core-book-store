using Aps.net_Ef_Core_book_store.Interface;
using Aps.net_Ef_Core_book_store.Models.DataModels;
using Aps.net_Ef_Core_book_store.Repository;
using Aps.net_Ef_Core_book_store.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Aps.net_Ef_Core_book_store.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthor _authorRepository;

        public AuthorController(IAuthor authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IActionResult Index()
        {
            var authors = _authorRepository.GetAllAuthors();
            return View(authors);
        }

        public IActionResult Details(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null) return NotFound();

            return View(author);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepository.AddAuthor(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null) return NotFound();

            return View(author);
        }

        public IActionResult Edit(Author author)
        {
            ModelState.Remove("Books");

            if (ModelState.IsValid)
            {
                _authorRepository.UpdateAuthor(author);
                return RedirectToAction("Index");
            }

            return View(author);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author != null)
            {
                _authorRepository.DeleteAuthor(author);
            }
            return RedirectToAction("Index");
        }
    }
}