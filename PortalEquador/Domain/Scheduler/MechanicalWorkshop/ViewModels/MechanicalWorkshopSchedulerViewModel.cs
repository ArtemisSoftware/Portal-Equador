using PortalEquador.Constants;
using PortalEquador.Domain.GroupTypes.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels
{
    public class MechanicalWorkshopSchedulerViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.MECHANIC)]
        public GroupItemViewModel Mechanic { get; set; }

        public GroupItemViewModel InterventionTime { get; set; }

        public string LicencePlate { get; set; }

        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY__HH_MM)]
        public DateTime ScheduleDate { get; set; }

        //HORARIO  CONTRATO    CODIGO SERVIÇO MODELO TELEFONE

    }
}
