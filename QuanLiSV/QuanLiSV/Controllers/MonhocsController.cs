using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLiSV.Data;
using QuanLiSV.Models;

namespace QuanLiSV.Controllers
{
    public class MonhocsController : Controller
    {
        private readonly QuanLiSVContext _context;

        public MonhocsController(QuanLiSVContext context)
        {
            _context = context;
        }

        // GET: Monhocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monhoc.ToListAsync());
        }

        // GET: Monhocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc
                .FirstOrDefaultAsync(m => m.mamonhoc == id);
            if (monhoc == null)
            {
                return NotFound();
            }

            return View(monhoc);
        }

        // GET: Monhocs/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mamonhoc,tenmh,sotinchi")] Monhoc monhoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monhoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monhoc);
        }

        // GET: Monhocs/Edit/5
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc.FindAsync(id);
            if (monhoc == null)
            {
                return NotFound();
            }
            return View(monhoc);
        }

        // POST: Monhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mamonhoc,tenmh,sotinchi")] Monhoc monhoc)
        {
            if (id != monhoc.mamonhoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monhoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonhocExists(monhoc.mamonhoc))
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
            return View(monhoc);
        }

        // GET: Monhocs/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc
                .FirstOrDefaultAsync(m => m.mamonhoc == id);
            if (monhoc == null)
            {
                return NotFound();
            }

            return View(monhoc);
        }

        // POST: Monhocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monhoc = await _context.Monhoc.FindAsync(id);
            _context.Monhoc.Remove(monhoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonhocExists(int id)
        {
            return _context.Monhoc.Any(e => e.mamonhoc == id);
        }
    }
}
