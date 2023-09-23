namespace PortalEquador.Domain.CurriculumVitae.ViewModels
{
    public class CurriculumDashboardViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public bool IsPersonalInformationComplete { get; set; }

        public int TotalDocuments { get; set; }

        public int TotalCompetences { get; set; }

        public bool IsDriversLicenceComplete { get; set; }
    }
}
