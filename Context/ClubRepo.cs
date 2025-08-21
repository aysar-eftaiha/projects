using Federation_proj.Models;

namespace Federation_proj.Context;

public class ClubRepo
{
    private readonly EFcontext _context;

    public ClubRepo(EFcontext context)
    {
        _context = context;
    }

    public void Add(Club club)
    {
        _context.Club.Add(club);
        _context.SaveChanges();
    }

    public Club? GetById(int id)
    {
        return _context.Club.FirstOrDefault(s => s.Id == id);
    }

    public IEnumerable<Club> GetAll()
    {
        return _context.Club.ToList();
    }

    public void Update(Club club)
    {
        _context.Club.Update(club);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var club = GetById(id);
        if (club != null)
        {
            _context.Club.Remove(club);
            _context.SaveChanges();
        }
    }
}