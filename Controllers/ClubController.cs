using Federation_proj.Context;
using Federation_proj.Models;
using Microsoft.AspNetCore.Mvc;

namespace Federation_proj.Controllers;


[ApiController]
[Route("[controller]")]
public class ClubController : ControllerBase
{
    ClubRepo _repo;

    //private readonly EFcontext _context;
    public ClubController(ClubRepo repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public IActionResult AddClub([FromBody] Club club)
    {
        _repo.Add(club);
        return Ok();
    }

    [HttpGet]
    public IEnumerable<Club> GetAllClubs()
    {
        return _repo.GetAll();
    }

    [HttpGet("{id}")]
    public IActionResult GetSingleclub(int id)
    {
        var club = _repo.GetById(id);
        if (club == null)
            return NotFound($"Staff with Id {id} not found.");

        return Ok(club);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return Ok();
    }

    [HttpPut("UpdateUser/{Id}")]
    public IActionResult EditClub(int Id, Club club)
    {
        var UpdatedClub = _repo.GetById(Id);
        if (UpdatedClub == null) return NotFound();
        UpdatedClub.Name = club.Name;
        _repo.Update(UpdatedClub);
        return Ok();
    }
}




