using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaskDemo.Data;
using MaskDemo.Models;

namespace MaskDemo.Controllers
{
    public class MasksController : Controller
    {
        private readonly MaskContext _context;

        public MasksController(MaskContext context)
        {
            _context = context;
        }

        // GET: Masks
        public async Task<IActionResult> Index()
        {
            var maskContext = _context.Masks.Include(m => m.MaskType);
            return View(await maskContext.ToListAsync());
        }

        // GET: Masks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Masks == null)
            {
                return NotFound();
            }

            var mask = await _context.Masks
                .Include(m => m.MaskType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mask == null)
            {
                return NotFound();
            }

            return View(mask);
        }

        // GET: Masks/Create
        public IActionResult Create()
        {
            ViewData["MaskTypeId"] = new SelectList(_context.MaskType, "Id", "Name");
            return View();
        }

        // POST: Masks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Price,MaskTypeId")] Mask mask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaskTypeId"] = new SelectList(_context.MaskType, "Id", "Name", mask.MaskTypeId);
            return View(mask);
        }

        // GET: Masks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Masks == null)
            {
                return NotFound();
            }

            var mask = await _context.Masks.FindAsync(id);
            if (mask == null)
            {
                return NotFound();
            }
            ViewData["MaskTypeId"] = new SelectList(_context.MaskType, "Id", "Name", mask.MaskTypeId);
            return View(mask);
        }

        // POST: Masks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Price,MaskTypeId")] Mask mask)
        {
            if (id != mask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaskExists(mask.Id))
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
            ViewData["MaskTypeId"] = new SelectList(_context.MaskType, "Id", "Name", mask.MaskTypeId);
            return View(mask);
        }

        // GET: Masks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Masks == null)
            {
                return NotFound();
            }

            var mask = await _context.Masks
                .Include(m => m.MaskType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mask == null)
            {
                return NotFound();
            }

            return View(mask);
        }

        // POST: Masks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Masks == null)
            {
                return Problem("Entity set 'MaskContext.Masks'  is null.");
            }
            var mask = await _context.Masks.FindAsync(id);
            if (mask != null)
            {
                _context.Masks.Remove(mask);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaskExists(int id)
        {
          return _context.Masks.Any(e => e.Id == id);
        }
    }
}
