namespace PortalEquador.Constants
{
    public static class StringConstants
    {
        public static class Html
        {
            public const string Id = "OrderId";
        }

        public static class Display
        {
            public const string DESCRIPTION = "Descrição";
            public const string OBSERVATION = "Observação";
            public const string FULL_NAME = "Nome completo";
            public const string DRIVERS_LICENCE_TYPE = "Tipo de carta";
            public const string STATE = "Estado";
            public const string EXPIRATION_DATE = "Data de expiração";
            public const string PROVISIONAL_EXPIRATION_DATE = "Data de expiração do verbete";
            public const string PROVISIONAL_UPDATE_NUMBER = "Nº de atualizações realizadas";
            public const string REGISTER_CREATION_DATE = "Registo criado a ";
            public const string REGISTER_LAST_UPDATE_DATE = "Última atualização a ";
        }

        public static class Error
        {
            public const string EXCEEDED_MAX_CHARACTERS_LENGHT = "Excedido o numero máximo de caractéres";
            public const string MANDATORY_FIELD = "Campo obrigatório";
            public const string EXISTING_GROUP_DESCRIPTION = "A descrição já existe para o grupo especificado";
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
    }
}
