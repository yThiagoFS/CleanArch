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
                .OwnsOne(c => c.Name)
                .Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(60)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder
                .HasData(
                    new Category(1, "School Materials")
                    , new Category(2, "Acessories")
                    , new Category(3, "Garden"));
        }
    }
}
