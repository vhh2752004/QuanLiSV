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
    public class DiemhoctapsController : Controller
    {
        private readonly QuanLiSVContext _context;

        public DiemhoctapsController(QuanLiSVContext context)
        {
            _context = context;
        }

        // GET: Diemhoctaps
        public async Task<IActionResult> Index()
        {
            var quanLiSVContext = _context.Diemhoctap.Include(d => d.Monhoc).Include(d => d.Sinhvien);
            return View(await quanLiSVContext.ToListAsync());
        }

        // GET: Diemhoctaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemhoctap = await _context.Diemhoctap
                .Include(d => d.Monhoc)
                .Include(d => d.Sinhvien)
                .FirstOrDefaultAsync(m => m.masv == id);
            if (diemhoctap == null)
            {
                return NotFound();
            }

            return View(diemhoctap);
        }

        // GET: Diemhoctaps/Create
        public IActionResult Create()
        {
            ViewData["Monhoc_Id"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh");
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh");
            return View();
        }

        // POST: Diemhoctaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("masv,Sinhvien_Id,Monhoc_Id,Diemthi,Diemquatrinh")] Diemhoctap diemhoctap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diemhoctap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Monhoc_Id"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh", diemhoctap.Monhoc_Id);
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh", diemhoctap.Sinhvien_Id);
            return View(diemhoctap);
        }

        // GET: Diemhoctaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemhoctap = await _context.Diemhoctap.FindAsync(id);
            if (diemhoctap == null)
            {
                return NotFound();
            }
            ViewData["Monhoc_Id"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh", diemhoctap.Monhoc_Id);
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh", diemhoctap.Sinhvien_Id);
            return View(diemhoctap);
        }

        // POST: Diemhoctaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("masv,Sinhvien_Id,Monhoc_Id,Diemthi,Diemquatrinh")] Diemhoctap diemhoctap)
        {
            if (id != diemhoctap.masv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diemhoctap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemhoctapExists(diemhoctap.masv))
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
            ViewData["Monhoc_Id"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh", diemhoctap.Monhoc_Id);
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh", diemhoctap.Sinhvien_Id);
            return View(diemhoctap);
        }

        // GET: Diemhoctaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemhoctap = await _context.Diemhoctap
                .Include(d => d.Monhoc)
                .Include(d => d.Sinhvien)
                .FirstOrDefaultAsync(m => m.masv == id);
            if (diemhoctap == null)
            {
                return NotFound();
            }

            return View(diemhoctap);
        }

        // POST: Diemhoctaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diemhoctap = await _context.Diemhoctap.FindAsync(id);
            _context.Diemhoctap.Remove(diemhoctap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemhoctapExists(int id)
        {
            return _context.Diemhoctap.Any(e => e.masv == id);
        }
    }
}
