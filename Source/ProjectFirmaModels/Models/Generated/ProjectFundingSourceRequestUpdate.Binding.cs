//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceRequestUpdate]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[ProjectFundingSourceRequestUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectFundingSourceRequestUpdate]")]
    public partial class ProjectFundingSourceRequestUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectFundingSourceRequestUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceRequestUpdate(int projectFundingSourceRequestUpdateID, int projectUpdateBatchID, int fundingSourceID, decimal? securedAmount, decimal? unsecuredAmount) : this()
        {
            this.ProjectFundingSourceRequestUpdateID = projectFundingSourceRequestUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FundingSourceID = fundingSourceID;
            this.SecuredAmount = securedAmount;
            this.UnsecuredAmount = unsecuredAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceRequestUpdate(int projectUpdateBatchID, int fundingSourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceRequestUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FundingSourceID = fundingSourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectFundingSourceRequestUpdate(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceRequestUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectFundingSourceRequestUpdates.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.ProjectFundingSourceRequestUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectFundingSourceRequestUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource)
        {
            return new ProjectFundingSourceRequestUpdate(projectUpdateBatch, fundingSource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectFundingSourceRequestUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectFundingSourceRequestUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectFundingSourceRequestUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int FundingSourceID { get; set; }
        public decimal? SecuredAmount { get; set; }
        public decimal? UnsecuredAmount { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectFundingSourceRequestUpdateID; } set { ProjectFundingSourceRequestUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual FundingSource FundingSource { get; set; }

        public static class FieldLengths
        {

        }
    }
}