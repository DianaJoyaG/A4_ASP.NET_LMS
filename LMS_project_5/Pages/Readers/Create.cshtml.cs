using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_5.Interfaces;
using LMS_project_5.Models;
using System.Threading.Tasks;
using LMS_project_5.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class CreateReaderModel : PageModel
{
    private readonly IReaderRepository _readerRepository;

    [BindProperty]
    public Reader Reader { get; set; }

    public CreateReaderModel(IReaderRepository readerRepository)
    {
        _readerRepository = readerRepository;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _readerRepository.AddReaderAsync(Reader);
        
        return RedirectToPage("./Index");
    }

}
