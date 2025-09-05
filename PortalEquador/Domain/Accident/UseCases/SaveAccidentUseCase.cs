using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.DriversLicence.Repository;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.Accident.UseCases
{
    public class SaveAccidentUseCase(
        IAccidentCauseRepository accidentCauseRepository,
        IAccidentRepository accidentRepository
        )
    {

        public async Task Invoke(AccidentViewModel model)
        {
            var accidentId = await accidentRepository.Save(model);

            //--accidentCauseRepository.Save(accidentId, model.GetCurrentCauses());
        }
    }
}