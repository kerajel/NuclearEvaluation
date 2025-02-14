﻿using LinqToDB;
using LinqToDB.Data;
using LinqToDB.EntityFrameworkCore;
using NuclearEvaluation.Library.Interfaces;
using NuclearEvaluation.Library.Models.DataManagement;
using NuclearEvaluation.Server.Data;

namespace NuclearEvaluation.Server.Services;

public class TempTableService : DbServiceBase, ITempTableService
{
    const TableOptions tableOptions = TableOptions.IsGlobalTemporaryStructure;

    readonly List<string> usedTableNames = [];

    public TempTableService(NuclearEvaluationServerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<string> CreateTempTable(string? tableName = default)
    {
        tableName = tableName ?? $"##{Guid.NewGuid()}";
        _ = await CreateTable<StemPreviewEntry>(tableName);
        usedTableNames.Add(tableName);
        return tableName;
    }

    public async Task BulkCopyInto<T>(string tableName, IEnumerable<T> entries) where T : class
    {
        BulkCopyOptions options = new()
        {
            TableName = tableName,
            TableOptions = TableOptions.IsGlobalTemporaryStructure,
        };
        using DataConnection dataConnection = _dbContext.CreateLinqToDBConnection();
        await dataConnection.BulkCopyAsync(options, entries);
    }

    private async Task<ITable<T>> CreateTable<T>(string tableName) where T : class
    {
        DataConnection dataConnection = _dbContext.CreateLinqToDBConnection();
        return await dataConnection.CreateTableAsync<T>(
            tableName: tableName,
            tableOptions: tableOptions);
    }

    public void Dispose()
    {
        if (usedTableNames.Count != 0)
        {
            using DataConnection dc = _dbContext.CreateLinqToDBConnection();
            foreach (string tableName in usedTableNames)
            {
                dc.DropTable<object>(tableName: tableName, tableOptions: tableOptions);

            }
        }
    }
}