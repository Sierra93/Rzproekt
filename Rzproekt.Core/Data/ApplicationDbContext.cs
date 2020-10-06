using Microsoft.EntityFrameworkCore;
using Rzproekt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rzproekt.Core.Data {
    public class ApplicationDbContext : DbContext {
        public DbSet<UserDto> Users { get; set; }   // Таблица пользователей.

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //modelBuilder.Entity<MultepleContextTable>()
            //.HasKey(t => new { t.UserId });

            //modelBuilder.Entity<MultepleContextTable>()
            //    .HasOne(sc => sc.User)
            //    .WithMany(s => s.MultepleContextTables);           
        }
    }
}
