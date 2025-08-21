using Federation_proj.Models;

namespace Federation_proj.Context;

public class StaffRepository
{
    private readonly EFcontext _context;

    public StaffRepository(EFcontext context)
    {
        _context = context;
    }

    public void Add(Staff staff)
    {
        _context.Staff.Add(staff);
        _context.SaveChanges();
    }

    public Staff? GetById(int id)
    {
        return _context.Staff.FirstOrDefault(s => s.Id == id);
    }

    public IEnumerable<Staff> GetAll()
    {
        IEnumerable<Staff> staffs = _context.Staff;
        _context.SaveChanges();
        return staffs;
    }

    public void UpdateStaff(Staff staff)
    {
        _context.Staff.Update(staff);
        _context.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var staff = GetById(id);
        if (staff != null)
        {
            _context.Staff.Remove(staff);
            _context.SaveChanges();
        }
    }
}