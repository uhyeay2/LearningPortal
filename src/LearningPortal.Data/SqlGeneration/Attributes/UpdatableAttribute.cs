namespace LearningPortal.Data.SqlGeneration.Attributes
{
    internal class UpdatableAttribute : SqlPropertyIdentiferAttribute
    {
        public UpdatableAttribute() { }

        public UpdatableAttribute(string specifiedDatabaseName) : base(specifiedDatabaseName) { }

        public UpdatableAttribute(bool isCoalesceUpdate)
        {
            IsCoalesceUpdate = isCoalesceUpdate;
        }

        public UpdatableAttribute(bool isCoalesceUpdate, string specifiedDatabaseName) : base(specifiedDatabaseName)
        {
            IsCoalesceUpdate = isCoalesceUpdate;
        }
        
        public bool IsCoalesceUpdate { get; set; }
    }
}
