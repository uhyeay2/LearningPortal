namespace LearningPortal.Data.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal abstract class SqlPropertyIdentiferAttribute : Attribute
    {
        internal SqlPropertyIdentiferAttribute() { }

        protected SqlPropertyIdentiferAttribute(string specifiedDatabaseName)
        {
            SpecifiedDatabaseName = specifiedDatabaseName;
        }

        /// <summary>
        /// SpecifiedColumnName is be to used when getting DTOProperties for Sql Procedures. If SpecifiedColumnName is left null then the PropertyName will be used.
        /// </summary>
        public string? SpecifiedDatabaseName { get; set; } = null;

        public string SpecifiedDatabaseNameOr(string otherName) => string.IsNullOrWhiteSpace(SpecifiedDatabaseName) ? otherName : SpecifiedDatabaseName;
    }
}
