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
    public class MaskTypesController : Controller
    {
        private readonly MaskContext _context;

        public MaskTypesController(MaskContext context)
        {
            _context = context;
        }

        // GET: MaskTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.MaskType.ToListAsync());
        }

        // GET: MaskTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MaskType == null)
            {
                return NotFound();
            }

            var maskType = await _context.MaskType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maskType == null)
            {
                return NotFound();
            }

            return View(maskType);
        }

        // GET: MaskTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaskTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MaskType maskType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maskType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maskType);
        }

        // GET: MaskTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MaskType == null)
            {
                return NotFound();
            }

            var maskType = await _context.MaskType.FindAsync(id);
            if (maskType == null)
            {
                return NotFound();
            }
            return View(maskType);
        }

        // POST: MaskTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MaskType maskType)
        {
            if (id != maskType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maskType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaskTypeExists(maskType.Id))
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
            return View(maskType);
        }

        // GET: MaskTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MaskType == null)
            {
                return NotFound();
            }

            var maskType = await _context.MaskType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maskType == null)
            {
                return NotFound();
            }

            return View(maskType);
        }

        // POST: MaskTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MaskType == null)
            {
                return Problem("Entity set 'MaskContext.MaskType'  is null.");
            }
            var maskType = await _context.MaskType.FindAsync(id);
            if (maskType != null)
            {
                _context.MaskType.Remove(maskType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaskTypeExists(int id)
        {
          return _context.MaskType.Any(e => e.Id == id);
        }
    }
}
