﻿using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 

        }
        public DbSet<Driver> Drivers { get; set; }
    }
}
