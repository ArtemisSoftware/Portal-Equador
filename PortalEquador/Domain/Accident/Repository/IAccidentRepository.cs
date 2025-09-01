using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Accident.Repository
{
    public interface IAccidentRepository : IGenericRepository<AccidentEntity>
    {
    }
}
