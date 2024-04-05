using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Threading.Tasks;


public class DeleteBookModel : PageModel
{
    private readonly IBookRepository _bookRepository;

    public Book Book { get; private set; }

    public DeleteBookModel(IBookRepository bookRepository)
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


    public async Task<IActionResult> OnPostAsync(int id)
    {
        await _bookRepository.DeleteBookAsync(id);
     
        return RedirectToPage("./Index");
    }
}
