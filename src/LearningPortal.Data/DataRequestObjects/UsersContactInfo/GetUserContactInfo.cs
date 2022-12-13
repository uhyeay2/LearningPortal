namespace LearningPortal.Data.DataRequestObjects.UsersContactInfo
{
    public class GetUserContactInfo :IDataRequestObject
    {

        #region Constructors

        public GetUserContactInfo(int userId) => UserId = userId;
        
        public GetUserContactInfo(string userIdentity) => UserIdentity = userIdentity;
        
        public GetUserContactInfo(Guid userGuid) => UserGuid = userGuid;

        #endregion

        #region Parameters Searchable By

        public int? UserId { get; set; }

        public string? UserIdentity { get; set; }

        public Guid? UserGuid { get; set; }

        #endregion

        #region IDataRequestObject Obligations

        public object? GenerateParameters() => new { UserId, UserIdentity, UserGuid };

        public string GenerateSql() => Fetch.Query(
            table: Table.UsersContactInfo_NoLock, 
            columns: $"{Table.UsersContactInfo}.*",
            where: "(   (Users.Id = @UserId AND @UserGuid IS NULL AND @UserIdentity IS NULL ) " +                   // fetch by @UserId
                    "OR (Users.Guid = @UserGuid AND @UserId IS NULL AND @UserIdentity IS NULL) " +                  // fetch by @UserGuid
                    "OR (Users.IdentityIdentifier = @UserIdentity AND @UserId IS NULL AND @UserGuid IS NULL) )",    // fetch by @UserIdentity

            joins: $"JOIN {Table.Users_NoLock} ON {Table.Users}.Id = {Table.UsersContactInfo}.UserId");

        #endregion

    }
}
