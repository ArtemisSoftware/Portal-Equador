using PortalEquador.Util.Constants;
using System.ComponentModel;

namespace PortalEquador.Domain.Contract
{
    public class ContractState
    {
        [Description(StringConstants.ContractStatus.UNASSIGNED)]
        public const int Unassigned = 0;

        [Description(StringConstants.ContractStatus.CONTRACTED)]
        public const int Contracted = 1;

        [Description(StringConstants.ContractStatus.FIRED)]
        public const int Fired = 2;
    }
}
