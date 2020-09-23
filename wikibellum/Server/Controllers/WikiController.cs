using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wikibellum.Data;

namespace wikibellum.Api.Controllers
{
    public class WikiController<TEntity> : ControllerBase where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public WikiController(IRepository<TEntity> repository)
        {
            _repository = repository;
        }


        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetEvents()
        {
            var entries = _repository.GetAll();
            return Ok(entries);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entry = _repository.Get(id);
            return Ok(entry);
        }
    }
}
