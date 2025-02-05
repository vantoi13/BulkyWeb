using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                 var tableName = entityType.GetTableName();
                 if (tableName!.StartsWith("AspNet"))
                 {
                     entityType.SetTableName(tableName.Substring(6));
                 }
            }
        }

        public DbSet<Category> Categorys { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
    }
}
