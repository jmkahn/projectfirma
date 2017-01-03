﻿using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureGridSpec : GridSpec<Models.PerformanceMeasure>
    {
        public PerformanceMeasureGridSpec()
        {
            Add("#", a => a.PerformanceMeasureID, 30);
            Add("PerformanceMeasure Name", a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.PerformanceMeasureDisplayName), 300, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.MeasurementUnit.ToGridHeaderString("Unit"), a => a.MeasurementUnitType.MeasurementUnitTypeDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Type",
                a => a.PerformanceMeasureType.PerformanceMeasureTypeDisplayName,
                60,
                DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Definition", a => a.PerformanceMeasureDefinition, 400, DhtmlxGridColumnFilterType.Html);
            Add("Simple Description",
                a => a.PerformanceMeasurePublicDescriptionHtmlString ?? new HtmlString(string.Empty),
                400,
                DhtmlxGridColumnFilterType.Html);
        }
    }
}