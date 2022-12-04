namespace LearningPortal.Data.SqlGeneration.Attributes
{
    internal class FetchableDTO : SqlClassIdentifierAttribute
    {
        #region Constructors

        public FetchableDTO(string table) : base(table) { }

        public FetchableDTO(string table, string where) : base(table, where) { }

        public FetchableDTO(string table, string join, string where = "") : this(table, where)
        {
            Joins = join;
        }

        public FetchableDTO(string table, string join = "", string where = "", string orderBy = "") : this(table, join, where)
        {
            _orderBy = orderBy;
        }

        #endregion

        public string Joins = string.Empty;

        public string? Top { get; set; }

        private readonly string? _orderBy;
        
        public string OrderBy => string.IsNullOrWhiteSpace(_orderBy) ? string.Empty : "ORDER BY " + _orderBy;
    }
}
