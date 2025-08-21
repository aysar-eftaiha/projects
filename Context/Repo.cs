using Microsoft.EntityFrameworkCore;

namespace Federation_proj.Context;

public interface IEntity
{
    public int Id { get; set; }
}
public class Repo<T> : IRepo<T> where T : class, IEntity
{
    private readonly EFcontext _context;

    public Repo(EFcontext context)
    {
        _context = context;
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
      
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Remove(T user)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}