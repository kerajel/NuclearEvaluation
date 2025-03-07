﻿using Kerajel.Primitives.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using NuclearEvaluation.Library.Enums;
using NuclearEvaluation.Library.Interfaces;
using NuclearEvaluation.Server.Models.Settings;
using NuclearEvaluation.Server.Models.Upload;
using NuclearEvaluation.Server.Shared.Grids;
using NuclearEvaluation.Server.Shared.Misc;
using Radzen;

namespace NuclearEvaluation.Server.Shared.DataManagement;

public partial class StemPreview : IDisposable
{
    [Parameter]
    public string ComponentId { get; set; } = Guid.NewGuid().ToString();

    [Inject]
    protected IJSRuntime JsRuntime { get; set; } = null!;

    [Inject]
    protected IStemPreviewService StemPreviewService { get; set; } = null!;

    [Inject]
    protected ILogger<StemPreview> Logger { get; set; } = null!;

    [Inject]
    protected DialogService DialogService { get; set; } = null!;

    [Inject]
    protected IOptions<StemSettings> StemSettingsOptions { get; set; } = null!;

    protected readonly Guid sessionId = Guid.NewGuid();
    protected StemPreviewEntryGrid stemPreviewEntryGrid = null!;

    List<UploadedFile> files = [];

    private InputFile fileInput = null!;
    private StemSettings stemSettings = null!;

    protected override async Task OnInitializedAsync()
    {
        stemSettings = StemSettingsOptions.Value;
    }

    private async Task HandleBeforeInternalNavigation(LocationChangingContext context)
    {
        bool hasInProgressFiles = files.Any(
            x => x.Status == FileStatus.Uploading
                || x.Status == FileStatus.Uploaded);

        if (hasInProgressFiles)
        {
            bool? userConfirm = await DialogService.Confirm(
                  "You have a current STEM preview that would be lost if you leave. Are you sure?",
                  "Confirm navigation",
                  Dialogs.YesNoConfirmOptions);

            if (userConfirm == false)
            {
                context.PreventNavigation();
            }
        }
    }

    private async Task OnInputFileChange(InputFileChangeEventArgs e)
    {
        List<IBrowserFile> newlySelectedFiles = new(e.GetMultipleFiles());

        files = files.Where(x => x.Status != FileStatus.Pending).ToList();

        foreach (IBrowserFile file in newlySelectedFiles)
        {
            if (file.Size <= stemSettings.MaxPreviewFileSizeMb)
            {
                UploadedFile newFile = new()
                {
                    BrowserFile = file,
                    Status = FileStatus.Pending,
                };
                files.Add(newFile);
            }
            else
            {
                UploadedFile newFile = new()
                {
                    BrowserFile = file,
                    Status = FileStatus.UploadError,
                    ErrorMessage = $"Size exceeds {stemSettings.MaxPreviewFileSizeMb:F2} mb",
                };
                files.Add(newFile);
            }
        }

        files = new(files);

        await InvokeAsync(StateHasChanged);
        await Task.Yield();
    }

    private async Task ProcessUpload()
    {
        UploadedFile[] pendingFiles = files
              .Where((UploadedFile f) => f.Status == FileStatus.Pending)
              .ToArray();

        foreach (UploadedFile file in pendingFiles)
        {
            if (file.Status != FileStatus.Pending)
            {
                continue;
            }

            IBrowserFile browserFile = file.BrowserFile;
            file.Status = FileStatus.Uploading;

            await InvokeAsync(StateHasChanged);
            await Task.Yield();

            await Task.Run(async () =>
            {
                try
                {
                    using Stream stream = browserFile.OpenReadStream(browserFile.Size);
                    OperationResult result = await StemPreviewService.UploadStemPreviewFile(
                          sessionId,
                          stream,
                          file.Id,
                          browserFile.Name,
                          file.FileCancellationTokenSource.Token
                    );

                    file.Status = result.Succeeded ? FileStatus.Uploaded : FileStatus.UploadError;

                    await InvokeAsync(StateHasChanged);
                    await Task.Yield();

                    if (!result.Succeeded)
                    {
                        file.ErrorMessage = result.ErrorMessage;
                    }
                    else
                    {
                        await InvokeAsync(stemPreviewEntryGrid.Refresh);
                    }
                }
                catch (Exception ex)
                {
                    file.Status = FileStatus.UploadError;
                    file.ErrorMessage = ex.Message;
                }
                finally
                {
                    await InvokeAsync(StateHasChanged);
                    await Task.Yield();
                }
            });

            _ = await StemPreviewService.RefreshIndexes(sessionId);
        }
    }

    private async Task RemoveFile(UploadedFile file)
    {
        if (file.Status == FileStatus.Uploaded || file.Status == FileStatus.Uploading)
        {
            bool? confirmDelete = await DialogService.Confirm(
                $"Are you sure you want to delete '{file.BrowserFile.Name}'?",
                "Confirm Delete",
                Dialogs.YesNoConfirmOptions
            );

            if (confirmDelete != true)
            {
                return;
            }
        }

        file.Status = FileStatus.Deleting;

        await InvokeAsync(StateHasChanged);
        await Task.Yield();

        if (file.Status == FileStatus.Uploading)
        {
            await file.FileCancellationTokenSource.CancelAsync();
        }

        files.Remove(file);
        files = new(files);

        await StemPreviewService.DeleteFileData(sessionId, file.Id);
        await stemPreviewEntryGrid.Refresh();

        file.Status = FileStatus.Removed;

        await InvokeAsync(StateHasChanged);
        await Task.Yield();
    }

    private async Task TriggerFileInputClick()
    {
        await JsRuntime.InvokeVoidAsync("clickElement", fileInput.Element);
    }

    public void Dispose()
    {
        _ = StemPreviewService.DisposeAsync();
        GC.SuppressFinalize(this);
    }
}