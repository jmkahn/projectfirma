﻿function filterYearOptions(min, max, yearSelect) {
    var selectedYear = yearSelect.val();

    yearSelect.children('option:not(:first)').remove();

    for (var year = min; year <= max; year++) {
        yearSelect.append(new Option(year, year));
    }

    if (min <= selectedYear && selectedYear <= max) {
        yearSelect.val(selectedYear);
    }
}

// Setup automatic constraining of project year selection inputs to valid years only
function initializeYearConstraining(planningYearInputId,
    implementationYearId, implementationMinYear, implementationMaxYear, 
    completionYearId, completionMinYear, completionMaxYear) {

    function constrainYearOptions() {
        var designStartSelect = jQuery("#" + planningYearInputId);
        var implementationStartSelect = jQuery("#" + implementationYearId);
        var completedSelect = jQuery("#" + completionYearId);

        var minImplementationYear = Math.max(implementationMinYear, designStartSelect.val());
        filterYearOptions(minImplementationYear, implementationMaxYear, implementationStartSelect);

        var minCompletionYear = Math.max(completionMinYear, minImplementationYear, implementationStartSelect.val());
        filterYearOptions(minCompletionYear, completionMaxYear, completedSelect);
    }

    constrainYearOptions();

    jQuery("#" + planningYearInputId).on("input", () => constrainYearOptions());
    jQuery("#" + implementationYearId).on("input", () => constrainYearOptions());
    jQuery("#" + completionYearId).on("input", () => constrainYearOptions());
}