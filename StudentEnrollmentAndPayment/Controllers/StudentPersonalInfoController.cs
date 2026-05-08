using Microsoft.AspNetCore.Mvc;
using StudentEnrollmentAndPayment.Database.AppDbContextModels;
using System.IO;

public class StudentPersonalInfoController : Controller
{
    private readonly AppDbContext _context;

    public StudentPersonalInfoController(AppDbContext context)
    {
        _context = context;
    }

    // 🔹 INDEX
    public IActionResult Index()
    {
        var data = _context.TblPersonalInformations.ToList();
        return View(data);
    }

    // 🔹 CREATE (GET)
    public IActionResult Create()
    {
        return View("createStudentInfo");
    }

    // 🔹 CREATE (POST WITH IMAGE)
    [HttpPost]
    public IActionResult Create(TblPersonalInformation student, IFormFile ProfileFile)
    {
        if (ProfileFile != null && ProfileFile.Length > 0)
        {
            var fileName = Path.GetFileName(ProfileFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                ProfileFile.CopyTo(stream);
            }

            student.Profile = "/images/" + fileName;
        }
        student.CreatedDateTime = DateTime.Now;
        student.DeleteFlag = false;
        _context.TblPersonalInformations.Add(student);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}