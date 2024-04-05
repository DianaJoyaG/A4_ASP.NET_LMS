using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_5.Interfaces; 
using LMS_project_5.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

public class IndexBookModel : PageModel
{
    private readonly IBookRepository _bookRepository;
    public IEnumerable<Book> Books { get; private set; }

    public IndexBookModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task OnGetAsync()
    {
        Books = await _bookRepository.GetAllBooksAsync();
    }
}
