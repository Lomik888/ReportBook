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
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResult<ReportDto>>> GetReportAsync(long id)
    {
        var response = await _reportService.GetReportByIdAsync(id);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }
}