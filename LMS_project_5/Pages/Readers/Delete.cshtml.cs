using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_5.Interfaces;
using LMS_project_5.Models;
using System.Threading.Tasks;


public class DeleteReaderModel : PageModel
{
    private readonly IReaderRepository _readerRepository;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public Reader Reader { get; set; }

    public DeleteReaderModel(IReaderRepository readerRepository)
    {
        _readerRepository = readerRepository;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Reader = await _readerRepository.GetReaderByIdAsync(id);

        if (Reader == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        await _readerRepository.DeleteReaderAsync(id);
                return RedirectToPage("./Index");
    }


}
