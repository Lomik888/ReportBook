using ReportBook.Domain.Dto;
using ReportBook.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBook.Domain.Interface.Service
{
    public interface IReportService
    {
        public Task<CollectionResult<ReportDto>> GetReportsByUserIdAsync(long userId);
        
        public Task<BaseResult<ReportDto>> GetReportByIdAsync(long reportId);
        
        public Task<BaseResult<ReportDto>> CreateReportAsync(CreateReportDto reportDto);

        public Task<BaseResult<ReportDto>> DeleteReportByIdAsync(long reportId);
        
        public Task<BaseResult<ReportDto>> UpdateReportAsync(UpdateReportDto updateDto);
    }
}
