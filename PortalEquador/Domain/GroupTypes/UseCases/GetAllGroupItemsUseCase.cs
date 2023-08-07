using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.UseCases
{
    public class GetAllGroupItemsUseCase
    {
        private readonly GroupItemRepository _groupRepository;

        public GetAllGroupItemsUseCase(GroupItemRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<List<GroupItemViewModel>> Invoke(int groupId)
        {
            return await _groupRepository.GetAllAsync(groupId);
        }
    }
}
