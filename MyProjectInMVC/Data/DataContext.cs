﻿using Microsoft.EntityFrameworkCore;
using MyProjectInMVC.Controllers;
using MyProjectInMVC.Data.Map;
using MyProjectInMVC.Models;

namespace MyProjectInMVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserCategoryModel> UserCategory { get; set; }
        public DbSet<HomeworkModel> Homeworks { get; set; }
        public DbSet<HomeworkUserModel> HomeworkUserModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.ApplyConfiguration(new HomeworkMap());
            modelBuilder.Entity<CategoryModel>()
                .HasIndex(c => c.Slug)
                .IsUnique();
            
            base.OnModelCreating(modelBuilder);
		}
    }
}
