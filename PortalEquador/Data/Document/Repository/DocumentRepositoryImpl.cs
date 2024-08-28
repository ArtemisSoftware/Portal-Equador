using AutoMapper;
using PortalEquador.Data.Document.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.PersonalInformation.Repository;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.Document.Repository
{
    public class DocumentRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<DocumentEntity>(context, httpContextAccessor), IDocumentRepository
    {
        public async Task<DocumentViewModel> GetCreateModel(int id)
        {

            var documentsTypes = GroupItems(Groups.DOCUMENTS);
            
            var model = new DocumentViewModel
            {
                DocumentTypes = documentsTypes,
            };

            return model;
        }
    }
}
