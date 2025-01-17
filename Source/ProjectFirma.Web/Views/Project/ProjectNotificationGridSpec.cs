﻿/*-----------------------------------------------------------------------
<copyright file="ProjectNotificationGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class ProjectNotificationGridSpec : GridSpec<ProjectFirmaModels.Models.Notification>
    {
        public ProjectNotificationGridSpec(FirmaSession currentFirmaSession)
        {
            Add("Date", x => x.NotificationDate, 120);
            Add("Notification Type", x => x.NotificationType.NotificationTypeDisplayName, 140, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Notification", x => x.NotificationType.GetFullDescriptionFromProjectPerspective(), 400, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Person Notified", x => x.Person.GetFullNameFirstLastAndOrgAsUrl(currentFirmaSession), 400);
        }
    }
}
