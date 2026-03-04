using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StronaAzure.Data;
using StronaAzure.Models;

namespace StronaAzure.Pages.Clients;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Client> Clients { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Clients = await _context.Clients
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .ToListAsync();
    }
}
