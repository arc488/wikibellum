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
        private IConditionDataService ConditionDataService { get; set; }
        [Inject]
        private IUnitDataService UnitDataService { get; set; }
        #endregion
        #region UI Controls
        private bool ShowDialog { get; set; }
        #endregion
        #region Parameters 
        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Parameter]
        public EventCallback<Asset> AddAssetEventCallback { get; set; }
        #endregion
        #region Stored Values
        #endregion
        #region Current Values
        private List<Condition> _conditions;
        private List<Unit> _units;
        private Unit _selectedUnit;
        private string _unitSearch;
        #endregion
        private Asset Asset { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _units = (await UnitDataService.GetAll()).ToList();
            _conditions = (await ConditionDataService.GetAll()).ToList();
            await base.OnInitializedAsync();
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
            Asset.UnitId = _selectedUnit.UnitId;
            _units = await UnitDataService.GetAll();
            StateHasChanged();
        }

        private void ResetDialog(AssetType assetType)
        {
            Asset = new Asset()
            {
                AssetType = assetType
            };
            _selectedUnit = null;
            
        }

        protected async Task HandleValidSubmit()
        {
            ShowDialog = false;
            Asset.UnitId = _selectedUnit.UnitId;
            await AddAssetEventCallback.InvokeAsync(Asset);
            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }

}
