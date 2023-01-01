using LearningPortal.Api.Abstractions;
using LearningPortal.Mediator.Abstractions.Responses;
using LearningPortal.Mediator.Mediators.UserContactInfoMediators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningPortal.Api.Controllers
{
    public class UserContactInfoController : BaseController
    {
        public UserContactInfoController(IMediator mediator) : base(mediator) { }

        [HttpPost ("InsertContactInfo")]
        public async Task<BaseResponse> InsertUserContactInfo(InsertUserContactInfoRequest request) => await _mediator.Send(request);

    }
}
