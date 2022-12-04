namespace LearningPortal.Data.SqlGeneration.Attributes
{
    internal class InsertRequestObject : SqlClassIdentifierAttribute
    {

        #region Constructors 

        public InsertRequestObject(string table) : base(table)
        {
        }

        public InsertRequestObject(string table, string from, string where) : base(table, where)
        {
            From = from;
        }


        public InsertRequestObject(string table, string ifNotExists) : base(table)
        {
            IfNotExists = ifNotExists;
        }

        #endregion

        public string IfNotExists { get; set; } = string.Empty;

        public bool IsInsertSelectRequest => !string.IsNullOrWhiteSpace(From);

        public string From { get; set; } = string.Empty;

        public string Join { get; set; } = string.Empty;

        public string GetValuesToInsert(string values) => IsInsertSelectRequest ? $"SELECT {values} FROM {From} {Join} {Where} " : $"VALUES ( {values} )";
    }
}
