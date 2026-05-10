using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollmentAndPayment.Database.AppDbContextModels;
using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        var data = _context.TblPersonalInformations
    .Where(x => x.DeleteFlag == false)
    .AsNoTracking()
    .ToList();
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

    //Edit
    public IActionResult Edit(int id)
    {
        var student = _context.TblPersonalInformations
            .FirstOrDefault(x => x.StudentId == id);

        if (student == null)
            return NotFound();

        return View(student);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, TblPersonalInformation updatedStudent, IFormFile ProfileFile)
    {
        var student = _context.TblPersonalInformations
            .FirstOrDefault(x => x.StudentId == id);

        if (student == null)
            return NotFound();

        // ✅ PATCH STYLE (only update what you want)

        student.FullName = updatedStudent.FullName;
        student.Nrc = updatedStudent.Nrc;
        student.PhoneNumber = updatedStudent.PhoneNumber;
        student.Email = updatedStudent.Email;

        // update image only if new file uploaded
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

        student.ModifiedDateTime = DateTime.Now;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    //Delete
    [HttpPost]

    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var student = _context.TblPersonalInformations
            .FirstOrDefault(x => x.StudentId == id);

        if (student == null)
        {
            return NotFound(); // avoids crash
        }

        student.DeleteFlag = true;
        student.ModifiedDateTime = DateTime.Now;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}