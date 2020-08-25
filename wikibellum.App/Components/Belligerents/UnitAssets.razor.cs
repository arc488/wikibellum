using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.App.Components.Belligerents
{
    public partial class UnitAssets<T> where T : new()
    {
        [Parameter]
        public List<T> Assets { get; set; }

        public AddUnitAssetDialog Dialog { get; set; }

        public int ParticipantIndex { get; set; }

        public async void AddAsset()
        {
            Assets.Add(new T());
        }

        public async void AddUnitAssetDialog_OnDialogClose()
        {
        }

        public async void AddUnitAssetDialog_OnAssetAdded(T asset)
        {
            Assets.Add(asset);
        }
    }
}
