using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .OwnsOne(p => p.Name)
                .Property(n => n.Value)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasColumnName("Description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasColumnName("Price")
                .HasColumnType("DECIMAL")
                .HasPrecision(10, 2)
                .IsRequired();

            builder
                .Property(p => p.Stock)
                .HasColumnName("Stock")
                .HasColumnType("INT")
                .IsRequired();

            builder
                .Property(p => p.Image)
                .HasColumnName("Image")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2000)
                .IsRequired();

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
