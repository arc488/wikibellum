using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.Components;
using wikibellum.App.Services;
using wikibellum.Entities;
using wikibellum.Entities.Models.Units;

namespace wikibellum.App.Pages
{
    public partial class AddEvent : ComponentBase
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        public Event Event { get; set; }

        public AddUnitAssetDialog AddUnitAssetDialog { get; set; }

        public int ParticipantIndex { get; set; }

        public int TempCount { get; set; } 

        protected async override Task OnInitializedAsync()
        {

            Event = new Event()
            {               
                End = DateTime.Now,
                Start = DateTime.Now,
                Location = new Location(),
                Participants = new List<EventParticipant> {
                    new EventParticipant()
                    {
                        Name = "",
                        Losses = new UnitLosses(){
                            Losses = new List<Loss>()
                        },
                        Strength = new UnitStrength(){ 
                            Assets = new List<Asset>()
                        },
                    }
                }
                
            };
        }

        protected void AddParticipant()
        {
            Event.Participants.Add(new EventParticipant()
            {
                Name = "",
                Losses = new UnitLosses()
                {
                    Losses = new List<Loss>()
                },
                Strength = new UnitStrength()
                {
                    Assets = new List<Asset>()
                },
            });
            TempCount++;
            StateHasChanged();
        }

        protected void AddLoss()
        {
            StateHasChanged();

        }

        protected void AddAsset(int participantIndex)
        {
            Debug.WriteLine("Reached AddAsset function with participantId = " + participantIndex);
            ParticipantIndex = participantIndex;
            AddUnitAssetDialog.Show();
        }

        public async void AddUnitAssetDialog_OnDialogClose()
        {        
            StateHasChanged();
        }

        public async void AddUnitAssetDialog_OnAssetAdded(Asset asset)
        {
            Event.Participants[ParticipantIndex].Strength.Assets.Add(asset); 
        }
        protected void HandleValidSubmit()
        {

        }

        protected void HandleInvalidSubmit()
        {

        }

        protected override void OnAfterRender(bool firstRender)
        {
            JSRuntime.InvokeVoidAsync("setBelligerentsHeight");
            
        }
    }
}
