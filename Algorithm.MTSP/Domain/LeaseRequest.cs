using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Domain
{
    [ExportTsInterface]
    public class LeaseRequest
    {
        public int Id { get; set; }
        public DateTimeOffset StartsWithDate {get; set;}
        public int AmountOfWorkers { get; set; } = 1;
        public int AmountOfWorkDays { get; set; }
        public string PostCenterId = "";
        public IEnumerable<string> SelectedPostCenterIds {get; set;} = new List<string>();
    }
}
