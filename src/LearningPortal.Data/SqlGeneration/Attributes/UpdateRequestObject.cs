namespace LearningPortal.Data.SqlGeneration.Attributes
{
    internal class UpdateRequestObject : SqlClassIdentifierAttribute
    {
        public UpdateRequestObject(string table, string where) : base(table, where) { }
    }
}