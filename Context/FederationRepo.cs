using Federation_proj.Models;

namespace Federation_proj.Context;

public class FederationRepo
{
    private readonly EFcontext _context;

    public FederationRepo(EFcontext context)
    {
        _context = context;
    }

    public void Add(Federation federation)
    {
        _context.Add(federation);
        _context.SaveChanges();
    }

    public Federation? GetById(int id)
    {
        return _context.Federation.FirstOrDefault(s => s.FederationId == id);
    }

    public IEnumerable<Federation> GetAll()
    {
        return _context.Federation.ToList();
    }

    public void Update(Federation federation)
    {
        _context.Federation.Update(federation);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var federation = GetById(id);
        if (federation != null)
        {
            _context.Federation.Remove(federation);
            _context.SaveChanges();
        }
    }
}