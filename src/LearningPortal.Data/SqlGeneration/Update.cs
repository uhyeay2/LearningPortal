namespace LearningPortal.Data.SqlGeneration
{
    internal static class Update
    {
        internal static string Set(string table, string where, params string[] items) => Set(table, where, items.Select(x => (x, x)).ToArray());

        internal static string Set(string table, string where, params (string ColumnName, string ValueName)[] items) =>
            $"UPDATE {table} SET \n {items.Select(x => $"{x.ColumnName} = {x.ValueName}").AggregateWithCommaNewLine()} WHERE {where}";

        internal static string Coalesce(string table, string where, params string[] items) => Coalesce(table, where, items.Select(x => (x, x)).ToArray());

        internal static string Coalesce(string table, string where, params (string ColumnName, string ValueName)[] items) =>
            $"UPDATE {table} SET \n {items.Select(x => $"{x.ColumnName} = COALESCE({x.ValueName}, {x.ColumnName})").AggregateWithCommaNewLine()} WHERE {where}";

        internal static string ReflectionCommand<TRequest>()
        {
            if (Attribute.GetCustomAttribute(typeof(TRequest), typeof(UpdateRequestObject)) is not UpdateRequestObject request)
            {
                throw new ApplicationException($"{nameof(TRequest)} Must Contain The UpdateRequestObject class attribute");
            }

            var propertyAttributes = typeof(TRequest).GetSqlProperties<UpdatableAttribute>();

            if (!propertyAttributes.Any())
            {
                throw new ApplicationException($"Request Object {nameof(TRequest)} Must contain properties with an Updatable attribute");
            }

            var items = propertyAttributes.Select(x => x.Attribute.IsCoalesceUpdate ?
                $"{x.Attribute.SpecifiedDatabaseNameOr(x.PropertyName)} = COALESCE ( @{x.PropertyName} , {x.Attribute.SpecifiedDatabaseNameOr(x.PropertyName)} ) "
                : $"{x.Attribute.SpecifiedDatabaseNameOr(x.PropertyName)} = ${x.PropertyName}"
                ).AggregateWithCommaNewLine();

            return $"UPDATE {request.Table} SET \n {items} \n {request.Where}";
        }
    }
}
