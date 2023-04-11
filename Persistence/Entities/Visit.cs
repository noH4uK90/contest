using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public partial class Visit
{
    [Required]
    public int IdVisit { get; set; }

    [Required]
    public int IdEmployee { get; set; }

    [Required]
    public DateTime Date { get; set; }

    public int? IdVisitInfo { get; set; }
}
