using EcommerceBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>();
        modelBuilder.Entity<Product>();

        base.OnModelCreating(modelBuilder);
    }
}