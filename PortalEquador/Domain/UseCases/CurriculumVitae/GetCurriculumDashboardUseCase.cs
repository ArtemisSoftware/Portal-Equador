using PortalEquador.Contracts;
using PortalEquador.Domain.Models.CurriculumVitae;
using PortalEquador.Domain.Models.Document;
using PortalEquador.Domain.Repositories;

namespace PortalEquador.Domain.UseCases.CurriculumVitae
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
