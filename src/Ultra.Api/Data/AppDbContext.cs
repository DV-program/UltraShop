namespace Ultra.Api.Data;
using Ultra.Api.Models;
using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public DbSet<Product> Products {get; set;}
    public DbSet<Category> Categories {get; set;}
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("Category");
    }
}
