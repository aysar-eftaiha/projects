// using Federation_proj.Models;
//
// namespace Federation_proj.Context;
//
// public class AddressRepo
// {
//     private readonly EFcontext _context;
//
//     public AddressRepo(EFcontext context)
//     {
//         _context = context;
//     }
//
//     public void Add(Address address)
//     {
//         _context.Address.Add(address);
//         _context.SaveChanges();
//     }
//
//     public Address? GetById(int id)
//     {
//         return _context.Address.FirstOrDefault(s => s.Id == id);
//     }
//
//     public IEnumerable<Address> GetAll()
//     {
//         return _context.Address.ToList();
//     }
//
//     public void Update(Address address)
//     {
//         _context.Address.Update(address);
//         _context.SaveChanges();
//     }
//
//     public void Delete(int id)
//     {
//         var address = GetById(id);
//         if (address != null)
//         {
//             _context.Address.Remove(address);
//             _context.SaveChanges();
//         }
//     }
// }