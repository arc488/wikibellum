using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities.Models.Units;

namespace wikibellum.App.Components.Belligerents
{
    public partial class UnitData<TItem> where TItem : IBelligerentUnit
    {
        [Parameter]
        public List<TItem> Units { get; set; }

        public AddUnitAssetDialog<TItem> Dialog { get; set; }

        public int ParticipantIndex { get; set; }

        public async void AddAsset()
        {
            Units.Add(new T());
            StateHasChanged();
        }

        public async void AddUnitAssetDialog_OnDialogClose()
        {
            StateHasChanged();
        }

        public async void AddUnitAssetDialog_OnAssetAdded(Asset asset)
        {
            Units.Add(asset);
        }

    }
}
