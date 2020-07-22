using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using wikibellum.Common;
using wikibellum.Data;
using wikibellum.Entities;
using wikibellum.Entities.ViewModels;
using wikiparser;

namespace wikibellum.Controllers
{
    public class ImportController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        private readonly Starter _starter;
        private readonly GeocodingService _geocodingService;

        public ImportController(IEventRepository eventRepository,
                                ILocationRepository locationRepository,
                                IMapper mapper,
                                Starter starter,
                                GeocodingService geocodingService)
        {
            _eventRepository = eventRepository;
            _locationRepository = locationRepository;
            _mapper = mapper;
            _starter = starter;
            _geocodingService = geocodingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Process()
        {
            var viewModel = new ImportViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Process(ImportViewModel viewModel)
        {
            var events = _starter.StartParse(viewModel.startFile, viewModel.endFile);
            foreach(var item in events)
            {
                _eventRepository.Create(item);
            }
            return View(new ImportViewModel());
        }

        public IActionResult Geocode()
        {
            var viewModel = new GeocodeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Geocode(GeocodeViewModel viewModel)
        {
            var locations = _locationRepository.GetAll();
            foreach (var location in locations)
            {
                var coords = _geocodingService.GetCoordinates(location.Name);
                location.Lat = coords["lat"];
                location.Long = coords["long"];
                _locationRepository.Update(location);
            }
            return View(new GeocodeViewModel());
        }
    }
}
