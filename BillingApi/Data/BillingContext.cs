using BillingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingApi.Data;

public class BillingContext(DbContextOptions<BillingContext> options) : DbContext(options)
{
    // Define the Sets of the Database (each of set represent a table of the database)
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    
    // This method that execute when EF build the model for the database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Define the name of the database
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<User>().ToTable("Users");
    }
}