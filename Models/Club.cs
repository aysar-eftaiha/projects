using System.ComponentModel.DataAnnotations;

namespace Federation_proj.Models;

public class Club(string name)
{
    [Key]
    public int Id { get;private set; }

    public string Name { get; set; } = name;
    // public ICollection<Address> Addresses { get; set; }
    // public ICollection<Staff> Staffs { get; set; }


    // public  int FederationId { get; set; }
    //   public Federation Federation { get; set; }
    //  
}