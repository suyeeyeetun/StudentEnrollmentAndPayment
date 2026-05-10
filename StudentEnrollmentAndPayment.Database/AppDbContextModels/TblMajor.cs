using System;
using System.Collections.Generic;

namespace StudentEnrollmentAndPayment.Database.AppDbContextModels;

public partial class TblMajor
{
    public int MajorId { get; set; }

    public string MajorName { get; set; } = null!;
}
