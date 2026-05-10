using StudentEnrollmentAndPayment.Database.AppDbContextModels;

namespace StudentEnrollmentAndPayment.ViewModels
{
    public class StudentFilterViewModel
    {
        public List<TblPersonalInformation> Students { get; set; }

        public List<TblMajor> Majors { get; set; }

        public List<TblAcademicYear> AcademicYears { get; set; }

        public int? MajorId { get; set; }

        public int? AcademicYearId { get; set; }
    }
}