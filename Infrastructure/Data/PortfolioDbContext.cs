using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }
      
        public DbSet<Ticket> Tickets { get; set; }
       
        public DbSet<TicketComment> TicketComments { get; set; }

        public DbSet<TicketActivity> TicketActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TicketComment>()
                .HasOne(c => c.Ticket)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TicketComment>()
                .Property(c => c.AuthorName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<TicketComment>()
                .Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(2000);

            modelBuilder.Entity<TicketActivity>()
                .HasOne(a => a.Ticket)
                .WithMany(t => t.Activities)
                .HasForeignKey(a => a.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TicketActivity>()
                .Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
