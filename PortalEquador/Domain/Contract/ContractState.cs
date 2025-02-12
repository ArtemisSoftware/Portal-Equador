using PortalEquador.Util.Constants;
using System.ComponentModel;

namespace PortalEquador.Domain.Contract
{
    public class ContractState
    {
        [Description(StringConstants.ContractStatus.COMPLETE)]
        public const int Complete = 1;

        [Description(StringConstants.ContractStatus.VALID)]
        public const int Valid = 2;

        [Description(StringConstants.ContractStatus.CANCELED)]
        public const int Canceled = 3;
    }
}
