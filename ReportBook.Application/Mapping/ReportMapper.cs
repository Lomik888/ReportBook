using AutoMapper;
using ReportBook.Domain.Dto;
using ReportBook.Domain.Entity;

namespace ReportBook.Application.Mapping;

public class ReportMapper : Profile
{
    public ReportMapper()
    {
        CreateMap<ReportEntity,ReportDto>().ReverseMap();
    }
}