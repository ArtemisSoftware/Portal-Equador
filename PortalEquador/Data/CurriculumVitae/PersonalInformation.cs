using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.CurriculumVitae
{
    public class PersonalInformation : BaseEntity
    {

        /// <summary>
        /// Numero do bilhete de identidade
        /// </summary>
        public string IdentityCard { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public DateTime DateOfBirth { get; set; }


        public int CurriculumId { get; set; }

        [ForeignKey("CurriculumId")]
        public Curriculum Curriculum { get; set; }

    }
}
