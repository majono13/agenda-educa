using EducaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducaApi.Infra.Data.Maps
{
    public class SchoolMap : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasOne(s => s.Teacher)
                  .WithMany(t => t.Schools);

            builder.HasMany(sc => sc.Students)
                .WithOne(st => st.School)
                .HasForeignKey(st => st.SchoolId);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Cep).IsRequired().HasMaxLength(9);
            builder.Property(p => p.City).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Street).IsRequired().HasMaxLength(100);
            builder.Property(p => p.State).IsRequired().HasMaxLength(100);
            builder.Property(p => p.District).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Number).IsRequired().HasMaxLength(10);
        }
    }
}
