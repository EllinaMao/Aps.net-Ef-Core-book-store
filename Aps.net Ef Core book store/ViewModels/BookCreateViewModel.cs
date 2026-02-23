using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aps.net_Ef_Core_book_store.ViewModels
{
    public class BookCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string? NewAuthorName { get; set; }

        public List<int> SelectedAuthorIds { get; set; } = new List<int>();
        public List<int> SelectedGenreIds { get; set; } = new List<int>();

        public IFormFileCollection? Uploads { get; set; }
        public IEnumerable<SelectListItem>? AvailableAuthors { get; set; }
        public IEnumerable<SelectListItem>? AvailableGenres { get; set; }
    }
}
