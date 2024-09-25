using FluentValidation;
using ReportBook.Domain.Dto;

namespace ReportBook.Application.Validations.FluentValidation;

public class CreateReportValidation : AbstractValidator<CreateReportDto>
{
    public CreateReportValidation()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(5).MaximumLength(30);
        RuleFor(x => x.Description).NotEmpty().MinimumLength(5).MaximumLength(100);
        RuleFor(x => x.UserId).NotEmpty();
    }
}