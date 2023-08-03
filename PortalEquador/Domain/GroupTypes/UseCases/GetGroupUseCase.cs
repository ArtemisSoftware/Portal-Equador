using AutoMapper;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Domain.GroupTypes.UseCases
{
    public class GetGroupUseCase
    {
        private readonly GroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetGroupUseCase(GroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GroupViewModel?> Invoke(int? id)
        {
            var entity = await _groupRepository.GetAsync(id);

            if (entity == null)
            {
                return null;
            }

            var model = _mapper.Map<GroupViewModel>(entity);
            return model;
        }
    }
}
