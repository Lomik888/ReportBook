namespace ReportBook.Domain.Dto;

public class UpdateReportDto
{
    public long Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
}