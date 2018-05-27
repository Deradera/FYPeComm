using FYPeComm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYPeComm.DAL
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public virtual DbSet<Colour> Colour { get; set; }
        public virtual DbSet<ProdCat> ProdCat { get; set; }
        public virtual DbSet<ProdSubCat> ProdSubCat { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public DbSet<ProdSizeColourLink> ProductSizeColourLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colour>(entity =>
            {
                entity.ToTable("COLOUR");

                entity.Property(e => e.ColourId).HasColumnName("colour_id");

                entity.Property(e => e.ColourName)
                    .IsRequired()
                    .HasColumnName("colour_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdCat>(entity =>
            {
                entity.ToTable("PROD_CAT");

                entity.Property(e => e.ProdCatId).HasColumnName("prod_cat_id");

                entity.Property(e => e.ProdCatName)
                    .IsRequired()
                    .HasColumnName("prod_cat_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdSubCat>(entity =>
            {
                entity.ToTable("PROD_SUB_CAT");

                entity.Property(e => e.ProdSubCatId).HasColumnName("prod_sub_cat_id");

                entity.Property(e => e.ProdParentCatId).HasColumnName("prod_parent_cat_id");

                entity.Property(e => e.ProdSubCatName)
                    .IsRequired()
                    .HasColumnName("prod_sub_cat_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProdParentCat)
                    .WithMany(p => p.ProdSubCat)
                    .HasForeignKey(d => d.ProdParentCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROD_SUB_CAT_PROD_CAT");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProdId)
                    .HasColumnName("prod_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProdDesc)
                    .IsRequired()
                    .HasColumnName("prod_desc")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdImg)
                    .IsRequired()
                    .HasColumnName("prod_img")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasColumnName("prod_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdPrice).HasColumnName("prod_price");

                entity.Property(e => e.SubCatId).HasColumnName("sub_cat_id");

                entity.Property(e => e.Stock).IsRequired().HasColumnName("stock_qty");

                entity.HasOne(d => d.SubCat)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.SubCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PROD_SUB_CAT");

            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("SIZE");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.SizeName)
                    .IsRequired()
                    .HasColumnName("size_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdSizeColourLink>(entity =>
            {
                entity.ToTable("PROD_SIZE_COLOUR_LINK");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColourId).HasColumnName("colour_id");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.HasOne(d => d.Colour)
                    .WithMany(p => p.ProdSizeColourLink)
                    .HasForeignKey(d => d.ColourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROD_SIZE_COLOUR_LINK_COLOUR");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.ProdSizeColourLink)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROD_SIZE_COLOUR_LINK_PRODUCT");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProdSizeColourLink)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROD_SIZE_COLOUR_LINK_SIZE");
            });
        }
    }
}
