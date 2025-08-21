using Federation_proj.Context;
using Federation_proj.Models;
using Microsoft.AspNetCore.Mvc;

namespace Federation_proj.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class FedrationController : ControllerBase
    {
        FederationRepo _repo;
        //private readonly EFcontext _context;
        public FedrationController(FederationRepo repo)
        {
            _repo = repo;
        }
   
        [HttpPost]
        public IActionResult AddFederation([FromBody] Federation federation)
        {
            _repo.Add(federation);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Federation> GetFederations()
        { 
            return _repo.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleFed(int id)
        {
            var federation = _repo.GetById(id);
            if (federation == null)
                return NotFound($"Fedrattion with Id {id} not found.");

            return Ok(federation);
        }

        [HttpDelete]
        public IActionResult Deletefed(int id)
        {
            _repo.Delete(id);
            return Ok();
        }

        [HttpPut("UpdateFed/{Id}")]
        public IActionResult Edit(int Id,Federation federation)
        {
            var UpdatedFed = _repo.GetById(Id);
            if (UpdatedFed == null) return NotFound();
            UpdatedFed.Name = federation.Name;
            _repo.Update(UpdatedFed);
            return Ok();
        }




}