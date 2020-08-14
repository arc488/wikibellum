using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using wikibellum.Data;
using wikibellum.Entities;
using wikibellum.Entities.ViewModels;

namespace wikibellum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
                              IEventRepository eventRepository,
                              IMapper mapper)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var events = _eventRepository.GetAll();
            List<MapItemViewModel> mapItems = new List<MapItemViewModel>();
            foreach (var item in events)
            {
                var viewModel = new MapItemViewModel()
                {
                    Title = item.Title,
                    Lat = item.Location.Lat,
                    Long = item.Location.Long,

                };
                mapItems.Add(viewModel);
            }

            return View(mapItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
