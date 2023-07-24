using System;
using System.ComponentModel;

namespace PortalEquador.Models.Documents
{
    public enum LicenceStatus
    {
        [Description("Sem data de expiração")] // TODO: Mudar isto
        No_Expiration_Date,

        [Description("Atualizado")]
        Updated,

        [Description("Caducada")]
        Expired,

        [Description("Verbete atualizado")]
        Provisional_Renewal_Updated,

        [Description("Verbete Caducado")]
        Provisional_Renewal_Expired,
    }
}
