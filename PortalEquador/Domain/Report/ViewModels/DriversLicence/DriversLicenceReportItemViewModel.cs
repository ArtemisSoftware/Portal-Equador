using DocumentFormat.OpenXml.Spreadsheet;
using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.DriversLicence
{
    public class DriversLicenceReportItemViewModel : ViewModel
    {
        public string FullName { get; set; }

        public string WorkStation { get; set; }

        public string Licence { get; set; }

        public DateTime? LicenceExpirationDate { get; set; }
        public DateTime? ProvisionalExpirationDate { get; set; } = null;

        public string GetLicenceExpirationRemainingTime()
        {
            if (LicenceExpirationDate.HasValue)
            {
                var daysDifference = (LicenceExpirationDate.Value.Date - DateTime.Now.Date).Days;

                if (daysDifference < 0)
                {
                    return "Expirado";
                }
                else if (daysDifference == 0)
                {
                    return "Último dia";
                }

                return daysDifference.ToString();
            }

            if (LicenceExpirationDate.HasValue == false && ProvisionalExpirationDate.HasValue == false)
            {
                return "Sem data de expiração";
            }

            return "";
        }


        public string GetProvisionalExpirationRemainingTime()
        {
            if (ProvisionalExpirationDate.HasValue)
            {
                var daysDifference = (ProvisionalExpirationDate.Value.Date - DateTime.Now.Date).Days;

                if (daysDifference < 0)
                {
                    return "Expirado";
                }
                else if (daysDifference == 0)
                {
                    return "Último dia";
                }

                return daysDifference.ToString();
            }

            return "";
        }
    }
}
