﻿namespace ProjectFirmaModels.Models
{
    public partial class ProjectUpdateSection
    {
        public abstract bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus);
    }

    public partial class ProjectUpdateSectionBasics
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsBasicsUpdated;
        }
    }

    public partial class ProjectUpdateSectionCustomAttributes
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsCustomAttributesUpdated;
        }
    }

    public partial class ProjectUpdateSectionClassifications
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsClassificationsUpdated;
        }
    }

    public partial class ProjectUpdateSectionLocationSimple
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsLocationSimpleUpdated;
        }
    }

    public partial class ProjectUpdateSectionLocationDetailed
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsLocationDetailUpdated;
        }
    }

    public partial class ProjectUpdateSectionReportedAccomplishments
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsReportedPerformanceMeasuresUpdated;
        }
    }

    public partial class ProjectUpdateSectionExpenditures
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsExpendituresUpdated;
        }
    }

    public partial class ProjectUpdateSectionPhotos
    {        
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsPhotosUpdated;
        }
    }

    public partial class ProjectUpdateSectionExternalLinks
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsExternalLinksUpdated;
        }
    }

    public partial class ProjectUpdateSectionAttachmentsAndNotes
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsNotesUpdated;
        }
    }

    public partial class ProjectUpdateSectionOrganizations
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsOrganizationsUpdated;
        }
    }

    public partial class ProjectUpdateSectionContacts
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsContactsUpdated;
        }
    }

    public partial class ProjectUpdateSectionBudget
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsBudgetsUpdated;
        }
    }

    public partial class ProjectUpdateSectionExpectedAccomplishments
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsExpectedPerformanceMeasuresUpdated;
        }
    }

    public partial class ProjectUpdateSectionTechnicalAssistanceRequests
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsTechnicalAssistanceRequestsUpdated;
        }
    }

    public partial class ProjectUpdateSectionBulkSetSpatialInformation
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            return projectUpdateStatus.IsBulkSetSpatialInformationUpdated;
        }
    }

    public partial class ProjectUpdateSectionPartnerFinder
    {
        public override bool SectionIsUpdated(ProjectUpdateStatus projectUpdateStatus)
        {
            // Has no saved values, so never updated.
            return false;
        }
    }
}