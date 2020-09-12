using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.Services;
using wikibellum.App.Services.Interfaces;
using wikibellum.Entities.Models.Units;

namespace wikibellum.App.Components
{
    public partial class AddUnitAssetDialog : ComponentBase
    {
        [Inject]
        private IClassificationDataService ClassificationDataService { get; set; }
        [Inject]
        private IBranchDataService BranchDataService { get; set; }
        [Inject]
        private IConditionDataService ConditionDataService { get; set; }

        private Asset Asset { get; set; }
        private bool ShowDialog { get; set; }
        private Branch CurrentBranch { get; set; }
        private List<Classification> CurrentBranchClassifications { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Parameter]
        public EventCallback<Asset> AddAssetEventCallback { get; set; }

        private List<Classification> _classifications;
        private List<Branch> _branches;
        private List<Condition> _conditions;

        protected async override Task OnInitializedAsync()
        {
            _classifications = (await ClassificationDataService.GetAll()).ToList();
            _conditions = (await ConditionDataService.GetAll()).ToList();
            _branches = (await BranchDataService.GetAll()).ToList();
            CurrentBranch = _branches[0];
            CurrentBranchClassifications = _classifications.Where(c => c.BranchId == CurrentBranch.BranchId).ToList();

            await base.OnInitializedAsync();
        }


        public void SetBranch(Branch branch)
        {
            CurrentBranch = branch;
            CurrentBranchClassifications = _classifications.Where(c => c.BranchId == CurrentBranch.BranchId).ToList();
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
            Asset.ClassificationId = Int32.Parse(Asset.ClassificationIdString);
            if (Asset.AssetType == AssetType.Loss)
            {
                Asset.ConditionId = Int32.Parse(Asset.ConditionIdString);
                Asset.Condition = _conditions.FirstOrDefault(c => c.ConditionId == Asset.ConditionId);
            }
            Asset.Classification = _classifications.FirstOrDefault(c => c.ClassificationId == Asset.ClassificationId);
            ShowDialog = false;
            await AddAssetEventCallback.InvokeAsync(Asset);
            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }

}
