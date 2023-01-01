using LearningPortal.Data.DataRequestObjects.UsersContactInfo;
using LearningPortal.Domain.Extensions;
using LearningPortal.Domain.Models;

namespace LearningPortal.Mediator.Mediators.UserContactInfoMediators
{
    public class InsertUserContactInfoRequest : RequiredIdentityRequest
    {
        #region Constructors 

        public InsertUserContactInfoRequest() { }

        public InsertUserContactInfoRequest(string identity, string firstName, string lastName, string email, string? preferredName = null) : base(identity)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PreferredName = preferredName;
        }

        #endregion

        #region Properties To Insert

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? PreferredName { get; set; }

        public string Email { get; set; } = null!;

        #endregion

        #region Validation

        public override bool IsValid(out List<ValidationFailedMessage> validationFailures)
        {
            _ = base.IsValid(out validationFailures);

            validationFailures.AddIfAnyStringsAreNullOrWhiteSpace((nameof(FirstName), FirstName), (nameof(LastName), LastName));

            validationFailures.AddIfEmailIsNotValidFormat(nameof(Email), Email);

            return !validationFailures.Any();
        }

        #endregion

        internal InsertUserContactInfo DataRequest => new(Identity, FirstName, LastName, Email, PreferredName);
    }

    internal class InsertUserContactInfoMediator : DataMediator<InsertUserContactInfoRequest>
    {
        public InsertUserContactInfoMediator(IDataConnection data) : base(data) { }

        protected override async Task<BaseResponse> Mediate(InsertUserContactInfoRequest request, CancellationToken cancellationToken = default)
        {
            return await _data.ExecuteAsync(request.DataRequest) switch
            {
                1 => Response.Success(),

                -1 => Response.AlreadyExists("UserContactInfo", $"Identity = {request.Identity}"),
                
                _ => Response.Unexpected("Unknown Error When Attempting To Insert UserContactInfo"),
            };
        }
    }
}
  