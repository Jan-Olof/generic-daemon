using Functional.Infrastructure.Store.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Functional.Infrastructure.Store.Context
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