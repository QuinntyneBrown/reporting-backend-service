using ReportingBackendService.Dtos;
using System.Collections.Generic;

namespace ReportingBackendService.Services
{
    public interface IReportService
    {
        ReportAddOrUpdateResponseDto AddOrUpdate(ReportAddOrUpdateRequestDto request);
        ICollection<ReportDto> Get();
        ReportDto GetById(int id);
        dynamic Remove(int id);
    }
}
