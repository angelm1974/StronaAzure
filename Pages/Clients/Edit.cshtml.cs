using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StronaAzure.Data;
using StronaAzure.Models;

namespace StronaAzure.Pages.Clients;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Client Client { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var client = await _context.Clients.FindAsync(id.Value);
        if (client is null)
        {
            return NotFound();
        }

        Client = client;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var clientToUpdate = await _context.Clients.FindAsync(Client.Id);
        if (clientToUpdate is null)
        {
            return NotFound();
        }

        clientToUpdate.FirstName = Client.FirstName;
        clientToUpdate.LastName = Client.LastName;
        clientToUpdate.Age = Client.Age;

        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
