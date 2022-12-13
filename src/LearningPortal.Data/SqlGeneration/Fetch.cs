namespace LearningPortal.Data.SqlGeneration
{
    internal static class Fetch
    {
        public static string Query(string table, string columns = "*", string where = "1 = 1", string joins = "") =>
            $"SELECT {columns} FROM {table} {joins} WHERE {where}";

        /// <summary> Returns "SELECT CASE WHEN EXISTS(SELECT {column} FROM {table} WHERE {condition}) THEN 1 ELSE 0 END" </summary>
        public static string Exists(string table, string condition, string column = "*") =>
            $"SELECT CASE WHEN EXISTS(SELECT {column} FROM {table} WHERE {condition}) THEN 1 ELSE 0 END";

        public static string ReflectionQuery<DTO>(string whereOverride = "")
        {
            if (Attribute.GetCustomAttribute(typeof(DTO), typeof(FetchableDTO)) is not FetchableDTO queryDetails)
            {
                throw new ApplicationException($"{nameof(DTO)} Must Contain The FetchableDTO class attribute");
            }

            var propertyAttributes = typeof(DTO).GetSqlProperties<FetchableAttribute>();

            var itemsToSelect = !propertyAttributes.Any() ? "*" : propertyAttributes.Select(p =>
                    $"{p.Attribute.SpecifiedDatabaseNameOr(p.PropertyName)} as {p.PropertyName}").AggregateWithCommaNewLine();

            var where = !string.IsNullOrWhiteSpace(whereOverride) ? "WHERE " + whereOverride : queryDetails.Where;

            return $"SELECT {itemsToSelect} FROM {queryDetails.Table} {queryDetails.Joins} {where} {queryDetails.OrderBy}";
        }
    }
}