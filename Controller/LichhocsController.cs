using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLiSV.Data;
using QuanLiSV.Models;

namespace QuanLiSV.Controllers
{
    public class LichhocsController : Controller
    {
        private readonly QuanLiSVContext _context;

        public LichhocsController(QuanLiSVContext context)
        {
            _context = context;
        }

        // GET: Lichhocs
        public async Task<IActionResult> Index()
        {
            var quanLiSVContext = _context.Lichhoc.Include(l => l.Monhoc);
            return View(await quanLiSVContext.ToListAsync());
        }

        // GET: Lichhocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichhoc = await _context.Lichhoc
                .Include(l => l.Monhoc)
                .FirstOrDefaultAsync(m => m.mamonhoc == id);
            if (lichhoc == null)
            {
                return NotFound();
            }

            return View(lichhoc);
        }

        // GET: Lichhocs/Create
        public IActionResult Create()
        {
            ViewData["Monhoc_ID"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh");
            return View();
        }

        // POST: Lichhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mamonhoc,thuhoc,giobatdau,gioketthuc,phonghoc,Monhoc_ID")] Lichhoc lichhoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lichhoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Monhoc_ID"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh", lichhoc.Monhoc_ID);
            return View(lichhoc);
        }

        // GET: Lichhocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichhoc = await _context.Lichhoc.FindAsync(id);
            if (lichhoc == null)
            {
                return NotFound();
            }
            ViewData["Monhoc_ID"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh", lichhoc.Monhoc_ID);
            return View(lichhoc);
        }

        // POST: Lichhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mamonhoc,thuhoc,giobatdau,gioketthuc,phonghoc,Monhoc_ID")] Lichhoc lichhoc)
        {
            if (id != lichhoc.mamonhoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichhoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichhocExists(lichhoc.mamonhoc))
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
            ViewData["Monhoc_ID"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh", lichhoc.Monhoc_ID);
            return View(lichhoc);
        }

        // GET: Lichhocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichhoc = await _context.Lichhoc
                .Include(l => l.Monhoc)
                .FirstOrDefaultAsync(m => m.mamonhoc == id);
            if (lichhoc == null)
            {
                return NotFound();
            }

            return View(lichhoc);
        }

        // POST: Lichhocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lichhoc = await _context.Lichhoc.FindAsync(id);
            _context.Lichhoc.Remove(lichhoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LichhocExists(int id)
        {
            return _context.Lichhoc.Any(e => e.mamonhoc == id);
        }
    }
}
