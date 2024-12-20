﻿using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Util;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;

namespace PortalEquador.Domain.DriversLicence.UseCases
{
    public class GetDriversLicenceDetailUseCase(IDriversLicenceRepository driversLicenceRepository, IDocumentRepository documentRepository)
    {
        public async Task<DriversLicenceDetailViewModel> Invoke(int id)
        {
            var model = await driversLicenceRepository.GetDriversLicenceDetail(id);
            model.Documents = await documentRepository.GetDocumentByParentId(model.Id, Documents.GetDriversLicenceDocuments());
            return model;
        }
    }
}
