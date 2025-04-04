using System;
using System.Collections.Generic;

namespace Lektion_med_Petter_REPETION.Models;

public partial class ActivityParticipation
{
    public int ParticipationId { get; set; }

    public int? MemberId { get; set; }

    public int? ActivityId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual Activity? Activity { get; set; }

    public virtual Member? Member { get; set; }
}
