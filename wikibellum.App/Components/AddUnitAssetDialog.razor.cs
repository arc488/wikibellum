using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.Services;
using wikibellum.Entities.Models.Units;

namespace wikibellum.App.Components
{
    public partial class AddUnitAssetDialog
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        public Asset Asset { get; set; }
        public bool ShowDialog { get; set; }
        public ForceType SelectedForceType { get; set; } = ForceType.Land;

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Parameter]
        public EventCallback<Asset> AddAssetEventCallback { get; set; }

        public int participantId { get; set; }

        public void SetForceType(ForceType forceType)
        {
            SelectedForceType = forceType;
            StateHasChanged();
        }

        public void Show(AssetType assetType)
        {
            ResetDialog(assetType);
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog(AssetType assetType)
        {
            Asset = new Asset()
            {
                AssetType = assetType
            };
        }

        protected async Task HandleValidSubmit()
        {
            //await EmployeeDataService.AddEmployee(Employee);
            ShowDialog = false;
            await AddAssetEventCallback.InvokeAsync(Asset);
            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }

    public enum ForceType
    {
        Land,
        Naval,
        Air
    }
}
