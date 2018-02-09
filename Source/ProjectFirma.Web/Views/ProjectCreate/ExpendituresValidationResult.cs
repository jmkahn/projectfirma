﻿/*-----------------------------------------------------------------------
<copyright file="ExpendituresValidationResult.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpendituresValidationResult
    {
        private readonly List<string> _warningMessages;

        public ExpendituresValidationResult(Dictionary<Models.FundingSource, HashSet<int>> missingFundingSourceYears)
            : this(missingFundingSourceYears, new List<int>())
        {
        }

        public ExpendituresValidationResult(List<int> missingYears)
            : this(new Dictionary<Models.FundingSource, HashSet<int>>(), missingYears)
        {
        }

        public ExpendituresValidationResult(Dictionary<Models.FundingSource, HashSet<int>> missingFundingSourceYears, List<int> missingYears)
        {
            _warningMessages = new List<string>();
            if (missingYears.Any())
            {
                _warningMessages.Add($"Missing Expenditures for {string.Join(", ", missingYears)}");
            }

            if (missingFundingSourceYears.Any())
            {
                _warningMessages.AddRange(
                    missingFundingSourceYears.Select(
                        missingFundingSourceYear =>
                            $"Missing Expenditures for {Models.FieldDefinition.FundingSource.GetFieldDefinitionLabel()} '{missingFundingSourceYear.Key.DisplayName}' for the following years: {string.Join(", ", missingFundingSourceYear.Value)}").ToList());
            }
        }

        public ExpendituresValidationResult(string customErrorMessage)
        {
            _warningMessages = new List<string> {customErrorMessage};
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}