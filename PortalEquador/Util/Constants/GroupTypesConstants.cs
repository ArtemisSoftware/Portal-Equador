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

            public const int DOCUMENTS = 4;

            public const int MECHANICAL_SHOP_CONTRACTS = 5;
            public const int MECHANICAL_SHOP_MECHANICS = 6;
            public const int MECHANICAL_SHOP_SCHEDULES = 7;

            public const int LANGUAGES = 8;
            public const int LANGUAGE_LEVEL = 9;

            public const int COMPANIES = 10;
            public const int WORKSTATIONS = 11;
            public const int COMPETENCES = 12;

            public const int SCHOOLS = 13;
            public const int SCHOOL_COURSES = 14;
            public const int SCHOOL_DEGREES = 15;

            public const int UNIVERSITY = 16;
            public const int UNIVERSITY_COURSES = 17;
            public const int UNIVERSITY_DEGREES = 18;

            //---
            public const int DRIVERS_LICENCE = 5;
            

            public const int SCHOOL_COURSE = 8;

            public const int COMPLETNESS = 8;
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
                public static readonly int DRIVERS_LICENCE = (new Item { Debug = 7, Production = 2 }).Value;
                public static readonly int DRIVERS_LICENCE_PROVISIONAL = (new Item { Debug = 7, Production = 2 }).Value;
             


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
