using Microsoft.EntityFrameworkCore;
using StronaAzure.Models;

namespace StronaAzure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients => Set<Client>();
}
