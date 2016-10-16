using System;
using System.Collections.Generic;
using ReportingBackendService.Dtos;
using ReportingBackendService.Data;
using System.Linq;

namespace ReportingBackendService.Services
{
    public class ReportService : IReportService
    {
        public ReportService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Reports;
            _cache = cacheProvider.GetCache();
        }

        public ReportAddOrUpdateResponseDto AddOrUpdate(ReportAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.Report());
            entity.Title = request.Name;
            _uow.SaveChanges();
            return new ReportAddOrUpdateResponseDto(entity);
        }

        public ICollection<ReportDto> Get()
        {
            ICollection<ReportDto> response = new HashSet<ReportDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new ReportDto(entity)); }
            return response;
        }

        public ReportDto GetById(int id)
        {
            return new ReportDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Models.Report> _repository;
        protected readonly ICache _cache;
    }
}
