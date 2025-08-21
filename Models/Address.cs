using System.ComponentModel.DataAnnotations;

namespace Federation_proj.Models;

public class Address
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string County { get; set; }
    public string ZipCode { get; set; }
    
    // public Club Club { get; set; }
    // public int ClubId { get; set; }
}