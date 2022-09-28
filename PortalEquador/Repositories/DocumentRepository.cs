using PortalEquador.Contracts;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Models.CurriculumVitae;

namespace PortalEquador.Repositories
{
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        private readonly ApplicationDbContext context;

        public DocumentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<DocumentsViewModel>> GetAllPersonalDocAsync()
        {
            var result = await (
                from personal in context.PersonalInformation
                join document in context.Documents on personal.CurriculumId equals document.CurriculumId into docs_table
                from personalDocuments in docs_table.DefaultIfEmpty()
                group personalDocuments by new { personal.Id, personal.FirstName, personal.LastName, personal.CurriculumId } into personalDocumentsGrouped
                
                select new DocumentsViewModel
                {
                    Id = personalDocumentsGrouped.Key.Id,
                    CurriculumId = personalDocumentsGrouped.Key.CurriculumId,
                    FullName = personalDocumentsGrouped.Key.FirstName + " " + personalDocumentsGrouped.Key.LastName,
                    NumberOfDocuments = personalDocumentsGrouped.Count(x => x.GroupItemId != null)
                }
             )
             .ToListAsync();

            return result;  
        }

    }
}
