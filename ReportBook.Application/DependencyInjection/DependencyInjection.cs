using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ReportBook.Application.Mapping;
using ReportBook.Application.Services;
using ReportBook.Application.Validations;
using ReportBook.Application.Validations.FluentValidation;
using ReportBook.Domain.Dto;
using ReportBook.Domain.Interface.Service;
using ReportBook.Domain.Interface.Validation;

namespace ReportBook.Application.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ReportMapper));

        services.InitServices();
    }

    private static void InitServices(this IServiceCollection services)
    {
        services.AddScoped<IReportService, ReportService>();

        services.AddScoped<IReportValidation, ReportValidation>();

        services.AddScoped<IValidator<CreateReportDto>, CreateReportValidation>();
        services.AddScoped<IValidator<UpdateReportDto>, UpdateReportValidation>();
    }
}