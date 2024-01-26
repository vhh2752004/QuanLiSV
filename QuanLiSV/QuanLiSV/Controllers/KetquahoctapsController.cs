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
    public class KetquahoctapsController : Controller
    {
        private readonly QuanLiSVContext _context;

        public KetquahoctapsController(QuanLiSVContext context)
        {
            _context = context;
        }

        // GET: Ketquahoctaps
        public async Task<IActionResult> Index()
        {
            var quanLiSVContext = _context.Ketquahoctap.Include(k => k.Monhoc).Include(k => k.Sinhvien);
            return View(await quanLiSVContext.ToListAsync());
        }

        // GET: Ketquahoctaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketquahoctap = await _context.Ketquahoctap
                .Include(k => k.Monhoc)
                .Include(k => k.Sinhvien)
                .FirstOrDefaultAsync(m => m.masv == id);
            if (ketquahoctap == null)
            {
                return NotFound();
            }

            return View(ketquahoctap);
        }

        // GET: Ketquahoctaps/Create
        public IActionResult Create()
        {
            ViewData["Monhoc_Id"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh");
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh");
            return View();
        }

        // POST: Ketquahoctaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("masv,Sinhvien_Id,Monhoc_Id,Hocky,Diemtongket")] Ketquahoctap ketquahoctap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ketquahoctap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Monhoc_Id"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh", ketquahoctap.Monhoc_Id);
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh", ketquahoctap.Sinhvien_Id);
            return View(ketquahoctap);
        }

        // GET: Ketquahoctaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketquahoctap = await _context.Ketquahoctap.FindAsync(id);
            if (ketquahoctap == null)
            {
                return NotFound();
            }
            ViewData["Monhoc_Id"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh", ketquahoctap.Monhoc_Id);
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh", ketquahoctap.Sinhvien_Id);
            return View(ketquahoctap);
        }

        // POST: Ketquahoctaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("masv,Sinhvien_Id,Monhoc_Id,Hocky,Diemtongket")] Ketquahoctap ketquahoctap)
        {
            if (id != ketquahoctap.masv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ketquahoctap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KetquahoctapExists(ketquahoctap.masv))
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
            ViewData["Monhoc_Id"] = new SelectList(_context.Monhoc, "mamonhoc", "tenmh", ketquahoctap.Monhoc_Id);
            ViewData["Sinhvien_Id"] = new SelectList(_context.Sinhvien, "masv", "gioitinh", ketquahoctap.Sinhvien_Id);
            return View(ketquahoctap);
        }

        // GET: Ketquahoctaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketquahoctap = await _context.Ketquahoctap
                .Include(k => k.Monhoc)
                .Include(k => k.Sinhvien)
                .FirstOrDefaultAsync(m => m.masv == id);
            if (ketquahoctap == null)
            {
                return NotFound();
            }

            return View(ketquahoctap);
        }

        // POST: Ketquahoctaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ketquahoctap = await _context.Ketquahoctap.FindAsync(id);
            _context.Ketquahoctap.Remove(ketquahoctap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KetquahoctapExists(int id)
        {
            return _context.Ketquahoctap.Any(e => e.masv == id);
        }
    }
}
