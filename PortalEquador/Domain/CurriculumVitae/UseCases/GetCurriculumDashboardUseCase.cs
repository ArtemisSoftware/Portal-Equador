using PortalEquador.Contracts;
using PortalEquador.Domain.CurriculumVitae.Repository;
using PortalEquador.Domain.CurriculumVitae.ViewModels;

namespace PortalEquador.Domain.CurriculumVitae.UseCases
{
    public class GetCurriculumDashboardUseCase
    {
        private readonly CurriculumRepository _curriculumRepository;

        public GetCurriculumDashboardUseCase(CurriculumRepository curriculumRepository)
        {
            _curriculumRepository = curriculumRepository;
        }

        public async Task<CurriculumDashboardViewModel> Invoke(int curriculumId)
        {
            return await _curriculumRepository.GetCurriculumDashboard(curriculumId);
        }
    }
}
