using FluentValidation;
using ReportBook.Domain.Dto;

namespace ReportBook.Application.Validations.FluentValidation;

public class UpdateReportValidation : AbstractValidator<UpdateReportDto>
{
    public UpdateReportValidation()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(5).MaximumLength(30);
        RuleFor(x => x.Description).NotEmpty().MinimumLength(5).MaximumLength(100);
        RuleFor(x => x.Id).NotEmpty();
    }
}