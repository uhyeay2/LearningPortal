﻿using LearningPortal.Domain.Extensions;
using LearningPortal.Domain.Models;

namespace LearningPortal.Mediator.Abstractions.Requests
{
    public abstract class RequiredIdentityRequest : BaseValidatableRequest
    {
        public RequiredIdentityRequest() { }

        public RequiredIdentityRequest(string identity) => Identity = identity;

        public string Identity { get; set; } = null!;

        public override bool IsValid(out List<ValidationFailedMessage> validationFailures)
        {
            validationFailures = new List<ValidationFailedMessage>();

            validationFailures.AddIfStringIsNullOrWhiteSpace(nameof(Identity), Identity);

            return !validationFailures.Any();
        }
    }
}
