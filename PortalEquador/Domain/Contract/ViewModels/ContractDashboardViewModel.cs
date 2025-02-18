using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractDashboardViewModel : ViewModel
    {
        public int Id { get; set; }
        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        public int TotalExams { get; set; }
        public int TotalTrainning { get; set; }
        public int TotalDisciplinaryNotification { get; set; }

        public required string ProfileImagePath { get; set; }

    }
}