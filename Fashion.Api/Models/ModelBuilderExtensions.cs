using Fashion.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Api.Data
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyConfigurations(this ModelBuilder modelBuilder)
        {
            // Configure ReadyToWear
            modelBuilder.Entity<ReadyToWear>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired().HasMaxLength(100);
                entity.Property(r => r.Price).HasColumnType("decimal(18,2)");
            });

            // Configure Bespoke
            modelBuilder.Entity<Bespoke>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Price).IsRequired().HasMaxLength(200);
                entity.Property(b => b.Price).HasColumnType("decimal(18,2)");
            });

            // Configure Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.FullName).IsRequired().HasMaxLength(150);
                entity.Property(c => c.Email).IsRequired().HasMaxLength(150);
                entity.Property(c => c.PhoneNumber).HasMaxLength(15);
            });

            // Configure Accessories
            modelBuilder.Entity<Accessories>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Price).HasColumnType("decimal(18,2)");
            });
        }
    }
}