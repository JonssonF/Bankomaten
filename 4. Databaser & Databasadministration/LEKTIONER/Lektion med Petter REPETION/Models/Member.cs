using System;
using System.Collections.Generic;

namespace Lektion_med_Petter_REPETION.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Age { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public int? AdressId { get; set; }

    public virtual ICollection<ActivityParticipation> ActivityParticipations { get; set; } = new List<ActivityParticipation>();

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}
