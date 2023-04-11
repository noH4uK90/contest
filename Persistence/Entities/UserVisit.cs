using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public partial class UserVisit
{
    [Required]
    public int IdVisit { get; set; }

    [Required]
    public int IdUser { get; set; }

    public string? GroupName { get; set; }
}
