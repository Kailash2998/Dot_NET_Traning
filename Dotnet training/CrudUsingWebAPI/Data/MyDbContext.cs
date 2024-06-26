﻿using CrudUsingWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingWebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }

}
