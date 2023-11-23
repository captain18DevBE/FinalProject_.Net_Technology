﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MusicWeb.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        
        }
        public DbSet<Songs> Songs { get; set; }
    }
}
