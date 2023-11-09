using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .OwnsOne(c => c.Name)
                .Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(60)
                .HasColumnType("VARCHAR")
                .IsRequired();
        }
    }
}
