using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Radzen;
using NuclearEvaluation.Server.Models;
using NuclearEvaluation.Server.Services;

namespace NuclearEvaluation.Server.Pages;

public partial class Profile
{
    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    protected TooltipService TooltipService { get; set; }

    [Inject]
    protected ContextMenuService ContextMenuService { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }

    protected string oldPassword = "";
    protected string newPassword = "";
    protected string confirmPassword = "";
    protected ApplicationUser user;
    protected string error;
    protected bool errorVisible;
    protected bool successVisible;

    [Inject]
    protected SecurityService Security { get; set; }

    protected override async Task OnInitializedAsync()
    {
        user = await Security.GetUserById($"{Security.User.Id}");
    }

    protected async Task FormSubmit()
    {
        try
        {
            await Security.ChangePassword(oldPassword, newPassword);
            successVisible = true;
        }
        catch (Exception ex)
        {
            errorVisible = true;
            error = ex.Message;
        }
    }
}