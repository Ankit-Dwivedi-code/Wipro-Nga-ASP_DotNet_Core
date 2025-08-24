using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Day30_BookStoreApp.Models;

namespace Day30_BookStoreApp.Pages.Books
{
    public class DeleteBookModel : PageModel
    {
        [BindProperty]
        public Book BookToDelete { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = BookRepository.GetById(id);
            if (book == null)
            {
                return RedirectToPage("/Books/BookList");
            }

            BookToDelete = book;
            return Page();
        }

        public IActionResult OnPost()
        {
            BookRepository.Delete(BookToDelete.Id);
            return RedirectToPage("/Books/BookList");
        }
    }
}
