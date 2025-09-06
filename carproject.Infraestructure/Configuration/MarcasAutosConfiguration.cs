using carproject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace carproject.Infraestructure.Configuration
{
    public class MarcasAutosConfiguration : IEntityTypeConfiguration<MarcasAutos>
    {
        public void Configure(EntityTypeBuilder<MarcasAutos> builder)
        {
            builder.ToTable("MarcasAutos"); 

            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .ValueGeneratedOnAdd();

            builder.Property(v => v.Brand)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Year)
                .IsRequired();

            builder.Property(v => v.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
