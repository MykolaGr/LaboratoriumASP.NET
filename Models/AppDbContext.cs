using Microsoft.EntityFrameworkCore;

namespace Laboratorium1.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts {
        get;
        set;
    }

    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: $"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1, 
                FirstName = "Adam", 
                LastName = "Johnson",
                Email = "st@wsei.edu.pl",
                PhoneNumber = "123 432 543",
                BirthDate = new DateOnly(2001, 11, 10)
            },
            new ContactEntity()
            {
                Id = 2, 
                FirstName = "John", 
                LastName = "Johnson",
                Email = "abc@wsei.edu.pl",
                PhoneNumber = "464 987 543",
                BirthDate = new DateOnly(1999, 01, 17)
            }
        );
    }
}