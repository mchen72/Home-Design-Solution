using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HDS_WebApp.Data;
using HDS_WebApp.Models;

namespace HDS_WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductData.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productData = await _context.ProductData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productData == null)
            {
                return NotFound();
            }

            return View(productData);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Cost,CurrentInventory,Description,LargeItem,ListPrice,ModelNumber,SerialNumber,CategoryName,Name")] ProductData productData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productData);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productData = await _context.ProductData.FindAsync(id);
            if (productData == null)
            {
                return NotFound();
            }
            return View(productData);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Brand,Cost,CurrentInventory,Description,LargeItem,ListPrice,ModelNumber,SerialNumber,CategoryName,Name")] ProductData productData)
        {
            if (id != productData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDataExists(productData.Id))
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
            return View(productData);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productData = await _context.ProductData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productData == null)
            {
                return NotFound();
            }

            return View(productData);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var productData = await _context.ProductData.FindAsync(id);
            _context.ProductData.Remove(productData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDataExists(string id)
        {
            return _context.ProductData.Any(e => e.Id == id);
        }
    }
}
