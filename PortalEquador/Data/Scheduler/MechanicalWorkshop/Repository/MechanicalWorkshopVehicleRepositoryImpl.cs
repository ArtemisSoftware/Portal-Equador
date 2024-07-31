using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Contracts;
using PortalEquador.Data.Scheduler.Entities;
using PortalEquador.Data.Scheduler.MechanicalWorkshop.Entities;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.Repository;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels;
using PortalEquador.Repositories;

namespace PortalEquador.Data.Scheduler.MechanicalWorkshop.Repository
{
    public class MechanicalWorkshopVehicleRepositoryImpl : GenericRepository<MechanicalWorkshopVehicleRepositoryImpl>, MechanicalWorkshopVehicleRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public MechanicalWorkshopVehicleRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            _mapper = mapper;
        }

        public Task<MechanicalWorkshopVehicleEntity> AddAsync(MechanicalWorkshopVehicleEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<MechanicalWorkshopSchedulerViewModel>> GetAll(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<DocumentViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save(MechanicalWorkshopSchedulerViewModel item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MechanicalWorkshopVehicleEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<List<MechanicalWorkshopVehicleEntity>> IGenericRepository<MechanicalWorkshopVehicleEntity>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<MechanicalWorkshopVehicleEntity> IGenericRepository<MechanicalWorkshopVehicleEntity>.GetAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}