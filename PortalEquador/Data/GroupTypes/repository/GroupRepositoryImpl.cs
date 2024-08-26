using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Data.GroupTypes.repository
{
    public class GroupRepositoryImpl : GenericRepository<GroupEntity>, GroupRepository
    {
        //private readonly IMapper _mapper;

        public GroupRepositoryImpl(ApplicationDbContext context/*, IMapper mapper*/) : base(context)
        {
           // _mapper = mapper;
        }

        public async Task<List<GroupViewModel>> GetAll()
        {
            return new List<GroupViewModel>();
            /*
            var entity = await GetAllAsync();
            var models = _mapper.Map<List<GroupViewModel>>(entity);
            return models;
            */
        }

        public async Task<bool> GroupExists(string description)
        {
            //return await context.GroupEntity.AnyAsync(item => item.Description == description);
            return  false;
        }
    }
}
