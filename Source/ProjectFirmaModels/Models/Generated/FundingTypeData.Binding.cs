//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingTypeData]
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
    // Table [dbo].[FundingTypeData] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FundingTypeData]")]
    public partial class FundingTypeData : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FundingTypeData()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingTypeData(int fundingTypeDataID, int fundingTypeID, string fundingTypeDisplayName, string fundingTypeShortName, int sortOrder) : this()
        {
            this.FundingTypeDataID = fundingTypeDataID;
            this.FundingTypeID = fundingTypeID;
            this.FundingTypeDisplayName = fundingTypeDisplayName;
            this.FundingTypeShortName = fundingTypeShortName;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingTypeData(int fundingTypeID, string fundingTypeDisplayName, string fundingTypeShortName, int sortOrder) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingTypeDataID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FundingTypeID = fundingTypeID;
            this.FundingTypeDisplayName = fundingTypeDisplayName;
            this.FundingTypeShortName = fundingTypeShortName;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FundingTypeData(FundingType fundingType, string fundingTypeDisplayName, string fundingTypeShortName, int sortOrder) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingTypeDataID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FundingTypeID = fundingType.FundingTypeID;
            this.FundingType = fundingType;
            fundingType.FundingTypeDatas.Add(this);
            this.FundingTypeDisplayName = fundingTypeDisplayName;
            this.FundingTypeShortName = fundingTypeShortName;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FundingTypeData CreateNewBlank(FundingType fundingType)
        {
            return new FundingTypeData(fundingType, default(string), default(string), default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FundingTypeData).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFundingTypeDatas.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int FundingTypeDataID { get; set; }
        public int TenantID { get; set; }
        public int FundingTypeID { get; set; }
        public string FundingTypeDisplayName { get; set; }
        public string FundingTypeShortName { get; set; }
        public int SortOrder { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FundingTypeDataID; } set { FundingTypeDataID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FundingType FundingType { get; set; }

        public static class FieldLengths
        {
            public const int FundingTypeDisplayName = 100;
            public const int FundingTypeShortName = 20;
        }
    }
}