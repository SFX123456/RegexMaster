﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class UserContext :IdentityDbContext<User>
{
    public UserContext(DbContextOptions<UserContext> options)
                    :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("identity");
    }
}