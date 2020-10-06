using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Services;
using wikibellum.Client.Services.Interfaces;
using wikibellum.Entities.Models;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Client.Components
{
    public partial class AddUnitAssetDialog : ComponentBase
    {
        #region DataServices
        [Inject]
        private IClassificationDataService ClassificationDataService { get; set; }
        [Inject]
        private IBranchDataService BranchDataService { get; set; }
        [Inject]
        private IConditionDataService ConditionDataService { get; set; }
        [Inject]
        private IOrganizationDataService OrganizationDataService { get; set; }
        [Inject]
        private IUnitDataService UnitDataService { get; set; }
        #endregion
        #region UI Controls
        private bool ShowDialog { get; set; }
        private bool _classificationIsDisabled = false;
        private bool ClassificationIsDisabled 
        { 
            get
            {
                return _classificationIsDisabled;
            }
            set
            {
                Asset.ClassificationIsDisabled = value;
                _classificationIsDisabled = value;
            } 
        }
        private bool _organizationIsDisabled = false;
        private bool OrganizationIsDisabled 
        {
            get
            {
                return _organizationIsDisabled;
            }
            set
            {
                Asset.OrganizationIsDisabled = value;
                _organizationIsDisabled = value;
            }
        }
        #endregion
        #region Parameters 
        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Parameter]
        public EventCallback<Asset> AddAssetEventCallback { get; set; }
        #endregion
        #region Stored Values
        private List<Classification> _classifications;
        private List<Organization> _organizations;
        private List<Branch> _branches;
        private List<Condition> _conditions;
        private int _organizationNAId;
        private int _classifiationNAId;
        #endregion
        #region Current Values
        private List<Classification> _currentClassifications;
        private List<Organization> _currentOrganizations;
        private Branch _currentBranch;
        private List<Unit> _units;
        private Unit _selectedUnit;
        private string _unitSearch;
        #endregion
        private Asset Asset { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _units = (await UnitDataService.GetAll()).ToList();
            _classifications = (await ClassificationDataService.GetAll()).ToList();
            _conditions = (await ConditionDataService.GetAll()).ToList();
            _organizations = (await OrganizationDataService.GetAll()).ToList();
            _branches = (await BranchDataService.GetAll()).ToList();
            _currentBranch = _branches[1];
            _organizationNAId = _organizations.FirstOrDefault(c => c.Singular == "N/A").OrganizationId;
            _classifiationNAId = _classifications.FirstOrDefault(c => c.Singular == "N/A").ClassificationId;
            GetCurrentClassifications();
            GetCurrentOrganizations();
            await base.OnInitializedAsync();
        }

        public void SetBranch(Branch branch)
        {
            _currentBranch = branch;
            GetCurrentClassifications();
            GetCurrentOrganizations();
            StateHasChanged();
        }


        private void GetCurrentOrganizations()
        {
            _currentOrganizations = _organizations
                .Where(c => c.BranchId == _currentBranch.BranchId)
                .ToList();
        }

        private void GetCurrentClassifications()
        {
            _currentClassifications = _classifications
                .Where(c => c.BranchId == _currentBranch.BranchId)
                .ToList();
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
        private async Task<IEnumerable<Unit>> SearchClassifications(string searchText)
        {
            _unitSearch = searchText;
            return await Task.FromResult(_units.Where(x => x.Name.ToLower().Contains(searchText.ToLower())).ToList());
        }

        private async Task CreateUnit()
        {
            _selectedUnit = await UnitDataService.Add(new Unit() { Name = _unitSearch });
            
            StateHasChanged();
        }

        private void ResetDialog(AssetType assetType)
        {
            Asset = new Asset()
            {
                AssetType = assetType,
                OrganizationIdString = _organizations[0].OrganizationId.ToString(),
                UnitIdString = _classifications[0].ClassificationId.ToString()
            };

        }

        protected async Task HandleValidSubmit()
        {
            //if (Asset.ClassificationIsDisabled) Asset.ClassificationId = _classifiationNAId;
            //if (Asset.OrganizationIsDisabled) Asset.OrganizationId = _organizationNAId;

            //Asset.ClassificationId = Int32.Parse(Asset.ClassificationIdString);
            //Asset.OrganizationId = Int32.Parse(Asset.OrganizationIdString);
            Debug.WriteLine("_selectedUnit value is: ");
            Debug.WriteLine(_selectedUnit.Name);
            //if (_units.Contains(_selectedUnit))
            //{
            //    Debug.WriteLine("Contained selected Unit");
            //}
            //else
            //{
            //    Debug.WriteLine("Doesn't contain selected unit");
            //}
            ShowDialog = false;
            await AddAssetEventCallback.InvokeAsync(Asset);
            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }

}
