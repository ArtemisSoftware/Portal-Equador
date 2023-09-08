using AutoMapper;
using PortalEquador.Constants;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Domain.PersonalInformation.UseCases
{
    public class SavePersonalInformationUseCase
    {
        private readonly PersonalInformationRepository _personalInformationRepository;
        private readonly IMapper _mapper;

        public SavePersonalInformationUseCase(
            PersonalInformationRepository personalInformationRepositor,
            IMapper mapper)
        {
            _personalInformationRepository = personalInformationRepositor;
            _mapper = mapper;
        }

        public async Task Invoke(PersonalInformationViewModel model, OperationType operationType)
        {
            PersonalInformationEntity entity = _mapper.Map<PersonalInformationEntity>(model);

            if(entity.NationalityId != ItemFromGroup.Nationality.ANGOLAN)
            {
                entity.ProvinceId = null;
            }
           
            switch (operationType)
            {
                case OperationType.Create:

                    await _personalInformationRepository.AddAsync(entity);
                    break;
                case OperationType.Update:

                    entity.DateModified = DateTime.UtcNow;
                    await _personalInformationRepository.UpdateAsync(entity);
                    break;
            }
        }
    }
}
