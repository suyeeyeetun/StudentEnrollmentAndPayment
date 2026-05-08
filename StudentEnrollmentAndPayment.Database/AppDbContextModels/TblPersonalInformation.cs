using System;
using System.Collections.Generic;

namespace StudentEnrollmentAndPayment.Database.AppDbContextModels;

public partial class TblPersonalInformation
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Nrc { get; set; }

    public DateOnly Dob { get; set; }

    public string Gender { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string FatherName { get; set; } = null!;

    public string MotherName { get; set; } = null!;

    public string FatherPhoneNumber { get; set; } = null!;

    public string MotherPhoneNumber { get; set; } = null!;

    public string? Profile { get; set; }

    public string Nationality { get; set; } = null!;

    public string Religion { get; set; } = null!;

    public string? RollNo { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public bool? DeleteFlag { get; set; }
}
