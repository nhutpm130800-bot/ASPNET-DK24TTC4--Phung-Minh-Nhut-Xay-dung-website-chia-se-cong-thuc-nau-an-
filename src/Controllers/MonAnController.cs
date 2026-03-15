using Microsoft.AspNetCore.Mvc;
using WebNauAn_TVU.Models;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebNauAn_TVU.Controllers
{
    public class MonAnController : Controller
    {
        private readonly AppDbContext _context;

        public MonAnController(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index(string searchString)
        {
            
            var monAns = _context.MonAn.Include(m => m.User).AsQueryable();

            
            if (!string.IsNullOrEmpty(searchString))
            {
                monAns = monAns.Where(s => s.TenMon.Contains(searchString));
            }

            return View(await monAns.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var monAn = await _context.MonAn
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (monAn == null) return NotFound();

            return View(monAn);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MonAn monAn)
        {
            
            monAn.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (monAn.ImageFile != null)
            {
                monAn.HinhAnh = await SaveImage(monAn.ImageFile);
            }

            _context.MonAn.Add(monAn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var monAn = await _context.MonAn.FindAsync(id);
            if (monAn == null) return NotFound();
            return View(monAn);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MonAn monAn)
        {
            if (id != monAn.Id) return NotFound();

            try
            {
                if (monAn.ImageFile != null)
                {
                    
                    monAn.HinhAnh = await SaveImage(monAn.ImageFile);
                }
                else
                {
                    
                    var existingMonAn = await _context.MonAn.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
                    monAn.HinhAnh = existingMonAn.HinhAnh;
                    monAn.UserId = existingMonAn.UserId;
                }

                _context.Update(monAn);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.MonAn.Any(e => e.Id == monAn.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }

       
        private async Task<string> SaveImage(Microsoft.AspNetCore.Http.IFormFile imageFile)
        {
            string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            if (!Directory.Exists(wwwRootPath)) Directory.CreateDirectory(wwwRootPath);

            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName)
                             + DateTime.Now.ToString("yymmssfff")
                             + Path.GetExtension(imageFile.FileName);
            string path = Path.Combine(wwwRootPath, fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return "images/" + fileName;
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var monAn = await _context.MonAn.Include(m => m.User).FirstOrDefaultAsync(m => m.Id == id);
            if (monAn == null) return NotFound();
            return View(monAn);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monAn = await _context.MonAn.FindAsync(id);
            if (monAn != null) _context.MonAn.Remove(monAn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}