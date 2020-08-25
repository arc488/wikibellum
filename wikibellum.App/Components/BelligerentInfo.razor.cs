using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.Components;
using wikibellum.Entities;
using wikibellum.Entities.Models.Units;

namespace wikibellum.App.Components
{
    public partial class BelligerentInfo : ComponentBase
    {
        [Parameter]
        public EventParticipant Belligerent { get; set; }

        public AddUnitAssetDialog Dialog { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public void AddAsset(AssetType assetType)
        {
            Dialog.Show(assetType);
        }

        public void AddUnitAssetDialog_OnAssetAdded(Asset asset)
        {
            if (asset.AssetType == AssetType.Loss)
            {
                Belligerent.Losses.Add(asset);
            }

            if (asset.AssetType == AssetType.Strength)
            {
                Belligerent.Strength.Add(asset);
            }
            StateHasChanged();
        }

        public void AddUnitAssetDialog_OnDialogClose()
        {

        }
    }


}
