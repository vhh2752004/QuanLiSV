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
    public class SinhviensController : Controller
    {
        private readonly QuanLiSVContext _context;

        public SinhviensController(QuanLiSVContext context)
        {
            _context = context;
        }

        // GET: Sinhviens1
        public async Task<IActionResult> Index()
        {
            var quanLiSVContext = _context.Sinhvien.Include(s => s.Lop);
            return View(await quanLiSVContext.ToListAsync());
        }

        // GET: Sinhviens1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien
                .Include(s => s.Lop)
                .FirstOrDefaultAsync(m => m.masv == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // GET: Sinhviens1/Create
        public IActionResult Create()
        {
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "malop", "tenlop");
            return View();
        }

        // POST: Sinhviens1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("masv,Hoten,ngaysinh,gioitinh,Lop_Id")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "malop", "tenlop", sinhvien.Lop_Id);
            return View(sinhvien);
        }

        // GET: Sinhviens1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "malop", "tenlop", sinhvien.Lop_Id);
            return View(sinhvien);
        }

        // POST: Sinhviens1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("masv,Hoten,ngaysinh,gioitinh,Lop_Id")] Sinhvien sinhvien)
        {
            if (id != sinhvien.masv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhvienExists(sinhvien.masv))
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
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "malop", "tenlop", sinhvien.Lop_Id);
            return View(sinhvien);
        }

        // GET: Sinhviens1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien
                .Include(s => s.Lop)
                .FirstOrDefaultAsync(m => m.masv == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // POST: Sinhviens1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sinhvien = await _context.Sinhvien.FindAsync(id);
            _context.Sinhvien.Remove(sinhvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhvienExists(int id)
        {
            return _context.Sinhvien.Any(e => e.masv == id);
        }
    }
}
