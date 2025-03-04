using FluentValidation;
using Candidate.Api.Dtos;

namespace Candidate.Api.Validators;

public class CandidateUpsertRequestValidator : AbstractValidator<CandidateUpsertRequest>
{
    public CandidateUpsertRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Comment).NotEmpty();
    }
}
