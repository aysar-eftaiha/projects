using Federation_proj.Context;
using Federation_proj.Dtos;
using Federation_proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Federation_proj.Controllers;

[ApiController]
[Route("[controller]")]
public class Staffcontroller : ControllerBase
{
    StaffRepository _repo;
    //private readonly EFcontext _context;
   public Staffcontroller(StaffRepository repo)
   {
       _repo = repo;
   }
   
    [HttpPost]
    public IActionResult Post([FromBody] Staff staff)
    {
        _repo.Add(staff);
        return Ok();
    }

    [HttpGet]
    public IEnumerable<Staff> Get()
    { 
        return _repo.GetAll();
    }

    [HttpGet("{id}")]
    public IActionResult GetSingleStaff(int id)
    {
        var staff = _repo.GetById(id);
        if (staff == null)
            return NotFound($"Staff with Id {id} not found.");

        return Ok(staff);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return Ok();
    }

    [HttpPut("UpdateUser/{Id}")]
    public IActionResult EditUser(int Id,Staff staff)
    {
            var UpdatedStaff = _repo.GetById(Id);
            if (UpdatedStaff == null) return NotFound();

        UpdatedStaff.FirstName = staff.FirstName;
        UpdatedStaff.LastName = staff.LastName;
        UpdatedStaff.Email = staff.Email;
        UpdatedStaff.Phone = staff.Phone;
        UpdatedStaff.Role = staff.Role;
        _repo.UpdateStaff(UpdatedStaff);
        return Ok();
    }
    
    
    
    
    
}
        // // select * from staff join club on club.id = staff.club_id join federation on f.id = club.fedration_id;
        // var response = _context.Staff.Include(p => p.Club)
        //     .ThenInclude(p => p.Federation)
        //     .ToList();
