﻿using NuclearEvaluation.Library.Commands;
using NuclearEvaluation.Library.Models.Views;

namespace NuclearEvaluation.Library.Interfaces;

public interface ISubSampleService
{
    Task<FilterDataResponse<SubSampleView>> GetSubSampleViews(FilterDataCommand<SubSampleView> command);
}