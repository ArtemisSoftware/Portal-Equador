﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Repositories;

namespace PortalEquador.Data.GroupTypes.Repositories
{
    public class GroupRepositoryImpl : GenericRepository<GroupEntity>, GroupRepository
    {
        private readonly IMapper _mapper;

        public GroupRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<GroupViewModel>> GetAll()
        {
            var entity = await GetAllAsync();
            var models = _mapper.Map<List<GroupViewModel>>(entity);
            return models;
        }

        public async Task<bool> GroupExists(string description)
        {
            return await context.GroupEntity.AnyAsync(item=> item.Description == description);
        }
    }
}