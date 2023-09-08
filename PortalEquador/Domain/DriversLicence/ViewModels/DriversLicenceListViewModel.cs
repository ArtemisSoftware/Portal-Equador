using NuGet.Packaging.Signing;
using PortalEquador.Constants;
using PortalEquador.Domain.DriversLicence;
using PortalEquador.Domain.Models;
using PortalEquador.Util;
using System.ComponentModel.DataAnnotations;


namespace PortalEquador.Domain.DriversLicence.ViewModels
{
    public class DriversLicenceListViewModel
    {
        public int? Id { get; set; }

        public int CurriculumId { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public DateTime? ProvisionalExpirationDate { get; set; }

        public bool ExpirationDateAvailable
        {
            get
            {

                if (ExpirationDate == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        [Display(Name = StringConstants.Display.FULL_NAME)]
        public string FullName { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        public string? Licence { get; set; }


        public string ProfilePicturePath
        {
            get
            {
                return "";//ImagesUtil.GetFilePath(CurriculumId);
            }
        }
        
        [Display(Name = StringConstants.Display.STATE)]
        public LicenceStatus Status { 
            get
            {
                return GetLicenceStatus();
            }
        }

        public string? StatusDescription
        {
            get
            {
                if (Status == null)
                {
                    return null;
                }
                else
                {
                    return Status.ToName();
                }
            }
        }


        private LicenceStatus GetLicenceStatus()
        {

            if (ExpirationDateAvailable == false)
            {
                return LicenceStatus.No_Expiration_Date;
            }
            else if (ExpirationDate < DateTime.Now && ProvisionalExpirationDate == null)
            {
                return LicenceStatus.Expired;
            }
            else if (ExpirationDate < DateTime.Now && ProvisionalExpirationDate < DateTime.Now)
            {
                return LicenceStatus.Provisional_Renewal_Expired;
            }
            else if (ExpirationDate < DateTime.Now && ProvisionalExpirationDate > DateTime.Now)
            {
                return LicenceStatus.Provisional_Renewal_Updated;
            }
            else if (ExpirationDate > DateTime.Now)
            {
                return LicenceStatus.Updated;
            }
            return LicenceStatus.Expired;
        }

    }
}
