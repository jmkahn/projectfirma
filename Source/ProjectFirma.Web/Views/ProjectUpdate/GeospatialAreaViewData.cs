﻿/*-----------------------------------------------------------------------
<copyright file="LocationSimpleViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class GeospatialAreaViewData : ProjectUpdateViewData
    {
        public readonly EditProjectGeospatialAreasViewData EditProjectGeospatialAreasViewData;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly string RefreshUrl;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly GeospatialAreaType GeospatialAreaType;

        public GeospatialAreaViewData(Person currentPerson,
            Models.ProjectUpdate projectUpdate,
            EditProjectGeospatialAreasViewData editProjectGeospatialAreasViewData,
            ProjectLocationSummaryViewData projectLocationSummaryViewData, 
            GeospatialAreaValidationResult geospatialAreaValidationResult,
            UpdateStatus updateStatus, GeospatialAreaType geospatialAreaType) : base(currentPerson, projectUpdate.ProjectUpdateBatch, updateStatus, geospatialAreaValidationResult.GetWarningMessages(), geospatialAreaType.GeospatialAreaTypeNamePluralized)
        {
            EditProjectGeospatialAreasViewData = editProjectGeospatialAreasViewData;
            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshProjectGeospatialArea(projectUpdate.ProjectUpdateBatch.Project, geospatialAreaType));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdate.ProjectUpdateBatch.LocationSimpleComment, projectUpdate.ProjectUpdateBatch.IsReturned);
            GeospatialAreaType = geospatialAreaType;
        } 
    }
}