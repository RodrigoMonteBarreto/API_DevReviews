using System.Collections.Generic;
using Devreviews.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devreviews.API.Persistence
{
    public class DevReviewsDbContext : DbContext
    {

        public DevReviewsDbContext(DbContextOptions<DevReviewsDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("tb_Product");
                p.HasKey(p => p.Id);
                p.HasMany(x => x.Reviews).
                WithOne().
                HasForeignKey(r => r.ProductId).
                OnDelete(DeleteBehavior.Restrict);


            });

            modelBuilder.Entity<ProductReview>(pr =>
            {
                pr.ToTable("tb_ProductReviews");
                pr.HasKey(p => p.Id);
                pr.Property(p => p.Author)
                    .HasMaxLength(50)
                    .IsRequired();
                //.HasColumnName("author");

            });

            // modelBuilder.Entity<Product>()
            //     .ToTable("tb_Product");
            // modelBuilder.Entity<Product>()
            //     .HasKey(p => p.Id);

            // modelBuilder.Entity<ProductReview>()
            //     .ToTable("tb_ProductReviews");
            // modelBuilder.Entity<ProductReview>()
            //      .HasKey(p => p.Id);
        }



    }
}