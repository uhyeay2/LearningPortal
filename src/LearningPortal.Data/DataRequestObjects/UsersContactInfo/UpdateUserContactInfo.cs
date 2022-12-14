namespace LearningPortal.Data.DataRequestObjects.UsersContactInfo
{
    public class UpdateUserContactInfo : IDataRequestObject
    {

        #region Constructor

        public UpdateUserContactInfo(Guid userGuid, string? firstName = null, string? lastName = null, string? preferredName = null, string? email = null)
        {
            FirstName = firstName;
            LastName = lastName;
            PreferredName = preferredName;
            Email = email;
            UserGuid = userGuid;
        }

        #endregion

        #region Properties To Update

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        
        public string? PreferredName { get; set; }

        public string? Email { get; set; }

        public Guid UserGuid { get; set; }

        #endregion

        #region IDataRequestObject Obligations

        public object? GenerateParameters() => new {FirstName, LastName, PreferredName, Email, UserGuid};

        public string GenerateSql() => _sql;

        private static readonly string _sql =
        $@"
            DECLARE @UserId int = ( {Fetch.Query(Table.Users_NoLock, "Id", where: "Guid = @UserGuid")} )
            
            {Update.Coalesce(Table.UsersContactInfo, where: "UserId = @UserId", 
                items: new[] {"FirstName", "LastName", "PreferredName", "Email"} )}
        ";
            
        #endregion
    }
}
