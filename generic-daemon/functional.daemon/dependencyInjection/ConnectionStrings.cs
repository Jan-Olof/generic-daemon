using Functional.Common.DataTypes;

namespace functional.daemon.dependencyInjection
{
    public class ConnectionStrings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionStrings"/> class.
        /// </summary>
        private ConnectionStrings(string storeConnection) =>
            StoreConnection = storeConnection;

        /// <summary>
        /// Connect to an event store.
        /// </summary>
        public ConnectionString StoreConnection { get; }

        public static ConnectionStrings Create(ConnectionString storeConnection) =>
            new(storeConnection);
    }
}