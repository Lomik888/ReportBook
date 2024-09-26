using Microsoft.AspNetCore.Mvc;
using ReportBook.Domain.Dto;
using ReportBook.Domain.Interface.Service;
using ReportBook.Domain.Result;

namespace ReportBook.API.Controllers;

[ApiController]
[Route("api/v1")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
    
    [HttpGet("report/{id}")]
    public async Task<ActionResult<BaseResult<ReportDto>>> GetReportAsync(long id)
    {
        var response = await _reportService.GetReportByIdAsync(id);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }
    
    [HttpGet("reports/{id}")]
    public async Task<ActionResult<CollectionResult<ReportDto>>> GetReportsAsync(long userId)
    {
        var response = await _reportService.GetReportsByUserIdAsync(userId);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<BaseResult<ReportDto>>> CreateReportsAsync([FromQuery]string name, [FromQuery]string description, [FromQuery]long userId)
    {
        var response = await _reportService.CreateReportAsync(new CreateReportDto()
        {
            UserId = userId,
            Name = name,
            Description = description
        });
        
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }
    
    [HttpDelete]
    public async Task<ActionResult<BaseResult<ReportDto>>> DeleteReportsAsync(long reportId)
    {
        var response = await _reportService.DeleteReportByIdAsync(reportId);
        
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<BaseResult<ReportDto>>> UpdateReportsAsync([FromQuery]string name, [FromQuery]string description, [FromQuery]long userId)
    {
        var response = await _reportService.UpdateReportAsync(new UpdateReportDto()
        {
            Id = userId,
            Name = name,
            Description = description
        });
        
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }
}