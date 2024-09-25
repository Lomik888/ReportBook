using ReportBook.Domain.Entity;
using ReportBook.Domain.Result;

namespace ReportBook.Domain.Interface.Validation;

public interface IReportValidation : IBaseValidation<ReportEntity>
{
    public BaseResult CreateReportValidation(UserEntity user, ReportEntity report);
}