using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PortalEquador.Data;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Domain.GroupTypes.UseCases
{
    public class SaveGroupItemUseCase
    {
        private readonly GroupItemRepository _groupItemRepository;
        private readonly IMapper _mapper;

        public SaveGroupItemUseCase(GroupItemRepository groupItemRepository, IMapper mapper)
        {
            _groupItemRepository = groupItemRepository;
            _mapper = mapper;
        }

        public async Task Invoke(GroupItemViewModel model, OperationType operationType)
        {
            GroupItemEntity entity = _mapper.Map<GroupItemEntity>(model);

            switch (operationType)
            {
                case OperationType.Create:

                    await _groupItemRepository.AddAsync(entity);
                    break;
                case OperationType.Update:

                    entity.DateModified = DateTime.UtcNow;
                    await _groupItemRepository.UpdateAsync(entity);
                    break;
            }
        }
    }
}
