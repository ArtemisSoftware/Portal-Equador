namespace PortalEquador.Domain.Report.ViewModels.Trainning
{
    public class TrainningPerDayViewModel
    {
        public string FullName { get; set; } = "";
        public DateTime? Date { get; set; }
        public string WorkStation { get; set; }
        public List<int> Trainings { get; set; } = new();
    }
}
