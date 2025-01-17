﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.User
{
    public class DetailViewData : FirmaViewData
    {
        public Person Person { get; }
        public string EditPersonOrganizationPrimaryContactUrl { get; }
        public string IndexUrl { get; }
        public string EditDetailBasicsUrl { get; }
        public string ChangePasswordUrl { get; }

        public bool UserHasPersonViewPermissions { get; }
        public bool UserHasPersonManagePermissions { get; }
        public bool UserHasAdminPermissions { get; }
        public bool CurrentPersonCanBeImpersonatedByCurrentUser { get; }
        public bool IsViewingSelf { get; }
        public Project.UserProjectGridSpec UserProjectGridSpec { get; }
        public string BasicProjectInfoGridName { get; }
        public string BasicProjectInfoGridDataUrl { get; }
        public UserNotificationGridSpec UserNotificationGridSpec { get; }
        public string UserNotificationGridName { get; }
        public string UserNotificationGridDataUrl { get; }
        public string ActivateInactivateUrl { get; }
        public bool TenantHasStewardshipAreas { get; }

        public HtmlString EditRolesLink { get; }

        public DetailViewData(FirmaSession currentFirmaSession,
            Person personToView,
            Project.UserProjectGridSpec userProjectGridSpec,
            string basicProjectInfoGridName,
            string basicProjectInfoGridDataUrl,
            UserNotificationGridSpec userNotificationGridSpec,
            string userNotificationGridName,
            string userNotificationGridDataUrl,
            string activateInactivateUrl)
            : base(currentFirmaSession)
        {
            Person = personToView;
            PageTitle = personToView.GetFullNameFirstLast() + (!personToView.IsActive ? " (inactive)" : string.Empty);
            EntityName = "User";

            EditPersonOrganizationPrimaryContactUrl = SitkaRoute<PersonOrganizationController>.BuildUrlFromExpression(c => c.EditPersonOrganizationPrimaryContacts(personToView));
            IndexUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.Index());
            if (FirmaWebConfiguration.AuthenticationType == AuthenticationType.LocalAuth)
            {
                EditDetailBasicsUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.EditUser(personToView.PrimaryKey));
                ChangePasswordUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.ChangePassword(personToView.PrimaryKey));
            }

            // And again, here we should take Current FirmaSession, not the person. -- SLG & SG
            UserHasPersonViewPermissions = new UserViewFeature().HasPermission(currentFirmaSession, personToView).HasPermission;
            UserHasPersonManagePermissions = new UserEditFeature().HasPermissionByFirmaSession(currentFirmaSession);
            UserHasAdminPermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);

            CurrentPersonCanBeImpersonatedByCurrentUser = new FirmaImpersonateUserFeature().HasPermission(currentFirmaSession, personToView).HasPermission;

            IsViewingSelf = !currentFirmaSession.IsAnonymousUser() && currentFirmaSession.PersonID == personToView.PersonID;
            EditRolesLink = UserHasAdminPermissions
                ? ModalDialogFormHelper.MakeEditIconLink(SitkaRoute<UserController>.BuildUrlFromExpression(c => c.EditRoles(personToView)),
                    $"Edit Roles for User - {personToView.GetFullNameFirstLast()}",
                    true)
                : new HtmlString(string.Empty);

            UserProjectGridSpec = userProjectGridSpec;
            BasicProjectInfoGridName = basicProjectInfoGridName;
            BasicProjectInfoGridDataUrl = basicProjectInfoGridDataUrl;

            UserNotificationGridSpec = userNotificationGridSpec;
            UserNotificationGridName = userNotificationGridName;
            UserNotificationGridDataUrl = userNotificationGridDataUrl;
            ActivateInactivateUrl = activateInactivateUrl;

            TenantHasStewardshipAreas = MultiTenantHelpers.GetProjectStewardshipAreaType() != null;
        }

        
    }
}
