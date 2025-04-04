using System;
using System.Collections.Generic;

namespace Lektion_med_Petter_REPETION.Models;

public partial class Adress
{
    public int Id { get; set; }

    public string? Street { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
