using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Threading.Tasks;

public class EditBorrowingModel : PageModel
{
    private readonly IBorrowingRepository _borrowingRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IReaderRepository _readerRepository;

    [BindProperty]
    public Borrowing Borrowing { get; set; }
    public SelectList Books { get; set; }
    public SelectList Readers { get; set; }

    public EditBorrowingModel(IBorrowingRepository borrowingRepository, IBookRepository bookRepository, IReaderRepository readerRepository)
    {
        _borrowingRepository = borrowingRepository;
        _bookRepository = bookRepository;
        _readerRepository = readerRepository;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Borrowing = await _borrowingRepository.GetBorrowingByIdAsync(id);

        if (Borrowing == null)
        {
            return NotFound();
        }

        Books = new SelectList(await _bookRepository.GetAllBooksAsync(), "IDBook", "Title", Borrowing.IDBook);
        Readers = new SelectList(await _readerRepository.GetAllReadersAsync(), "IDReader", "NameReader", Borrowing.IDReader);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Books = new SelectList(await _bookRepository.GetAllBooksAsync(), "IDBook", "Title", Borrowing.IDBook);
            Readers = new SelectList(await _readerRepository.GetAllReadersAsync(), "IDReader", "NameReader", Borrowing.IDReader);
            return Page();
        }

        var result = await _borrowingRepository.UpdateBorrowingAsync(Borrowing);
        if (result == null)
        {
            return NotFound();
        }

        return RedirectToPage("./Index");
    }
}
