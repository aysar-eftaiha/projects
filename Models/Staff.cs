using System.ComponentModel.DataAnnotations;
using Federation_proj.Context;

namespace Federation_proj.Models;

public class Staff(string firstName, string lastName, string email, string phone, Role role)
{
    [Key]
    public int Id { get; private set;}

    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    [EmailAddress]
    public string Email { get; set; }  = email;
    public string Phone { get; set; }  = phone;
    public Role Role { get;set;}

    // public Club Club { get; set; }
    // public int ClubId { get; set; }
    
    public void SetRole(Role role)
    {
        Role = role;
    }

}