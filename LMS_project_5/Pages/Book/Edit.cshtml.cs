using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Threading.Tasks;


public class EditBookModel : PageModel
{
    private readonly IBookRepository _bookRepository;

    [BindProperty]
    public Book Book { get; set; }

    public EditBookModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Book = await _bookRepository.GetBookByIdAsync(id);

        if (Book == null)
        {

            return NotFound();
        }

        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            
            return Page();
        }

        
        var existingBook = await _bookRepository.GetBookByIdAsync(Book.IDBook);
        if (existingBook == null)
        {
            return NotFound();
        }


        var updatedBook = await _bookRepository.UpdateBookAsync(Book);
        if (updatedBook == null)
        {

            return NotFound();
        }


        return RedirectToPage("./Index");
    }


}

