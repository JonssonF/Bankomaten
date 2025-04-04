using System;
using System.Collections.Generic;

namespace Lektion_med_Petter_REPETION.Models;

public partial class Activity
{
    public int ActivityId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? MaxParticipants { get; set; }

    public virtual ICollection<ActivityParticipation> ActivityParticipations { get; set; } = new List<ActivityParticipation>();
}
