using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Day30_BookStoreApp.Models;

namespace Day30_BookStoreApp.Pages.Books
{
    public class EditBookModel : PageModel
    {
        [BindProperty]
        public Book EditBook { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = BookRepository.GetById(id);
            if (book == null)
            {
                return RedirectToPage("/Books/BookList");
            }

            EditBook = book;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            BookRepository.Update(EditBook);
            return RedirectToPage("/Books/BookList");
        }
    }
}
