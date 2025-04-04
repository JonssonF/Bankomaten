using System;
using System.Collections.Generic;

namespace Lektion_med_Petter_REPETION.Models;

public partial class Membership
{
    public int MembershipId { get; set; }

    public int? MemberId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string MembershipType { get; set; } = null!;

    public virtual Member? Member { get; set; }
}
