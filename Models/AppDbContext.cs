using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium1.Models;

public class AppDbContext: IdentityDbContext<IdentityUser>
{
    public DbSet<ContactEntity> Contacts {
        get;
        set;
    }

    public DbSet<OrganizationEntity> Organization { get; set; }
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
        base.OnModelCreating(modelBuilder);
        
        string  ADMIN_ID = Guid.NewGuid().ToString();
        string USER_ID = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole()
                {
                    Id = ADMIN_ID,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = ADMIN_ID
                },
                new IdentityRole()
                {
                    Id = USER_ID,
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = USER_ID
                }
            );
        var admin = new IdentityUser()
        {
            Id = ADMIN_ID,
            UserName = "Adam",
            NormalizedUserName = "Adam",
            Email = "adam@wsei.edu.pl",
            NormalizedEmail = "ADAM@WSEI.EDU.PL",
            EmailConfirmed = true
        };
        var user = new IdentityUser()
        {
            Id = USER_ID,
            UserName = "John",
            NormalizedUserName = "JOHN",
            Email = "john@wsei.edu.pl",
            NormalizedEmail = "JOHN@WSEI.EDU.PL",
            EmailConfirmed = true
        };
        
        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = hasher.HashPassword(admin, "1234");
        user.PasswordHash = hasher.HashPassword(user, "abcd");

        modelBuilder.Entity<IdentityUser>()
            .HasData(admin, user);

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = ADMIN_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>()
                {
                    RoleId = USER_ID,
                    UserId = USER_ID
                }
            );
           
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new { OrganizationEntityId = 1, City = "Kraków", Street = "św. Filipa 17"},
                new { OrganizationEntityId = 2, City = "Warszawa", Street = "Wesoła 15"}
            );

        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c => c.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(o => o.OrganizationId);

        modelBuilder.Entity<OrganizationEntity>()
            .HasData(
                new OrganizationEntity()
                {
                    Id = 1,
                    Regon = "789456123",
                    Nip = "178945623",
                    Name = "WSEI"
                    
                        
                },
                new OrganizationEntity()
                {
                    Id = 2,
                    Regon = "789456123",
                    Nip = "178945623",
                    Name = "Famo"
                }
            );
        
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1, 
                FirstName = "Adam", 
                LastName = "Johnson",
                Email = "st@wsei.edu.pl",
                PhoneNumber = "123 432 543",
                BirthDate = new DateOnly(2001, 11, 10),
                OrganizationId = 1
            },
            new ContactEntity()
            {
                Id = 2, 
                FirstName = "John", 
                LastName = "Johnson",
                Email = "abc@wsei.edu.pl",
                PhoneNumber = "464 987 543",
                BirthDate = new DateOnly(1999, 01, 17),
                OrganizationId = 2
            }
        );
    }
}