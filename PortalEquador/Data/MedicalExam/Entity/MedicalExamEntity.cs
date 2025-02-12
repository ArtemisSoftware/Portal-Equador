using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.MedicalExam.Entity
{
    public class MedicalExamEntity: BaseEntity
    {
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public int ExamId { get; set; }

        [ForeignKey("ExamId")]
        public GroupItemEntity ExamGroupItemEntity { get; set; }

        public string? Observation { get; set; }

        public string Extension { get; set; }
    }
}
