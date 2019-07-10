﻿/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceBudgetsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFundingSourceBudget
{
    public class EditProjectFundingSourceBudgetViewData : FirmaUserControlViewData
    {
        public readonly List<FundingSourceSimple> AllFundingSources;
        public readonly List<ProjectSimple> AllProjects;
        public readonly int? ProjectID;
        public readonly int? FundingSourceID;
        public readonly bool FromFundingSource;

        private EditProjectFundingSourceBudgetViewData(List<ProjectSimple> allProjects,
            List<FundingSourceSimple> allFundingSources,
            int? projectID,
            int? fundingSourceID)
        {
            AllFundingSources = allFundingSources;
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            AllProjects = allProjects;
            
            var displayMode = FundingSourceID.HasValue ? EditorDisplayMode.FromFundingSource : EditorDisplayMode.FromProject;
            FromFundingSource = displayMode == EditorDisplayMode.FromFundingSource;
        }

        public EditProjectFundingSourceBudgetViewData(ProjectSimple project,
            List<FundingSourceSimple> allFundingSources)
            : this(new List<ProjectSimple> { project }, allFundingSources, project.ProjectID, null)
        {
        }

        public EditProjectFundingSourceBudgetViewData(FundingSourceSimple fundingSource, List<ProjectSimple> allProjects)
            : this(allProjects, new List<FundingSourceSimple> {fundingSource}, null, fundingSource.FundingSourceID)
        {
        }

        public enum EditorDisplayMode
        {
            FromProject,
            FromFundingSource
        }
    }
}
