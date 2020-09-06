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
    public partial class AddUnitAssetDialog
    {
        [Inject]
        public IClassificationDataService ClassificationDataService { get; set; }
        [Inject]
        public IBranchDataService BranchDataService { get; set; }
        [Inject]
        public IConditionDataService ConditionDataService { get; set; }

        public Asset Asset { get; set; }
        public bool ShowDialog { get; set; }
        public ForceType SelectedForceType { get; set; } = ForceType.Land;
        public Branch CurrentBranch { get; set; }
        public List<Classification> CurrentBranchClassifications { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Parameter]
        public EventCallback<Asset> AddAssetEventCallback { get; set; }

        public int participantId { get; set; }
        private List<Classification> _classifications;
        private List<Branch> _branches;
        private List<Condition> _conditions;

        protected async override Task OnInitializedAsync()
        {
            _classifications = (await ClassificationDataService.GetAll()).ToList();
            _conditions = (await ConditionDataService.GetAll()).ToList();
            _branches = (await BranchDataService.GetAll()).ToList();
            _branches.Reverse();
            CurrentBranch = _branches[0];
            CurrentBranchClassifications = _classifications.Where(c => c.BranchId == CurrentBranch.BranchId).ToList();

            await base.OnInitializedAsync();
        }

        public void SetForceType(ForceType forceType)
        {
            SelectedForceType = forceType;
            StateHasChanged();
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
            Asset.Classification = await ClassificationDataService.GetById(Int32.Parse(Asset.ClassificationId));
            Asset.Condition = await ConditionDataService.GetById(Int32.Parse(Asset.ConditionId));
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
