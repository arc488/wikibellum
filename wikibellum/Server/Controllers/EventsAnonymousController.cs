using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wikibellum.Data;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities;
using wikibellum.Entities.ViewModels;

namespace wikibellum.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsAnonymousController : ControllerBase
    {
        private readonly IEventAnonymousRepository _repo;

        public EventsAnonymousController(IEventAnonymousRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<EventMarker>> GetEvents()
        {
            var events = await _repo.GetAll();
            var eventMarkers = new List<EventMarker>();
            foreach (var item in events)
            {
                try
                {
                    var eventMarker = new EventMarker
                    {
                        EventId = item.EventId,
                        Title = item.Title,
                        Start = item.Start,
                        End = item.End,
                        Lat = item.Location.Lat,
                        Long = item.Location.Long
                    };
                    eventMarkers.Add(eventMarker);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Something went wrong mapping events to event markers.");
                    Debug.WriteLine(e.Message);
                }

            }
            return eventMarkers;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _repo.Get(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }


    }
}
