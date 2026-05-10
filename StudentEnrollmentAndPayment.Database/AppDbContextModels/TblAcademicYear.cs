using System;
using System.Collections.Generic;

namespace StudentEnrollmentAndPayment.Database.AppDbContextModels;

public partial class TblAcademicYear
{
    public int AcademicYearId { get; set; }

    public string AcademicYear { get; set; } = null!;
}
