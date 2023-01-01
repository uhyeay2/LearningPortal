using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningPortal.Api.Abstractions
{
    public class BaseController : Controller
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
