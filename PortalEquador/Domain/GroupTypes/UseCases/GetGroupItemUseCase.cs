using AutoMapper;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.UseCases
{
    public class GetGroupItemUseCase
    {
        private readonly GroupItemRepository _groupItemRepository;

        public GetGroupItemUseCase(GroupItemRepository groupItemRepository)
        {
            _groupItemRepository = groupItemRepository;
        }

        public async Task<GroupItemViewModel?> Invoke(int groupItemId)
        {
            var model = await _groupItemRepository.GetGroupItemAsync(groupItemId);
            return model;
        }
    }
}
