namespace LearningPortal.Data.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class SqlClassIdentifierAttribute : Attribute
    {
        public string Table { get; set; }

        private readonly string? _where;

        public string Where => string.IsNullOrWhiteSpace(_where) ? string.Empty : "WHERE " + _where;

        public SqlClassIdentifierAttribute(string table)
        {
            Table = table;
        }

        public SqlClassIdentifierAttribute(string table, string where) : this(table)
        {
            _where = where;
        }
    }
}
