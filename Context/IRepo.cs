namespace Federation_proj.Context;

    public interface IRepo<T> 
    {
        IEnumerable<T> GetAll();
        Task<T?> GetById(int id);
        void Add(T user);
        void Update(T user);
        void Remove(T user);
    }
