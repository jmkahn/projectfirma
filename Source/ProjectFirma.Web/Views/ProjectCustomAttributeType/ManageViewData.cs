﻿using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeType
{
    public class ManageViewData : FirmaViewData
    {
        public ProjectCustomAttributeTypeGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public string NewProjectCustomAttributeTypeUrl { get; }
        public bool HasManagePermissions { get; }

        public ManageViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage neptunePage)
            : base(currentPerson, neptunePage)
        {
            EntityName = "Attribute Type";
            PageTitle = "Manage Custom Attributes";

            NewProjectCustomAttributeTypeUrl = SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(t => t.New());
            GridSpec = new ProjectCustomAttributeTypeGridSpec(currentPerson)
            {
                ObjectNameSingular = "Attribute Type",
                ObjectNamePlural = "Attribute Types",
                SaveFiltersInCookie = true
        };

            GridName = "projectCustomAttributeTypeGrid";
            GridDataUrl = SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(tc => tc.ProjectCustomAttributeTypeGridJsonData());

            HasManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(CurrentPerson);
        }
    }
}
