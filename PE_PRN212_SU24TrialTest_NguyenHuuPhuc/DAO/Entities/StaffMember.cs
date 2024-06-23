using System.ComponentModel.DataAnnotations;

namespace DAO.Entities;

public partial class StaffMember
{
    public StaffMember(string emailAddress, string password)
    {
        this.EmailAddress = emailAddress;
        this.Password = password;
    }

    public StaffMember(int memberId, 
        string password, 
        string fullName, 
        string emailAddress, 
        int role) 
    {
        this.MemberId = memberId;
        this.Password = password;
        this.FullName = fullName;
        this.EmailAddress = emailAddress;
        this.Role = role;
    }

    [Key]
    public int MemberId { get; set; }

    [Required]
    [StringLength(40)]
    public string Password { get; set; } = null!;

    [Required]
    [StringLength(60)]
    public string FullName { get; set; } = null!;

    [StringLength(60)]
    public string? EmailAddress { get; set; }

    public int? Role { get; set; }
}
