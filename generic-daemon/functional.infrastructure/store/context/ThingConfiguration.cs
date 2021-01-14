using functional.infrastructure.store.dataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace functional.infrastructure.store.context
{
    public class ThingConfiguration : IEntityTypeConfiguration<Thing>
    {
        public void Configure(EntityTypeBuilder<Thing> builder)
        {
            builder.HasKey(thing => thing.Id);
            builder.Property(thing => thing.Name).HasMaxLength(255);
        }
    }
}