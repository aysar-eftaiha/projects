using System.ComponentModel.DataAnnotations;

namespace Federation_proj.Models;

public class Federation(string Name)
{
   [Key]
   public int FederationId { get; private set; }

   public string Name { set; get; } = Name;
   // public ICollection<Club> Clubs { get; set; }

}