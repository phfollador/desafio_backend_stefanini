using Example.Domain.CityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Example.Infra.Data.EntityConfiguration
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).HasColumnType("VARCHAR(200)");
            builder.Property(x => x.UF).HasColumnType("VARCHAR(2)").HasConversion(new EnumToStringConverter<UF>());
        }
    }
}
