using Microsoft.EntityFrameworkCore;
using TechLibrary.API.Domain.Entities;

namespace TechLibrary.API.Infraestructure;
public class TechLibraryDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\PNETO\\source\\repos\\TechLibrary\\TechLibraryDb.db");
    }
}
