using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using wikibellum.Data;
using wikibellum.Models.ViewModels;

namespace wikibellum.Controllers
{
    public class ImportController : Controller
    {
        public ImportController()
        {
        }

        public IActionResult Index(IEventRepository eventRepository,
                                    IMapper mapper
                                    )
        {
            return View();
        }
        [HttpPost]
        public IActionResult Process(ImportViewModel viewModel)
        {
            return View();
        }
    }
}
