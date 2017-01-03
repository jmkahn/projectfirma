﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyTierTwo : IAuditableEntity
    {
        public string DeleteUrl
        {
            get { return SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(c => c.DeleteTaxonomyTierTwo(TaxonomyTierTwoID)); }
        }

        public ICollection<Project> Projects
        {
            get { return TaxonomyTierOnes.SelectMany(x => x.Projects).ToList(); }
        }

        public string DisplayName
        {
            get { return TaxonomyTierTwoName; }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName); }
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(x => x.Detail(TaxonomyTierTwoID)); }
        }

        public string CustomizedMapUrl
        {
            get { return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.TaxonomyTierTwo, TaxonomyTierTwoID.ToString(), ProjectColorByType.ProjectStage); }
        }


        public string DefinitionAndGuidanceUrl
        {
            get { return SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(x => x.DefinitionAndGuidance(this)); }
        }

        public static bool IsTaxonomyTierTwoNameUnique(IEnumerable<TaxonomyTierTwo> taxonomyTierTwos, string taxonomyTierTwoName, int currentTaxonomyTierTwoID)
        {
            var taxonomyTierTwo = taxonomyTierTwos.SingleOrDefault(x => x.TaxonomyTierTwoID != currentTaxonomyTierTwoID && String.Equals(x.TaxonomyTierTwoName, taxonomyTierTwoName, StringComparison.InvariantCultureIgnoreCase));
            return taxonomyTierTwo == null;
        }

        public string AuditDescriptionString
        {
            get { return TaxonomyTierTwoName; }
        }

        public List<PerformanceMeasure> GetPerformanceMeasures()
        {
            var performanceMeasures = TaxonomyTierTwoPerformanceMeasures.Where(x => x.IsPrimaryTaxonomyTierTwo).OrderBy(x => x.PerformanceMeasureID).Select(x => x.PerformanceMeasure).ToList();
            return performanceMeasures;
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(string.Format("{0}", UrlTemplate.MakeHrefString(SummaryUrl, TaxonomyTierTwoName)), TaxonomyTierThreeID.ToString(), false)
            {
                ThemeColor = TaxonomyTierThree.TaxonomyTierThreeColor,
                MapUrl = CustomizedMapUrl,
                Children = TaxonomyTierOnes.Select(x => x.ToFancyTreeNode()).ToList()
            };
            return fancyTreeNode;
        }
    }
}