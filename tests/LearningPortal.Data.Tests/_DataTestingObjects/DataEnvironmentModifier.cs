using LearningPortal.Data.Abstractions.BaseRequestObjects;

namespace LearningPortal.Data.Tests._DataTestingObjects
{
    internal abstract class DataEnvironmentModifier
    {
        protected readonly DataConnection _data;

        public DataEnvironmentModifier(DataConnection data) => _data = data;

        /// <summary>
        /// InlineSqlRequest used for Inline SQL to modify database to prepare for tests
        /// </summary>
        protected class InlineSqlRequest : ParameterlessRequest
        {
            public InlineSqlRequest(string sql) => _sql = sql;

            private readonly string _sql;

            public override string GenerateSql() => _sql;
        }
    }
}
