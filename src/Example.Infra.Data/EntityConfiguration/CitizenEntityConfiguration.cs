using Example.Domain.CitizenAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Infra.Data.EntityConfiguration
{
    public class CitizenEntityConfiguration : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            builder.Property(x => x.Name).HasColumnType("VARCHAR(300)");
            builder
                .Property(x => x.Cpf);
            builder.HasOne(x => x.City).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
