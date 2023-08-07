using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.UseCases
{
    public class GroupItemExistsUseCase
    {
        private readonly GroupItemRepository _groupItemRepository;

        public GroupItemExistsUseCase(GroupItemRepository groupItemRepository)
        {
            _groupItemRepository = groupItemRepository;
        }

        public async Task<bool> Invoke(GroupItemViewModel model)
        {
            return await _groupItemRepository.GroupItemExists(model);
        }
    }
}
