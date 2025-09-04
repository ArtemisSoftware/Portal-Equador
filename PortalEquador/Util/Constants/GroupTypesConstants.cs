namespace PortalEquador.Util.Constants
{
    public static class GroupTypesConstants
    {
        private class Item
        {

            public int Debug { get; set; }
            public int Production { get; set; }

            public int Value
            {
                get
                {
                    if (AppConstants.ENVIRONMENT == AppConstants.DEBUG)
                    {
                        return Debug;
                    }
                    else {
                        return Production;
                    }
                }
            }

        }


        public static class Groups
        {

            public const int NATIONALITY = 1;
            public const int PROVINCE = 2;
            public const int NEIGHBOURHOOD = 3;

            public static readonly int DOCUMENTS = (new Item { Debug = 4, Production = 4 }).Value;

            public const int MECHANICAL_SHOP_CONTRACTS = 5;
            public const int MECHANICAL_SHOP_MECHANICS = 6;
            public const int MECHANICAL_SHOP_SCHEDULES = 7;

            public const int LANGUAGES = 8;
            public const int LANGUAGE_LEVEL = 9;

            public static readonly int COMPANIES = (new Item { Debug = 10, Production = 14 }).Value;
            public static readonly int WORKSTATIONS = (new Item { Debug = 11, Production = 18 }).Value;
            public static readonly int COMPETENCES = (new Item { Debug = 12, Production = 11 }).Value;

            public static readonly int SCHOOLS = (new Item { Debug = 13, Production = 15 }).Value;
            public static readonly int SCHOOL_COURSES = (new Item { Debug = 14, Production = 12 }).Value;
            public static readonly int SCHOOL_DEGREES = (new Item { Debug = 15, Production = 16 }).Value;

            public static readonly int UNIVERSITY = (new Item { Debug = 16, Production = 19 }).Value;
            public static readonly int UNIVERSITY_COURSES = (new Item { Debug = 17, Production = 13 }).Value;
            public static readonly int UNIVERSITY_DEGREES = (new Item { Debug = 18, Production = 17 }).Value;

            public static readonly int DRIVERS_LICENCE = (new Item { Debug = 19, Production = 10 }).Value;

            public static readonly int CAR_WASH_SCHEDULES = (new Item { Debug = 20, Production = 21 }).Value;
            public static readonly int WASH_LANE = (new Item { Debug = 21, Production = 22 }).Value;

            public static readonly int EXAM = (new Item { Debug = 22, Production = 23 }).Value;
            public static readonly int TRAINNING = (new Item { Debug = 23, Production = 24 }).Value;
            public static readonly int ACCIDENT_LEVEL = (new Item { Debug = 24, Production = 26 }).Value;
            public static readonly int NOTIFICATIONS = (new Item { Debug = 25, Production = 25 }).Value;
            public static readonly int ALCOOL_TEST_RESULT = (new Item { Debug = 26, Production = 28 }).Value;

            public static readonly int CONTRACT_STATE = (new Item { Debug = 27, Production = 30 }).Value;
            public static readonly int RESIGNATION_REASONS = (new Item { Debug = 28, Production = 31 }).Value;


            public static readonly int AGENCY = (new Item { Debug = 29, Production = 35 }).Value;
            public static readonly int EXAM_RESULT = (new Item { Debug = 30, Production = 36 }).Value;

            public static readonly int CITIES = (new Item { Debug = 31, Production = 36 }).Value;
            public static readonly int ACCIDENT_CAUSES = (new Item { Debug = 32, Production = 36 }).Value;
            public static readonly int ESTIMATED_VALUE = (new Item { Debug = 33, Production = 36 }).Value;
            public static readonly int OCORRED_ACCIDENT_LEVEL = (new Item { Debug = 34, Production = 36 }).Value;
        }

        public static class ItemFromGroup
        {
            public static class Trainning
            {
                public static readonly int DEFENSIVE_DRIVING = (new Item { Debug = 59, Production = 1 }).Value; //--299 356
            }

            public static class Nationality
            {
                public static readonly int ANGOLAN = (new Item{ Debug = 3, Production = 1 }).Value;
            }

            public static class DisciplinaryNotification
            {
                public static readonly int ALCOOL = (new Item { Debug = 63, Production = 309 }).Value;
                public static readonly int ACCIDENT = (new Item { Debug = 70, Production = 316 }).Value;
            }

            public static class AlcoolTestResults
            {
                public static readonly int POSITIVE = (new Item { Debug = 68, Production = 319 }).Value;
            }

            public static class ContractStates
            {
                public static readonly int CONTRACTED = (new Item { Debug = 71, Production = 337 }).Value;
                public static readonly int FIRED = (new Item { Debug = 72, Production = 338 }).Value;
            }

            public static class Documents
            {
                public static readonly int PROFILE_PICTURE = (new Item { Debug = 7, Production = 2 }).Value;
                public static readonly int IDENTIFICATION = (new Item { Debug = 7, Production = 38 }).Value;
                public static readonly int DRIVERS_LICENCE = (new Item { Debug = 43, Production = 39 }).Value;
                public static readonly int DRIVERS_LICENCE_PROVISIONAL = (new Item { Debug = 44, Production = 69 }).Value;
                public static readonly int MEDICAL_EXAM = (new Item { Debug = 65, Production = 296 }).Value;
                public static readonly int TRAINNIG = (new Item { Debug = 66, Production = 298 }).Value;
                public static readonly int DISCIPLINARY_NOTIFICATION = (new Item { Debug = 67, Production = 297 }).Value;



                private static List<int> driversLicenceDocuments = new List<int>();
                private static List<int> contractDocuments = new List<int>();
                private static List<int> generalDocuments = new List<int>();

                static Documents()
                {
                    generalDocuments.Add(PROFILE_PICTURE);
                    generalDocuments.Add(IDENTIFICATION);
                    generalDocuments.Add(DRIVERS_LICENCE);
                    generalDocuments.Add(DRIVERS_LICENCE_PROVISIONAL);

                    driversLicenceDocuments.Add(DRIVERS_LICENCE);
                    driversLicenceDocuments.Add(DRIVERS_LICENCE_PROVISIONAL);

                    contractDocuments.Add(MEDICAL_EXAM);
                    contractDocuments.Add(TRAINNIG);
                    contractDocuments.Add(DISCIPLINARY_NOTIFICATION);
                }

                public static List<int> GetDriversLicenceDocuments()
                {
                    return driversLicenceDocuments;
                }

                public static List<int> GetContractDocuments()
                {
                    return contractDocuments;
                }

                public static List<int> GetGeneralDocuments()
                {
                    return generalDocuments;
                }
            }

        }
    }
}
