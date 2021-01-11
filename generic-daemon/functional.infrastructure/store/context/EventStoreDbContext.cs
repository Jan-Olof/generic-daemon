using functional.common.entities;
using functional.common.valueObjects;
using Microsoft.EntityFrameworkCore;

namespace functional.infrastructure.store.context
{
    public class EventStoreDbContext : DbContext
    {
        private readonly ConnectionString _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStoreDbContext" /> class.
        /// </summary>
        public EventStoreDbContext(ConnectionString connectionString) =>
            _connectionString = connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStoreDbContext" /> class.
        /// </summary>
        public EventStoreDbContext(DbContextOptions<EventStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventStore>? EventStore { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(new EventStoreConfiguration());
    }
}