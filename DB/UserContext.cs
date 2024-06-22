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
}