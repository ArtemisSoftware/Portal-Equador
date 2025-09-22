using PortalEquador.Data.Uniforms.Entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Uniforms.ViewModels;

namespace PortalEquador.Domain.Uniforms.Repository
{
    public interface IUniformRepository : IGenericRepository<UniformEntity>
    {
        Task<List<UniformViewModel>> GetAll();

        Task Save(UniformViewModel model);
        Task UpdateState(int id, bool active);

        //Task<GroupItemViewModel?> GetGroupItem(int id);
        Task<bool> UniformExists(string description);

    }
}
