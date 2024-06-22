using Microsoft.EntityFrameworkCore;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class UserContext :DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
                    : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for the User table
        modelBuilder.Entity<User>().HasData(
                        new User { Id = 1, Email = "user1@example.com", SignUpDate = DateTime.Now, Password = "password1" },
                        new User { Id = 2, Email = "user2@example.com", SignUpDate = DateTime.Now, Password = "password2" }
                        // Add more users as needed
        );
        
    }
    
}