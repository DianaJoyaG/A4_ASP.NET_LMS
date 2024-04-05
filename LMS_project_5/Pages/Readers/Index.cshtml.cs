using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS_project_5.Interfaces;
using LMS_project_5.Models;


public class IndexReaderModel : PageModel
{
    private readonly IReaderRepository _readerRepository; 

    public IEnumerable<Reader> Readers { get; private set; }

    public IndexReaderModel(IReaderRepository readerRepository)
    {
        _readerRepository = readerRepository;
    }

    public async Task OnGetAsync()
    {
        Readers = await _readerRepository.GetAllReadersAsync();
    }
}
