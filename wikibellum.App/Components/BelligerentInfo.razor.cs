using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.Components;
using wikibellum.App.Services.Interfaces;
using wikibellum.Entities;
using wikibellum.Entities.Enums;
using wikibellum.Entities.Models;
using wikibellum.Entities.Models.Units;

namespace wikibellum.App.Components
{
    public partial class BelligerentInfo : ComponentBase
    {
        [Parameter]
        public EventParticipant Belligerent { get; set; }

        [Inject]
        public IEventParticipantDataService EventParticipantDataService { get; set; }
        [Inject]
        public IAllianceDataService AllianceDataService { get; set; }
        [Inject]
        public INationDataService NationDataService { get; set; }

        public AddUnitAssetDialog Dialog { get; set; }

        public Alliance Alliance { get; set; }

        private IEnumerable<Alliance> _alliances;
        private Alliance _allies;
        private Alliance _axis;
        private IEnumerable<Nation> _nations;

        protected async override Task OnInitializedAsync()
        {
            _alliances = await AllianceDataService.GetAll();
            _nations = await NationDataService.GetAll();

            _allies = _alliances.FirstOrDefault(a => a.Name == "Allies");
            _axis = _alliances.FirstOrDefault(a => a.Name == "Axis");
            await base.OnInitializedAsync();
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
            Belligerent.Nation = _nations.FirstOrDefault(n => n.NationId == Belligerent.NationId);
            EventParticipantDataService.Update(Belligerent.EventParticipantId, Belligerent);

            StateHasChanged();
        }

        public void SetAlliance(Alliance alliance)
        {
            Alliance = alliance;
            StateHasChanged();
        }

        public void AddUnitAssetDialog_OnDialogClose()
        {

        }
    }



}
