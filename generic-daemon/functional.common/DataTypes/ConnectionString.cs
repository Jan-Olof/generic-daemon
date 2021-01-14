namespace Functional.Common.DataTypes
{
    /// <summary>
    /// A connection string to a data store.
    /// </summary>
    public readonly struct ConnectionString
    {
        private ConnectionString(string value) =>
            Value = value;

        private string Value { get; }

        public static implicit operator ConnectionString(string s) =>
            new(s);

        public static implicit operator string(ConnectionString c) =>
            c.Value;

        public static bool operator !=(ConnectionString left, ConnectionString right) =>
            !(left == right);

        public static bool operator ==(ConnectionString left, ConnectionString right) =>
            left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is ConnectionString cs && this == cs;

        public override int GetHashCode() =>
            Value.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() =>
            Value;
    }
}