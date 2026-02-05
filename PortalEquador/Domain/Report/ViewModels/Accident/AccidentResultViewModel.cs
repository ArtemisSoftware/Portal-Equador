using PortalEquador.Domain.Generic;
using static PortalEquador.Util.Constants.FoldersConstants;
using System.IO;
using PortalEquador.Util.Files.models;
using PortalEquador.Util.Files;

namespace PortalEquador.Domain.Report.ViewModels.Accident
{
    public class AccidentResultViewModel: ViewModel
    {
        public int Id { get; set; }
        public int PersonalInformationId { get; set; }
        public DateTime Date { get; set; }

        public string Level { get; set; }
        public int EstimatedValueId { get; set; }
        public int HumanDamage { get; set; }
        public string LicencePlate { get; set; }


        public string? FileExtension { get; set; }

        public string? Url { get; set; }

        public string Address { get; set; }
        public List<AccidentCauseResultViewModel> Causes { get; set; } = new List<AccidentCauseResultViewModel>();  
    }
}
