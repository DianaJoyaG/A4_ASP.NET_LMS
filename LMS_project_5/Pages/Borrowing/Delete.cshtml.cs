using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Threading.Tasks;

public class DeleteBorrowingModel : PageModel
{
    private readonly IBorrowingRepository _borrowingRepository;

    [BindProperty]
    public Borrowing Borrowing { get; set; }

    public DeleteBorrowingModel(IBorrowingRepository borrowingRepository)
    {
        _borrowingRepository = borrowingRepository;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Borrowing = await _borrowingRepository.GetBorrowingByIdAsync(id);

        if (Borrowing == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var borrowingToDelete = await _borrowingRepository.GetBorrowingByIdAsync(id);

        if (borrowingToDelete == null)
        {
            return NotFound();
        }

        await _borrowingRepository.DeleteBorrowingAsync(id);

        return RedirectToPage("./Index");
    }
}
