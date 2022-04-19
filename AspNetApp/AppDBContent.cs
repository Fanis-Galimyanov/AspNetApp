﻿#nullable disable
using AspNetApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AspNetApp
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        { }
        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
    }

}
