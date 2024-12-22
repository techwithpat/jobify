using FluentValidation;

namespace Jobify.Api.Features.Companies.CreateCompany;

public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyValidator()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email must be valid");
    }
}