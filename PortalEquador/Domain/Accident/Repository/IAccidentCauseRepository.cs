using AutoMapper;
using PortalEquador.Data.Accident.Entities;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.Accident.Repository
{
    public interface IAccidentCauseRepository
    {
        Task Save(int accidentId, List<GroupItemViewModel> causes);
    }
}
