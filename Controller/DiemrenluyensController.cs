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
    public class DiemrenluyensController : Controller
    {
        private readonly QuanLiSVContext _context;

        public DiemrenluyensController(QuanLiSVContext context)
        {
            _context = context;
        }

        // GET: Diemrenluyens
        public async Task<IActionResult> Index()
        {
            var quanLiSVContext = _context.Diemrenluyen.Include(d => d.Sinhvien);
            return View(await quanLiSVContext.ToListAsync());
        }

        // GET: Diemrenluyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemrenluyen = await _context.Diemrenluyen
                .Include(d => d.Sinhvien)
                .FirstOrDefaultAsync(m => m.masv == id);
            if (diemrenluyen == null)
            {
                return NotFound();
            }

            return View(diemrenluyen);
        }

        // GET: Diemrenluyens/Create
        public IActionResult Create()
        {
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh");
            return View();
        }

        // POST: Diemrenluyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("masv,Sinhvien_Id,Hoten,diemrenluyen")] Diemrenluyen diemrenluyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diemrenluyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh", diemrenluyen.Sinhvien_Id);
            return View(diemrenluyen);
        }

        // GET: Diemrenluyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemrenluyen = await _context.Diemrenluyen.FindAsync(id);
            if (diemrenluyen == null)
            {
                return NotFound();
            }
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh", diemrenluyen.Sinhvien_Id);
            return View(diemrenluyen);
        }

        // POST: Diemrenluyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("masv,Sinhvien_Id,Hoten,diemrenluyen")] Diemrenluyen diemrenluyen)
        {
            if (id != diemrenluyen.masv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diemrenluyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemrenluyenExists(diemrenluyen.masv))
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
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh", diemrenluyen.Sinhvien_Id);
            return View(diemrenluyen);
        }

        // GET: Diemrenluyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemrenluyen = await _context.Diemrenluyen
                .Include(d => d.Sinhvien)
                .FirstOrDefaultAsync(m => m.masv == id);
            if (diemrenluyen == null)
            {
                return NotFound();
            }

            return View(diemrenluyen);
        }

        // POST: Diemrenluyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diemrenluyen = await _context.Diemrenluyen.FindAsync(id);
            _context.Diemrenluyen.Remove(diemrenluyen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemrenluyenExists(int id)
        {
            return _context.Diemrenluyen.Any(e => e.masv == id);
        }
    }
}
