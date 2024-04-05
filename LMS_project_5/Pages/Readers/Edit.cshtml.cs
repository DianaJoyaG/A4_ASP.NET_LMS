using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_5.Interfaces;
using LMS_project_5.Models;
using System.Threading.Tasks;


public class EditReaderModel : PageModel
{
    private readonly IReaderRepository _readerRepository; 

    [BindProperty]
    public Reader Reader { get; set; }

    public EditReaderModel(IReaderRepository readerRepository)
    {
        _readerRepository = readerRepository;
    }

    public async Task <IActionResult> OnGetAsyn(int id)
    {
        Reader = await _readerRepository.GetReaderByIdAsync(id);

        if (Reader == null)
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

        var existingreader = await _readerRepository.GetReaderByIdAsync(Reader.IDReader);

        if (existingreader == null)
        {
            return NotFound();
        }


        var readerToUpdate = await _readerRepository.UpdateReaderAsync(Reader);
        if (readerToUpdate == null)
        {  return NotFound(); }


        return RedirectToPage("./Index");
    }
}
