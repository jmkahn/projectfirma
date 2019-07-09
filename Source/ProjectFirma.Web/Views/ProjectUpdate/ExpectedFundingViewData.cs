﻿/*-----------------------------------------------------------------------
<copyright file="ExpendituresViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.ProjectFunding;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpectedFundingViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public ProjectFundingDetailViewData ProjectFundingDetailViewData { get; set; }

        public readonly string RequestFundingSourceUrl;
        public readonly ViewDataForAngularClass ViewDataForAngular;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        
        public ExpectedFundingViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ViewDataForAngularClass viewDataForAngularClass, ProjectFundingDetailViewData projectFundingDetailViewData, ProjectUpdateStatus projectUpdateStatus, ExpectedFundingValidationResult expectedFundingValidationResult)
            : base(currentPerson, projectUpdateBatch, projectUpdateStatus, expectedFundingValidationResult.GetWarningMessages(), ProjectUpdateSection.Budget.ProjectUpdateSectionDisplayName)
        {
            ViewDataForAngular = viewDataForAngularClass;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpectedFunding(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpectedFunding(projectUpdateBatch.Project));
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            ProjectFundingDetailViewData = projectFundingDetailViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.ExpectedFundingComment, projectUpdateBatch.IsReturned());
            ValidationWarnings = expectedFundingValidationResult.GetWarningMessages();
        }

        public class ViewDataForAngularClass
        {
            public readonly List<FundingSourceSimple> AllFundingSources;
            // Actually a ProjectUpdateBatchID
            public readonly int ProjectID;
            public readonly decimal EstimatedTotalCost;

            public ViewDataForAngularClass(ProjectUpdateBatch projectUpdateBatch,
                List<FundingSourceSimple> allFundingSources,
                decimal estimatedTotalCost)
            {
                AllFundingSources = allFundingSources;
                ProjectID = projectUpdateBatch.ProjectUpdateBatchID;
                EstimatedTotalCost = estimatedTotalCost;
                
            }
        }
    }
}
