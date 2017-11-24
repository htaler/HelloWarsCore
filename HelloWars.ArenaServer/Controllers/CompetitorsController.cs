using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using HelloWars.Common.Interfaces;

namespace HelloWars.ArenaServer.Controllers
{
    [Route("api/[controller]")]
    public class CompetitorsController : Controller
    {
        private readonly IRepository _repository;

        public CompetitorsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ICompetitor> Get()
        {
            return _repository.Competitors;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ICompetitor Get(Guid id)
        {
            return _repository.Competitors.SingleOrDefault(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Competitor value)
        {
            value.Id = Guid.NewGuid();
            _repository.Competitors.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Competitor value)
        {
            var competitor = _repository.Competitors.SingleOrDefault(x => x.Id == id);
            //TODO: mapping
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var c = _repository.Competitors.SingleOrDefault(x => x.Id == id);
            _repository.Competitors.Remove(c);
        }
    }
}
