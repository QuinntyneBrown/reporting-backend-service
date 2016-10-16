namespace ReportingBackendService.Data
{
    public interface IUow
    {
        IRepository<Models.Report> Reports { get; }
        void SaveChanges();
    }
}
