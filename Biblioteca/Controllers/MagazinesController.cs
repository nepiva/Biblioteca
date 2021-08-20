using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class MagazinesController : Controller
    {
        private readonly LibraryContext _context;

        public MagazinesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Magazines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Magazines.ToListAsync());
        }

        // GET: Magazines/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazine = await _context.Magazines
                .FirstOrDefaultAsync(m => m.Code == id);
            if (magazine == null)
            {
                return NotFound();
            }

            return View(magazine);
        }

        // GET: Magazines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Magazines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name,Description,PublicationYear,NumberOfSerie,ColectionName")] Magazine magazine)
        {
            if (ModelState.IsValid)
            {
                magazine.ElementType = ElementType.MAGAZINES;
                _context.Add(magazine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magazine);
        }

        // GET: Magazines/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazine = await _context.Magazines.FindAsync(id);
            if (magazine == null)
            {
                return NotFound();
            }
            return View(magazine);
        }

        // POST: Magazines/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,Name,Description,PublicationYear,NumberOfSerie,ColectionName")] Magazine magazine)
        {
            if (id != magazine.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magazine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagazineExists(magazine.Code))
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
            return View(magazine);
        }

        // GET: Magazines/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazine = await _context.Magazines
                .FirstOrDefaultAsync(m => m.Code == id);
            if (magazine == null)
            {
                return NotFound();
            }

            return View(magazine);
        }

        // POST: Magazines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var magazine = await _context.Magazines.FindAsync(id);
            _context.Magazines.Remove(magazine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MagazineExists(string id)
        {
            return _context.Magazines.Any(e => e.Code == id);
        }
    }
}
