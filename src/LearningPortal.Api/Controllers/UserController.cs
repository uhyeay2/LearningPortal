using LearningPortal.Api.Abstractions;
using LearningPortal.Mediator.Abstractions.Responses;
using LearningPortal.Mediator.Mediators.UserMediators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningPortal.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpGet ("IsUserIdentityRegistered")]
        public async Task<BaseResponse> IsUserIdentityRegistered(string identity) => await _mediator.Send(new IsUserIdentityRegisteredRequest(identity));

        [HttpPost ("InsertUser")]
        public async Task<BaseResponse> InsertUser(string identity) => await _mediator.Send(new InsertUserRequest(identity));
    }
}
