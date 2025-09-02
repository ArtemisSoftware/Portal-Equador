using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Domain.Accident.ViewModels
{
    public class AccidentViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.CITY)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public int Number { get; set; }

        public int PersonaInformationId { get; set; }
        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.DATE)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = StringConstants.Display.HOUR)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        [DataType(DataType.Time)] 
        [DisplayFormat(DataFormatString = StringConstants.Dates.HH_MM, ApplyFormatInEditMode = true)]
        public TimeSpan? Time { get; set; }



        [Display(Name = StringConstants.Display.CONTRACT)]
        [Required]
        public int ContractId { get; set; }

        public SelectList? Contracts { get; set; }



        [Display(Name = StringConstants.Display.ADDRESS)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Address { get; set; }

        [Display(Name = StringConstants.Display.CITY)]
        [Required]
        public int CityId { get; set; }

        public SelectList? Cities { get; set; }


        public List<GroupItemViewModel> Causes { get; set; } = new List<GroupItemViewModel>();
        public List<bool> SelectedCauses { get; set; } = new List<bool>();


        [Display(Name = StringConstants.Display.ESTIMATED_VALUE)]
        public int EstimatedValueId { get; set; }

        public SelectList? EstimatedValues { get; set; }

        [Display(Name = StringConstants.Display.HUMAN_DAMAGE)]
        [Required]
        public int HumanDamage { get; set; }

        [Display(Name = StringConstants.Display.ACCIDENT_LEVEL)]
        public int LevelId { get; set; }

        public SelectList? Levels { get; set; }
    }


}
