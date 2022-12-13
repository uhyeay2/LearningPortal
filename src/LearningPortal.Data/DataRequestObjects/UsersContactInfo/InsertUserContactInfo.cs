namespace LearningPortal.Data.DataRequestObjects.UsersContactInfo
{
    public class InsertUserContactInfo : IDataRequestObject
    {
        #region Constructors

        public InsertUserContactInfo(string identity, string firstName, string lastName, string email, string? preferredName = null)
        {
            Identity = identity;
            FirstName = firstName;
            LastName = lastName;
            PreferredName = preferredName;
            Email = email;
        }

        #endregion

        #region Properties To Insert

        public string Identity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? PreferredName { get; set; }

        public string Email { get; set; }

        #endregion

        public object? GenerateParameters() => new { Identity, FirstName, LastName, PreferredName, Email };

        public string GenerateSql() => _sql;

        private static readonly string _sql = 
        $@"
            DECLARE @UserId INT = ( {Fetch.Query(Table.Users_NoLock, "Id", "IdentityIdentifier = @Identity")} )

            IF(@UserId IS NOT NULL AND NOT EXISTS( {Fetch.Query(Table.UsersContactInfo_NoLock, where: "UserId = @UserId")} ) )
            BEGIN
                {Insert.Command(Table.UsersContactInfo, "UserId, FirstName, LastName, PreferredName,  Email")}
            END
        ";
    }
}
