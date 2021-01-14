using functional.infrastructure.store.dataModels;
using Functional.Common.DataTypes;
using Microsoft.EntityFrameworkCore;

namespace functional.infrastructure.store.context
{
    public class GenericDbContext : DbContext
    {
        private readonly ConnectionString _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDbContext" /> class.
        /// </summary>
        public GenericDbContext(ConnectionString connectionString) =>
            _connectionString = connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDbContext" /> class.
        /// </summary>
        public GenericDbContext(DbContextOptions<GenericDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventStore>? EventStore { get; set; }

        public DbSet<Thing>? Things { get; set; }

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventStoreConfiguration());
            modelBuilder.ApplyConfiguration(new ThingConfiguration());
        }
    }
}