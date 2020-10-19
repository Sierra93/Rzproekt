using Microsoft.EntityFrameworkCore;
using Rzproekt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rzproekt.Core.Data {
    public class ApplicationDbContext : DbContext {
        public DbSet<UserDto> Users { get; set; }   // Таблица пользователей.

        public DbSet<HeaderDto> Headers { get; set; }   // Таблица хидера.

        public DbSet<OrderDto> Orders { get; set; }     // Таблица услуг.

        public DbSet<AboutDto> Abouts { get; set; }     // Таблица о нас.

        public DbSet<StatisticDto> Statistic { get; set; }    // Таблица статистики.

        public DbSet<ProjectDto> Projects { get; set; }     // Таблица проектов.

        public DbSet<ClientDto> Clients { get; set; }     // Таблица клиентов.

        public DbSet<ContactCompanyDto> ContactsCompany { get; set; }     // Таблица контактов.

        public DbSet<ContactLead> ContactLeads { get; set; }    // Табилца контактов руководства.

        public DbSet<FooterDto> Footers { get; set; }   // Таблица футера.

        public DbSet<MessageDto> Messages { get; set; }     // Таблица сообщений.

        public DbSet<CertDto> Certs { get; set; }   // Таблица сертификатов.

        public DbSet<DetailProject> DetailProjects { get; set; }    // Таблица с дополнительными изображениями проектов.

        public DbSet<AwardDto> Awards { get; set; }    // Таблица наград.

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<MultepleContextTable>()
            .HasKey(t => new { t.UserId });

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Headers)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Orders)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Abouts)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Statistics)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Projects)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Clients)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Contacts)
                .WithMany(s => s.MultepleContextTables);

                modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Footers)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Messages)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Certs)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.DetailProjects)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Awards)
                .WithMany(s => s.MultepleContextTables);
        }
    }
}