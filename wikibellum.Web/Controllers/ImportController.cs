using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using wikibellum.Data;
using wikibellum.Entities;
using wikibellum.Entities.ViewModels;
using wikiparser;

namespace wikibellum.Controllers
{
    public class ImportController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly Starter _starter;

        public ImportController(IEventRepository eventRepository,
                                    IMapper mapper,
                                    Starter starter)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _starter = starter;
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
    }
}
