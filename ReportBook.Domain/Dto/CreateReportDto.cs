namespace ReportBook.Domain.Dto;

public class CreateReportDto
{
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public long UserId { get; set; }
}