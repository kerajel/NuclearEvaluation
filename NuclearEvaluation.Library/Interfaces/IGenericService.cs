﻿using NuclearEvaluation.Library.Commands;

namespace NuclearEvaluation.Library.Interfaces;

public interface IGenericService
{
    Task<FilterDataResponse<dynamic>> GetFilterOptions<T>(FilterDataCommand<T> command, string propertyName) where T : class, IIdentifiable;
}