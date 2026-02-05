using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Data.Generic;
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

        Task<UniformViewModel?> GetUniform(int id);
        Task UpdateState(int id, bool active);

        Task<bool> UniformExists(string description);
        SelectList GetUniforms(
            OrderType orderType = OrderType.No_order,
            string extraOption = "",
            bool addExtraOptionOnTop = false
        );

        Task<List<UniformViewModel>> GetAllUniforms(OrderType orderType = OrderType.No_order);
    }
}
