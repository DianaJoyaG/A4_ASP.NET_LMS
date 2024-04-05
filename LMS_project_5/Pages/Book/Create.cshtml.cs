using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Threading.Tasks;



public class CreateBookModel : PageModel
{
    private readonly IBookRepository _bookRepository;

    [BindProperty]
    public Book Book { get; set; }

    public CreateBookModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _bookRepository.AddBookAsync(Book);

        return RedirectToPage("./Index");
    }

}
