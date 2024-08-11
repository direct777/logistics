using Microsoft.EntityFrameworkCore;
using CompanyApi.Models; // Assuming your entity models are in a Models namespace

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
}
