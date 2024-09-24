namespace PortalEquador.Util.Constants
{
    public static class StringConstants
    {
        public static class Html
        {
            public const string Id = "OrderId";
        }

        public static class Display
        {
            // A
            public const string ADRESS = "Endereço";

            // C
            public const string CONTRACT = "Contrato";
            public const string CONTRACT_IN_USE = "Contrato associado";
            public const string COMPETENCE = "Habilitação";
            public const string CODE = "Código";
            public const string COMPANY = "Empresa";
            public const string CONTACTS = "Contactos";
            public const string COURSE = "Curso";

            // D
            public const string DEGREE = "Grau";
            public const string DATE = "Data";
            public const string DESCRIPTION = "Descrição";
            public const string DRIVERS_LICENCE_TYPE = "Tipo de carta";
            public const string DRIVERS_LICENCE = "Carta de condução";
            public const string DATE_OF_BIRTH = "Data de nascimento";
            public const string DURATION = "Duração";
            public const string DOCUMENT = "Documento";

            // I
            public const string INSTITUTION = "Instituição";

            // L
            public const string LANGUANGE = "Língua";
            public const string LICENCE_PLATE = "Matricula";

            // M
            public const string MATERNAL_LANGUANGE = "Língua materna";
            public const string MECHANIC = "Mecânico";
            public const string MODEL = "Modelo";
            public const string MODIFIED_BY = "Alterado por";
            public const string MONTHS = "Meses";
            public const string MOTHER = "Mãe";

            // O
            public const string ORAL_LEVEL = "Nível oral";

            // P
            public const string PROFESSIONAL_EXPERIENCE = "Experiência profissional";
            public const string PROFESSIONAL_COMPETENCE = "Habilitações profissionais";

            // S
            public const string SERVICE = "Serviço";
            public const string SCHEDULE = "Horário";
            public const string STATE = "Estado";
            public const string SURNAME = "Apelido";

            //  T
            public const string TELEPHONE = "Telefone";

            //  V
            public const string VEHICLE = "Veículo";

            //  W
            public const string WRITTEN_LEVEL = "Nível escrito";
            public const string WORKSTATION = "Posto";

            //  Y
            public const string YEARS = "Anos";


            public const string BENIFICIARY_NUMBER = "Nº de benificiário";


            public const string OBSERVATION = "Observação";
            public const string FULL_NAME = "Nome completo";
            public const string NATIONALITY = "Nacionalidade";
            public const string PROVINCE = "Provincia";
            public const string NEIGHBOURHOOD = "Bairro";

            public const string EMAIL = "Email";
            public const string EXPIRATION_DATE = "Data de expiração";
            public const string IDENTITY_CARD_EXPIRATION_DATE = "Data de expiração do bilhete de identidade";
            public const string PROVISIONAL_EXPIRATION_DATE = "Data de expiração do verbete";
            public const string PROVISIONAL_UPDATE_NUMBER = "Nº de atualizações realizadas";
            public const string REGISTER_CREATION_DATE = "Registo criado a ";
            public const string REGISTER_LAST_UPDATE_DATE = "Última atualização a ";
            public const string IDENTITY_CARD_NUMBER = "Nº Bilhete de identidade";
            public const string NAME = "Nome";
            public const string FATHER = "Pai";
            public const string FINANTIAL_IDENTITY = "Nif";
            public const string FILE = "Ficheiro";






        }

        public static class Error
        {
            public const string EXCEEDED_MAX_CHARACTERS_LENGHT = "Excedido o numero máximo de caractéres";
            public const string MANDATORY_FIELD = "Campo obrigatório";
            public const string EXISTING_GROUP_DESCRIPTION = "A descrição já existe para o grupo especificado";
            public const string EXISTING_IDENTITY_CARD = "O numero do bilhete de identidade já se encontra registado";
            public const string EXISTING_DOCUMENT = "O tipo de documento já se encontra registado";
            public const string MANDATORY_FILE = "A escolha de um ficheiro é obrigatória";
            public const string EXISTING_REGISTER = "O item já se encontra registado";
            public const string EXISTING_LICENCE_PLATE = "A matricula já se encontra registada";
            public const string INVALID_LICENCE_PLATE = "Matricula inválida";
            public const string EXISTING_LANGUAGE = "A lingua já se encontra registada";
            public const string INVALID_DURATION = "Duração inválida";
            public const string EXISTING_PROFESSIONAL_EXPERIENCE = "A experiência profissional já se encontra registada";
            public const string EXISTING_PROFESSIONAL_COMPETENCE = "A habilitação profissional já se encontra registada";
            public const string EXISTING_EDUCATION = "A educação já se encontra registada";
            public const string UNDECLARED_ERROR = "Ocorreu um erro ao preencher o formulário.";
            public const string EXISTING_DRIVERS_LICENCE = "A carta de condução já se encontra registada";
        }

        public static class Dates
        {
            public const string YYYY_MM_DD = "{0:yyyy-MM-dd}";
            public const string DD_MM_YYYY = "{0:dd-MM-yyyy}";

            public const string DD_MM_YYYY__HH_MM = "{0:dd-MM-yyyy HH:mm}";
        }

        public static class Lenght
        {
            public const int LENGHT_140 = 140;
        }

        public static class Alert
        {
            public const string DELETE_PROVISIONAL_DRIVERS_LICENCE = "Ao renovar a carta de condução irá eliminar o verbete caso exista.";
        }

        public static class LicenceStatus
        {
            public const string NO_EXPIRATION_DATE = "Sem data de expiração";
            public const string UPDATED = "Atualizado";
            public const string EXPIRED = "Caducada";
            public const string PROVISIONAL_UPDATED = "Verbete atualizado";
            public const string PROVISIONAL_EXPIRED = "Verbete Caducado";
        }

        public static class Controller
        {
            public const string Curriculums = "Curriculum";
            public const string DriversLicence = "DriversLicence";

            public static class Action
            {
                public const string Dashboard = "Dashboard";
                public const string Create = "Create";
            }
        }
    }
}
