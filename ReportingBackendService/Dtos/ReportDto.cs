namespace ReportingBackendService.Dtos
{
    public class ReportDto
    {
        public ReportDto()
        {

        }

        public ReportDto(Models.Report entity)
        {
            Id = entity.Id;
            Name = entity.Title;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
