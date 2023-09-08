using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PortalEquador.Data;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Domain.GroupTypes.Repository;

namespace PortalEquador.Domain.GroupTypes.UseCases
{
    public class UpdateGroupItemStateUseCase
    {
        private readonly GroupItemRepository _groupItemRepository;

        public UpdateGroupItemStateUseCase(GroupItemRepository groupItemRepository)
        {
            _groupItemRepository = groupItemRepository;
        }

        public async Task Invoke(int groupItemId, bool active)
        {
            GroupItemEntity entity = await _groupItemRepository.GetAsync(groupItemId);

            entity.Active = active;
            entity.DateModified = DateTime.UtcNow;
            await _groupItemRepository.UpdateAsync(entity);
        }
    }
}
