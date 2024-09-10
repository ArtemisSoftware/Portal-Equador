﻿using NuGet.Packaging.Signing;
using PortalEquador.Domain.Generic;
using PortalEquador.Util;
using PortalEquador.Util.Constants;

namespace PortalEquador.Domain.Curriculum.ViewModels
{
    public class CurriculumDashboardViewModel: ViewModel
    {
        public int Id { get; set; }

        public required string FullName { get; set; }

        public bool IsPersonalInformationComplete { get; set; }

        public int TotalDocuments { get; set; }
        public int TotalLanguages { get; set; }

        public int TotalCompetences { get; set; }

        public int TotalExpertises { get; set; }

        public bool IsDriversLicenceComplete { get; set; }

        public required string ProfileImagePath { get; set; }

    }
}
