using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollmentAndPayment.Database.AppDbContextModels;
using StudentEnrollmentAndPayment.ViewModels;

namespace StudentEnrollmentAndPayment.Controllers
{
    public class StudentFilterController : Controller
    {
        private readonly AppDbContext _context;

        public StudentFilterController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? majorId, int? yearId)
        {
            var students = _context.TblPersonalInformations.AsQueryable();

            if (majorId.HasValue)
            {
                students = students.Where(x => x.MajorId == majorId);
            }

            if (yearId.HasValue)
            {
                students = students.Where(x => x.AcademicYearId == yearId);
            }

            ViewBag.Majors = _context.TblMajors.ToList();
            ViewBag.Years = _context.TblAcademicYears.ToList();

            ViewBag.SelectedMajor = majorId;
            ViewBag.SelectedYear = yearId;

            return View(students.ToList());
        }
    }
}
