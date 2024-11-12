using PortalEquador.Domain.MechanicalWorkshop.Scheduler;
using System;
using System.Diagnostics;

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
        }

        public static class ItemFromGroup
        {

            public static class Nationality
            {
                public static readonly int ANGOLAN = (new Item{ Debug = 3, Production = 1 }).Value;
            }

            public static class Documents
            {
                public static readonly int PROFILE_PICTURE = (new Item { Debug = 7, Production = 2 }).Value;
                public static readonly int DRIVERS_LICENCE = (new Item { Debug = 43, Production = 39 }).Value;
                public static readonly int DRIVERS_LICENCE_PROVISIONAL = (new Item { Debug = 44, Production = 69 }).Value;
             


             private static List<int> driversLicenceDocuments = new List<int>();

                static Documents()
                {
                    driversLicenceDocuments.Add(DRIVERS_LICENCE);
                    driversLicenceDocuments.Add(DRIVERS_LICENCE_PROVISIONAL);
                }

                public static List<int> GetDriversLicenceDocuments()
                {
                    return driversLicenceDocuments;
                }
            }

        }
    }
}
