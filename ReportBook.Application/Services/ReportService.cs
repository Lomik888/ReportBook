using Microsoft.EntityFrameworkCore;
using ReportBook.Domain.Dto;
using ReportBook.Domain.Entity;
using ReportBook.Domain.Interface.Repository;
using ReportBook.Domain.Interface.Service;
using ReportBook.Domain.Result;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ReportBook.Application.Resources;
using ReportBook.Domain.Enum;
using ReportBook.Domain.Interface.Validation;

namespace ReportBook.Application.Services
{
    public class ReportService : IReportService
    {
        public readonly IBaseRepository<ReportEntity> _repRepository;
        public readonly IBaseRepository<UserEntity> _userRepository;
        public readonly IReportValidation _reportValidation;
        public readonly IMapper _mapper;
        public readonly ILogger _logger;

        public ReportService(IBaseRepository<ReportEntity> repRepository, ILogger logger, IBaseRepository<UserEntity> userRepository)
        {
            _repRepository = repRepository;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<CollectionResult<ReportDto>> GetReportsByUserIdAsync(long userId)
        {
            ReportDto[] reports;

            try
            {
                reports = await _repRepository.GetAll()
                                              .Where(x => x.Id == userId)
                                              .Select(x => new ReportDto()
                                              {
                                                  Id = x.Id,
                                                  Name = x.Name,
                                                  Description = x.Description,
                                                  DateCreated = x.CreatedAt.ToShortDateString()
                                              })
                                              .ToArrayAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);

                return new CollectionResult<ReportDto>()
                {
                    ErrorMessage = ErrorMessage.IternalServerError,
                    ErrorCode= (int) ErrorCodes.IternalServerError
                };
            }

            if (!reports.Any())
            {
                _logger.Warning(ErrorMessage.ReportsNotFound, reports.Length);
                return new CollectionResult<ReportDto>()
                {
                    ErrorMessage = ErrorMessage.ReportsNotFound,
                    ErrorCode= (int) ErrorCodes.ReportsNotFound
                };
            }

            return new CollectionResult<ReportDto>() {Data = reports };
        }

        public async Task<BaseResult<ReportDto>> GetReportByIdAsync(long reportId)
        {
            ReportDto? report;

            try
            {
                report = await _repRepository.GetAll().Select(x => new ReportDto()
                {
                    Id = reportId,
                    Name = x.Name,
                    Description = x.Description,
                    DateCreated = x.CreatedAt.ToShortDateString()
                }).FirstOrDefaultAsync(x => x.Id == reportId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<ReportDto>()
                {
                    ErrorMessage = ErrorMessage.IternalServerError,
                    ErrorCode = (int)ErrorCodes.IternalServerError
                };
            }

            if (report == null)
            {
                _logger.Warning(ErrorMessage.ReportNotFound, reportId);
                return new BaseResult<ReportDto>()
                {
                    ErrorMessage = ErrorMessage.ReportNotFound,
                    ErrorCode = (int)ErrorCodes.ReportNotFound
                };
            }

            return new BaseResult<ReportDto>() {Data = report};
        }

        public async Task<BaseResult<ReportDto>> CreateReportAsync(CreateReportDto reportDto)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Id == reportDto.UserId);
                var report = await _repRepository.GetAll().FirstOrDefaultAsync(x => x.Name == reportDto.Name);

                var result = _reportValidation.CreateReportValidation(user, report);

                if (!result.IsSuccess)
                {
                    return new BaseResult<ReportDto>()
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode
                    };
                }
                
                report= new ReportEntity()
                {
                    UserId = reportDto.UserId,
                    Name = reportDto.Name,
                    Description = reportDto.Description,
                };
                
                await _repRepository.CreateAsync(report);
            
                return new BaseResult<ReportDto>() { Data = _mapper.Map<ReportDto>(report)};
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);

                return new BaseResult<ReportDto>()
                {
                    ErrorMessage = ErrorMessage.IternalServerError,
                    ErrorCode= (int) ErrorCodes.IternalServerError
                };
            }
        }

        public async Task<BaseResult<ReportDto>> DeleteReportByIdAsync(long reportId)
        {
            try
            {
                var report = await _repRepository.GetAll().FirstOrDefaultAsync(x => x.Id == reportId);
                var result = _reportValidation.ValidateOnNull(report);

                if (!result.IsSuccess)
                {
                    return new BaseResult<ReportDto>()
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode
                    };
                }

                await _repRepository.RemoveAsync(report);
                
                return new BaseResult<ReportDto>() { Data = _mapper.Map<ReportDto>(report) };
            }
            catch (Exception ex)
            {
               _logger.Error(ex, ex.Message);
               return new BaseResult<ReportDto>()
               {
                   ErrorMessage = ErrorMessage.IternalServerError,
                   ErrorCode = (int)ErrorCodes.IternalServerError
               };
            }
        }

        public async Task<BaseResult<ReportDto>> UpdateReportAsync(UpdateReportDto updateDto)
        {
            try
            {
                var report = await _repRepository.GetAll().FirstOrDefaultAsync(x => x.Id == updateDto.Id);
                var result = _reportValidation.ValidateOnNull(report);

                if (!result.IsSuccess)
                {
                    return new BaseResult<ReportDto>()
                    {
                        ErrorMessage = result.ErrorMessage,
                        ErrorCode = result.ErrorCode
                    };
                }

                report = _mapper.Map<ReportEntity>(updateDto);
                
                await _repRepository.RemoveAsync(report);
                
                return new BaseResult<ReportDto>() { Data = _mapper.Map<ReportDto>(report) };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<ReportDto>()
                {
                    ErrorMessage = ErrorMessage.IternalServerError,
                    ErrorCode = (int)ErrorCodes.IternalServerError
                };
            }
        }
    }
}
