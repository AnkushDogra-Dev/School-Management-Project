//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using RaviSirTaskJune20.Models;

//namespace RaviSirTaskJune20.Controllers
//{
//    public class TeachersController : Controller
//    {
//        private readonly AppDbContext _context;

//        public TeachersController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Teachers
//        public async Task<IActionResult> Index()
//        {
//            var appDbContext = _context.Teachers.Include(t => t.Class).Include(t => t.Section);
//            return View(await appDbContext.ToListAsync());
//        }

//        // GET: Teachers/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var teachers = await _context.Teachers
//                .Include(t => t.Class)
//                .Include(t => t.Section)
//                .FirstOrDefaultAsync(m => m.TeacherId == id);
//            if (teachers == null)
//            {
//                return NotFound();
//            }

//            return View(teachers);
//        }

//        // GET: Teachers/Create
//        public IActionResult Create()
//        {
//            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name");
//          //  ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionName");
//            return View();
//        }



//        public IActionResult GetSections(int classId)
//        {
//            var sections = _context.Sections.Where(t => t.ClassId == classId)
//                                            .Select(t => new { t.SectionId, t.SectionName })
//                                            .ToList();
//            return Json(sections);
//        }





//        // POST: Teachers/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("TeacherId,TeacherName,SectionId,ClassId")] Teachers teachers)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(teachers);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", teachers.ClassId);
//           // ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionName", teachers.SectionId);
//            return View(teachers);
//        }

//        // GET: Teachers/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var teachers = await _context.Teachers.FindAsync(id);
//            if (teachers == null)
//            {
//                return NotFound();
//            }
//            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", teachers.ClassId);
//            //ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionName", teachers.SectionId);
//            return View(teachers);
//        }

//        // POST: Teachers/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,TeacherName,SectionId,ClassId")] Teachers teachers)
//        {
//            if (id != teachers.TeacherId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(teachers);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!TeachersExists(teachers.TeacherId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", teachers.ClassId);
//           // ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionName", teachers.SectionId);
//            return View(teachers);
//        }

//        // GET: Teachers/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var teachers = await _context.Teachers
//                .Include(t => t.Class)
//                .Include(t => t.Section)
//                .FirstOrDefaultAsync(m => m.TeacherId == id);
//            if (teachers == null)
//            {
//                return NotFound();
//            }

//            return View(teachers);
//        }

//        // POST: Teachers/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var teachers = await _context.Teachers.FindAsync(id);
//            if (teachers != null)
//            {
//                _context.Teachers.Remove(teachers);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool TeachersExists(int id)
//        {
//            return _context.Teachers.Any(e => e.TeacherId == id);
//        }
//    }
//}




using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaviSirTaskJune20.Models;

namespace RaviSirTaskJune20.Controllers
{
    public class TeachersController : Controller
    {
        private readonly AppDbContext _context;

        public TeachersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Teachers.Include(t => t.Class).Include(t => t.Section);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers
                .Include(t => t.Class)
                .Include(t => t.Section)
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name");
            return View();
        }

        // GET: Teachers/GetSections
        public JsonResult GetSections(int classId)
        {
            var sections = _context.Sections
                                    .Where(s => s.ClassId == classId)
                                    .Select(s => new { s.SectionId, s.SectionName })
                                    .ToList();
            return Json(sections);
        }

        // POST: Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,TeacherName,SectionId,ClassId")] Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", teachers.ClassId);
            return View(teachers);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers.FindAsync(id);
            if (teachers == null)
            {
                return NotFound();
            }

            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", teachers.ClassId);
            return View(teachers);
        }

        // POST: Teachers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,TeacherName,SectionId,ClassId")] Teachers teachers)
        {
            if (id != teachers.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachersExists(teachers.TeacherId))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", teachers.ClassId);
            return View(teachers);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers
                .Include(t => t.Class)
                .Include(t => t.Section)
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachers = await _context.Teachers.FindAsync(id);
            if (teachers != null)
            {
                _context.Teachers.Remove(teachers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachersExists(int id)
        {
            return _context.Teachers.Any(e => e.TeacherId == id);
        }
    }
}
