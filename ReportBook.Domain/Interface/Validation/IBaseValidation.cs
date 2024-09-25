using ReportBook.Domain.Result;

namespace ReportBook.Domain.Interface.Validation;

public interface IBaseValidation<T> where T : class
{
    public BaseResult ValidateOnNull(T entity);
}