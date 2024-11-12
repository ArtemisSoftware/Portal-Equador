using PortalEquador.Util.Constants;
using System.ComponentModel;

namespace PortalEquador.Domain.MechanicalWorkshop
{
    public class CarWashState
    {
        [Description(StringConstants.CarWashStatus.PERFORMED)]
        public const int Performed = 1;

        [Description(StringConstants.CarWashStatus.NOT_PERFORMED)]
        public const int NotPerformed = 2;

        public const int Open = 3;
    }
}
