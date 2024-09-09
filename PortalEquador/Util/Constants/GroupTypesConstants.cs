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

            //---
            public const int DRIVERS_LICENCE = 5;
            public const int COMPETENCES = 6;
            public const int COMPANIES = 7;
            public const int WORKSTATIONS = 8
                ;
            public const int SCHOOL = 8;
            public const int SCHOOL_LEVEL = 8;
            public const int SCHOOL_COURSE = 8;
            public const int UNIVERSITY = 8;
            public const int UNIVERSITY_LEVEL = 8;
            public const int UNIVERSITY_COURSE = 8;
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
                //public const int DRIVERS_LICENCE = 7;
                //public const int PROVISIONAL_DRIVERS_LICENCE = 10;
            }

        }
    }
}
