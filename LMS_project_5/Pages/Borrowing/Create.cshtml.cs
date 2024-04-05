using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Threading.Tasks;

public class CreateBorrowingModel : PageModel
{
    private readonly IBorrowingRepository _borrowingRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IReaderRepository _readerRepository;

    public SelectList Books { get; set; }
    public SelectList Readers { get; set; }

    [BindProperty]
    public Borrowing Borrowing { get; set; }

    public CreateBorrowingModel(
        IBorrowingRepository borrowingRepository,
        IBookRepository bookRepository,
        IReaderRepository readerRepository)
    {
        _borrowingRepository = borrowingRepository;
        _bookRepository = bookRepository;
        _readerRepository = readerRepository;
    }

    public async Task OnGetAsync()
    {
        Books = new SelectList(await _bookRepository.GetAllBooksAsync(), "IDBook", "Title");
        Readers = new SelectList(await _readerRepository.GetAllReadersAsync(), "IDReader", "NameReader");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Reload the dropdown lists if the model is not valid
            Books = new SelectList(await _bookRepository.GetAllBooksAsync(), "IDBook", "Title");
            Readers = new SelectList(await _readerRepository.GetAllReadersAsync(), "IDReader", "NameReader");
            return Page();
        }

        // Add the new borrowing to the repository
        await _borrowingRepository.AddBorrowingAsync(Borrowing);

        // Store a success message in TempData that will be read in the redirected action
        TempData["SuccessMessage"] = "Book created successfully.";

        // Redirect to the Index page after creation
        return RedirectToPage("./Index");
    }
}
