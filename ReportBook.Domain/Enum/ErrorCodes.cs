namespace ReportBook.Domain.Enum;

public enum ErrorCodes
{ 
    ReportsNotFound = 0,
    ReportNotFound,
    ReportAlreadyExist,
    
    UserNotFound = 10,
    
    IternalServerError = 30,
}