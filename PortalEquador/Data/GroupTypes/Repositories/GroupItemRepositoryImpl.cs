using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Data.GroupTypes.Repositories
{
    public class GroupItemRepositoryImpl : GenericRepository<GroupItemEntity>, GroupItemRepository
    {

        private readonly IMapper _mapper;

        public GroupItemRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<bool> GroupItemExists(GroupItemViewModel model)
        {
           return await context.GroupItemEntity.AnyAsync(item => item.GroupEntityId == model.GroupId && item.Description == model.Description);
        }

        public async Task<List<GroupItemViewModel>> GetAllAsync(int groupId)
        {
            var result = await context.GroupItemEntity
                .Include(item => item.GroupEntity)
                .Where(item => item.GroupEntityId == groupId).ToListAsync();

            return _mapper.Map<List<GroupItemViewModel>>(result);
            
        }

        public async Task<GroupItemViewModel?> GetGroupItemAsync(int groupItemId)
        {
            var result = await context.GroupItemEntity
               .Include(item => item.GroupEntity)
               .Where(item => item.Id == groupItemId).FirstOrDefaultAsync();

            return _mapper.Map<GroupItemViewModel>(result);
        }
    }

}
