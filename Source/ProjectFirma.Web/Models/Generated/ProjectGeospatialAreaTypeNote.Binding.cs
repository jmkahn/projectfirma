//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaTypeNote]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ProjectGeospatialAreaTypeNote]")]
    public partial class ProjectGeospatialAreaTypeNote : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectGeospatialAreaTypeNote()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectGeospatialAreaTypeNote(int projectGeospatialAreaTypeNoteID, int projectID, int geospatialAreaTypeID, string notes) : this()
        {
            this.ProjectGeospatialAreaTypeNoteID = projectGeospatialAreaTypeNoteID;
            this.ProjectID = projectID;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
            this.Notes = notes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectGeospatialAreaTypeNote(int projectID, int geospatialAreaTypeID, string notes) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectGeospatialAreaTypeNoteID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
            this.Notes = notes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectGeospatialAreaTypeNote(Project project, GeospatialAreaType geospatialAreaType, string notes) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectGeospatialAreaTypeNoteID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectGeospatialAreaTypeNotes.Add(this);
            this.GeospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            this.GeospatialAreaType = geospatialAreaType;
            geospatialAreaType.ProjectGeospatialAreaTypeNotes.Add(this);
            this.Notes = notes;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectGeospatialAreaTypeNote CreateNewBlank(Project project, GeospatialAreaType geospatialAreaType)
        {
            return new ProjectGeospatialAreaTypeNote(project, geospatialAreaType, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectGeospatialAreaTypeNote).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            DeleteFull(HttpRequestStorage.DatabaseEntities);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            dbContext.AllProjectGeospatialAreaTypeNotes.Remove(this);
        }

        [Key]
        public int ProjectGeospatialAreaTypeNoteID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public int GeospatialAreaTypeID { get; set; }
        public string Notes { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectGeospatialAreaTypeNoteID; } set { ProjectGeospatialAreaTypeNoteID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual GeospatialAreaType GeospatialAreaType { get; set; }

        public static class FieldLengths
        {
            public const int Notes = 4000;
        }
    }
}