using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using LMS_project_5.Models;
using LMS_project_5.Interfaces;

public class IndexBorrowingModel : PageModel
{
    private readonly IBorrowingRepository _borrowingRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IReaderRepository _readerRepository;

    // Add properties to hold the lists of books and readers
    public IEnumerable<Borrowing> Borrowings { get; private set; }
    public IEnumerable<Book> Books { get; private set; }
    public IEnumerable<Reader> Readers { get; private set; }

    // Inject the additional repositories into the constructor
    public IndexBorrowingModel(IBorrowingRepository borrowingRepository, IBookRepository bookRepository, IReaderRepository readerRepository)
    {
        _borrowingRepository = borrowingRepository;
        _bookRepository = bookRepository;
        _readerRepository = readerRepository;
    }

    public async Task OnGetAsync()
    {
        Borrowings = await _borrowingRepository.GetAllBorrowingsAsync() ?? Enumerable.Empty<Borrowing>();
        Books = await _bookRepository.GetAllBooksAsync() ?? Enumerable.Empty<Book>();
        Readers = await _readerRepository.GetAllReadersAsync() ?? Enumerable.Empty<Reader>();
    }


}
