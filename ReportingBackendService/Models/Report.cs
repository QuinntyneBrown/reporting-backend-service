using System.Collections.Generic;

namespace ReportingBackendService.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Column> Columns { get; set; } = new HashSet<Column>();
        public bool IsDeleted { get; set; }
    }
}
