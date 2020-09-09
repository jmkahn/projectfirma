﻿/*-----------------------------------------------------------------------
<copyright file="ProjectLocationDetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Organization
{
    public class MatchmakerOrganizationLocationDetailViewData : FirmaUserControlViewData
    {
        public readonly int ProjectID;
        //public readonly bool HasProjectLocationPoint;
        public readonly MapInitJson MapInitJson;
        public readonly LayerGeoJson EditableLayerGeoJson;
        //public readonly string UploadGisFileUrl;
        public readonly string MapFormID;
        public readonly string SaveFeatureCollectionUrl;
        public readonly int AnnotationMaxLength;
        public readonly string SimplePointMarkerImg;

        public MatchmakerOrganizationLocationDetailViewData(int projectID, 
                                                            MapInitJson mapInitJson, 
                                                            LayerGeoJson editableLayerGeoJson, 
                                                            //string uploadGisFileUrl, 
                                                            string mapFormID, 
                                                            string saveFeatureCollectionUrl, 
                                                            int annotationMaxLength
                                                            /*,bool hasProjectLocationPoint*/)
        {
            ProjectID = projectID;
            MapInitJson = mapInitJson;
            EditableLayerGeoJson = editableLayerGeoJson;
            //UploadGisFileUrl = uploadGisFileUrl;
            MapFormID = mapFormID;
            SaveFeatureCollectionUrl = saveFeatureCollectionUrl;
            AnnotationMaxLength = annotationMaxLength;
            //HasProjectLocationPoint = hasProjectLocationPoint;

            SimplePointMarkerImg = "https://api.tiles.mapbox.com/v3/marker/pin-s-marker+838383.png";
        }
    }
}
