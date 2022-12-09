namespace LearningPortal.Data.DataRequestObjects.UserRequests
{
    public class UpdateUser : IDataRequestObject
    {
        public UpdateUser(string identity, string? preferredName)
        {
            Identity = identity;
            PreferredName = preferredName;
        }

        public string Identity { get; set; } = null!;

        public string? PreferredName { get; set; }

        public object? GenerateParameters() => new { Identity, PreferredName };

        public string GenerateSql() => Update.Coalesce(
            table: Table.Users,
            where: "IdentityIdentifier = @Identity",
            items: new[] { "PreferredName" });

    }
}
