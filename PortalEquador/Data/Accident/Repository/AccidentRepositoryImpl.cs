using AutoMapper;
using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Contract.Repository;

namespace PortalEquador.Data.Accident.Repository
{
    public class AccidentRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<AccidentEntity>(context, httpContextAccessor), IAccidentRepository
    {

    }
}
