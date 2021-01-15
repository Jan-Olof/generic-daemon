using Functional.Infrastructure.Store.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Functional.Infrastructure.Store.Context
{
    public class EventStoreConfiguration : IEntityTypeConfiguration<EventStore>
    {
        public void Configure(EntityTypeBuilder<EventStore> builder)
        {
            builder.HasKey(eventStore => eventStore.Id);

            builder.HasIndex(eventStore => eventStore.Timestamp);
            builder.HasIndex(eventStore => eventStore.MessageType);
            builder.HasIndex(eventStore => eventStore.EntityId);
        }
    }
}