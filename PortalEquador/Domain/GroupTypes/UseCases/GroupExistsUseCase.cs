using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PortalEquador.Data;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Domain.GroupTypes.UseCases
{
    public class GroupExistsUseCase
    {
        private readonly GroupRepository _groupRepository;

        public GroupExistsUseCase(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<bool> Invoke(string description)
        {
            return await _groupRepository.GroupExists(description);
        }
    }
}
