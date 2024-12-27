﻿using NuclearEvaluation.Library.Commands;
using NuclearEvaluation.Library.Models.Views;
using NuclearEvaluation.Server.Shared.Grids;

namespace NuclearEvaluation.Server.Shared.DataManagement;

public partial class DataManagementTabs
{
    protected int _currentTabIndex = 0;
    protected SeriesCountsGrid? _seriesCountsGrid;

    async Task OnSeriesSetChange(FilterDataCommand<SeriesView> command)
    {
        if (_seriesCountsGrid != null)
            await _seriesCountsGrid.RefreshSummaryData(command);
    }
}