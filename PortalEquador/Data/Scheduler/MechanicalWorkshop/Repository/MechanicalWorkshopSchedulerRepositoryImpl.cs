using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Scheduler.Entities;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.Repositories;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.Repository;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels;
using PortalEquador.Repositories;

namespace PortalEquador.Data.Scheduler.MechanicalWorkshop.Repository
{
    public class MechanicalWorkshopSchedulerRepositoryImpl : GenericRepository<MechanicalWorkshopSchedulerEntity>, MechanicalWorkshopSchedulerRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public MechanicalWorkshopSchedulerRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            _mapper = mapper;
        }

        public async Task<List<MechanicalWorkshopSchedulerViewModel>> GetAll(DateTime date)
        {
            var result = await context.MechanicalWorkshopSchedulerEntity
               //.Include(item => item.LicenceTypeGroupItemEntity)
               .ToListAsync();

            return _mapper.Map<List<MechanicalWorkshopSchedulerViewModel>>(result);
        }

        public Task<DocumentViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save(MechanicalWorkshopSchedulerViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
