using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaviSirTaskJune20.Models;

namespace RaviSirTaskJune20.Controllers
{
    public class SectionsController : Controller
    {
        private readonly AppDbContext _context;

        public SectionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Sections.Include(s => s.Class);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.Sections
                .Include(s => s.Class)
                .FirstOrDefaultAsync(m => m.SectionId == id);
            if (sections == null)
            {
                return NotFound();
            }

            return View(sections);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SectionId,SectionName,ClassId")] Sections sections)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sections);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", sections.ClassId);
            return View(sections);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.Sections.FindAsync(id);
            if (sections == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", sections.ClassId);
            return View(sections);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectionId,SectionName,ClassId")] Sections sections)
        {
            if (id != sections.SectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sections);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionsExists(sections.SectionId))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "Name", sections.ClassId);
            return View(sections);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sections = await _context.Sections
                .Include(s => s.Class)
                .FirstOrDefaultAsync(m => m.SectionId == id);
            if (sections == null)
            {
                return NotFound();
            }

            return View(sections);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sections = await _context.Sections.FindAsync(id);
            if (sections != null)
            {
                _context.Sections.Remove(sections);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionsExists(int id)
        {
            return _context.Sections.Any(e => e.SectionId == id);
        }
    }
}
