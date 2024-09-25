using ReportBook.Application.Resources;
using ReportBook.Domain.Entity;
using ReportBook.Domain.Enum;
using ReportBook.Domain.Interface.Validation;
using ReportBook.Domain.Result;

namespace ReportBook.Application.Validations;

public class ReportValidation : IReportValidation
{
    public BaseResult ValidateOnNull(ReportEntity? entity)
    {
        if (entity is null)
        {
            return new BaseResult()
            {
                ErrorMessage = ErrorMessage.ReportNotFound,
                ErrorCode = (int)ErrorCodes.ReportNotFound
            };
        }

        return new BaseResult();
    }

    public BaseResult CreateReportValidation(UserEntity? user, ReportEntity? report)
    {
        if (user is null)
        {
            return new BaseResult()
            {
                ErrorMessage = ErrorMessage.UserNotFound,
                ErrorCode = (int)ErrorCodes.UserNotFound
            };
        }

        if (report != null)
        {
            return new BaseResult()
            {
                ErrorMessage = ErrorMessage.ReportAlreadyExist,
                ErrorCode = (int)ErrorCodes.ReportAlreadyExist
            };
        }

        return new BaseResult(){};
    }
}