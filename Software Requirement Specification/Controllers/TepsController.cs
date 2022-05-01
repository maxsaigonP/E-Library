using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Controllers
{
    public class TepsController : Controller
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public TepsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: Teps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tep.ToListAsync());
        }

        // GET: Teps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tep = await _context.Tep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tep == null)
            {
                return NotFound();
            }

            return View(tep);
        }

        // GET: Teps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenFile,LoaiFile,KichThuoc")] Tep tep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tep);
        }

        // GET: Teps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tep = await _context.Tep.FindAsync(id);
            if (tep == null)
            {
                return NotFound();
            }
            return View(tep);
        }

        // POST: Teps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenFile,LoaiFile,KichThuoc")] Tep tep)
        {
            if (id != tep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TepExists(tep.Id))
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
            return View(tep);
        }

        // GET: Teps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tep = await _context.Tep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tep == null)
            {
                return NotFound();
            }

            return View(tep);
        }

        // POST: Teps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tep = await _context.Tep.FindAsync(id);
            _context.Tep.Remove(tep);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TepExists(int id)
        {
            return _context.Tep.Any(e => e.Id == id);
        }
    }
}
