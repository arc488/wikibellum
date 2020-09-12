using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private IEventParticipantDataService EventParticipantDataService { get; set; }
        [Inject]
        private IAllianceDataService AllianceDataService { get; set; }
        [Inject]
        private INationDataService NationDataService { get; set; }

        private AddUnitAssetDialog Dialog { get; set; }

        private Alliance Alliance { get; set; }

        private IEnumerable<Alliance> _alliances;
        private Alliance _alliesAlliance;
        private Alliance _axisAlliance;
        private IEnumerable<Nation> _nations;
        private IEnumerable<Nation> _alliedNations;
        private IEnumerable<Nation> _axisNations;

        protected async override Task OnInitializedAsync()
        {
            _alliances = await AllianceDataService.GetAll();
            _nations = await NationDataService.GetAll();

            _alliesAlliance = _alliances.FirstOrDefault(a => a.Name == "Allies");
            _axisAlliance = _alliances.FirstOrDefault(a => a.Name == "Axis");

            _alliedNations = _nations.Where(n => n.AllianceId == _alliesAlliance.AllianceId).ToList();
            _axisNations = _nations.Where(n => n.AllianceId == _axisAlliance.AllianceId).ToList();

            Alliance = _alliesAlliance;

            await base.OnInitializedAsync();
        }

        public void AddAsset(AssetType assetType)
        {
            Dialog.Show(assetType);
        }

        public void AddUnitAssetDialog_OnAssetAdded(Asset asset)
        {

            Belligerent.Assets.Add(asset);
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

        public void SetNation()
        {
            Belligerent.NationId = Int32.Parse(Belligerent.NationIdString);
            Belligerent.Nation = _nations.FirstOrDefault(n => n.NationId == Belligerent.NationId);
            EventParticipantDataService.Update(Belligerent.EventParticipantId, Belligerent);
            StateHasChanged();

        }
    }



}
