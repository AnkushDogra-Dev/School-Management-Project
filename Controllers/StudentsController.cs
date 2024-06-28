using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaviSirTaskJune20.Models;

namespace RaviSirTaskJune20.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Students.Include(s => s.Class).Include(s => s.Section);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Section)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name");
            return View();
        }

        // GET: Students/GetSections
        public JsonResult GetSections1(int classId)
        {
            var sections = _context.Sections
                .Where(s => s.ClassId == classId)
                .Select(s => new { s.SectionId, s.SectionName })
                .ToList();
            return Json(sections);
        }




     


        // POST: Students/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("StudentId,StudentName,ClassId,SectionId")] Students students)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(students);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", students.ClassId);
        //    return View(students);
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,ClassId,SectionId")] Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", students.ClassId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionName", students.SectionId);
            return View(students);
        }


        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", students.ClassId);
            return View(students);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,ClassId,SectionId")] Students students)
        {
            if (id != students.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", students.ClassId);
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Section)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.Students.FindAsync(id);
            if (students != null)
            {
                _context.Students.Remove(students);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
