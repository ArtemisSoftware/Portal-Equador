using AutoMapper;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.MedicalExam.ViewModels;

namespace PortalEquador.Data.MedicalExam.Repository
{
    public class MedicalExamRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
    IWebHostEnvironment hostEnvironment
    )
        : GenericRepository<MedicalExamEntity>(context, httpContextAccessor), IMedicalExamRepository
    {
        public async Task<List<MedicalExamViewModel>> GetAll(int personalInformationId)
        {
            var list = new List<MedicalExamViewModel>();
            list.Add(
                new MedicalExamViewModel {
                    Id = 1,
                    Date =  DateTime.Now,
                    PersonaInformationId = 1,
                    Extension = "jpg",
                    FullName = "The guy",
                    Exam = new GroupItemViewModel
                    {
                        Id = 1,
                        Description = "EXAM1"
                    }
                }
                );
            return list; 
        }
    }
}
