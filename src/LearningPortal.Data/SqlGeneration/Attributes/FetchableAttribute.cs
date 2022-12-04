namespace LearningPortal.Data.SqlGeneration.Attributes
{
    internal class FetchableAttribute : SqlPropertyIdentiferAttribute
    {
        internal FetchableAttribute() { }

        internal FetchableAttribute(string specifiedDatabaseName) : base(specifiedDatabaseName) { }
    }
}
