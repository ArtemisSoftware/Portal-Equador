using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Repositories;
using PortalEquador.Domain.UseCases;
using PortalEquador.Repositories;

namespace PortalEquador.Data.DriversLicence.Repository
{
    public class DriversLicenceRepositoryImpl : GenericRepository<DriversLicenceEntity>, DriversLicenceRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public DriversLicenceRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            _mapper = mapper;
        }

        public async Task<List<DriversLicenceDetailViewModel>> GetAllDriversLicenceAsync()
        {
            var result = await context.DriversLicenceEntity
               .Include(item => item.LicenceTypeGroupItemEntity)
               .Include(item => item.PersonalInformationEntity)
               .ToListAsync();

            return _mapper.Map<List<DriversLicenceDetailViewModel>>(result);

            //return new List<DriversLicenceListViewModel>();
        }

        public async Task<DriversLicenceViewModel_Finak> GetDriversLicenceAsync(int personalIdentifierId)
        {
           
            var result = await context.DriversLicenceEntity
               .Include(item => item.LicenceTypeGroupItemEntity)
               .Include(item => item.PersonalInformationEntity)
               .FirstOrDefaultAsync(m => m.PersonalInformationId == personalIdentifierId);

            return _mapper.Map<DriversLicenceViewModel_Finak>(result);
           
            //return new DriversLicenceViewModel_Finak();
        }

        public async Task<DriversLicenceDetailViewModel> GetDriversLicenceDetailAsync(int personalIdentifierId)
        {
            
            var result = await context.DriversLicenceEntity
               .Include(item => item.LicenceTypeGroupItemEntity)
               .Include(item => item.PersonalInformationEntity)
               .FirstOrDefaultAsync(m => m.PersonalInformationId == personalIdentifierId);

            return _mapper.Map<DriversLicenceDetailViewModel>(result);
            
            //return new DriversLicenceDetailViewModel();
        }

        public async Task Save(DriversLicenceViewModel_Finak model, OperationType operationType)
        {
            var entity = _mapper.Map<DriversLicenceEntity>(model);
            
            switch (operationType)
            {
                case OperationType.Create:

                    await AddAsync(entity);
                    break;
                case OperationType.Update:

                    entity.DateModified = DateTime.UtcNow;
                    await UpdateAsync(entity);
                    break;
            }
        }
    }
}
