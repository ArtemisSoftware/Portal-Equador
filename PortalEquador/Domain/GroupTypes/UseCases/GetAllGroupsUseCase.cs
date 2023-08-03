using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.UseCases
{
    public class GetAllGroupsUseCase
    {
        private readonly GroupRepository _groupRepository;

        public GetAllGroupsUseCase(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<List<GroupViewModel>> Invoke()
        {
            return await _groupRepository.GetAll();
        }
    }
}
