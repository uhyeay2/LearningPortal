namespace LearningPortal.Data.SqlGeneration
{
    internal static class Delete
    {
        public static string Command(string table, string where) => $"DELETE FROM {table} WHERE {where}";
    }
}
