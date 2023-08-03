using AutoMapper;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Repositories;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Domain.GroupTypes.UseCases
{
    public class SaveGroupUseCase
    {
        private readonly GroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public SaveGroupUseCase(GroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task Invoke(GroupViewModel model, OperationType operationType)
        {
            GroupEntity entity = _mapper.Map<GroupEntity>(model);

            switch (operationType)
            {
                case OperationType.Create:

                    await _groupRepository.AddAsync(entity);
                    break;
                 case OperationType.Update:

                    await _groupRepository.UpdateAsync(entity);
                    break;
            }
        }
    }
}
