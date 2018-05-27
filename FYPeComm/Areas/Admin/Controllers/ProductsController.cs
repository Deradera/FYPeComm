using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FYPeComm.DAL;
using FYPeComm.Models;

namespace FYPeComm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var productContext = _context.Product.Include(p => p.SubCat);
            return View(await productContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.SubCat)
                .SingleOrDefaultAsync(m => m.ProdId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["SubCatId"] = new SelectList(_context.ProdSubCat, "ProdSubCatId", "ProdSubCatName");
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdId,ProdName,ProdDesc,ProdPrice,ProdImg,SubCatId,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProdId = Guid.NewGuid();
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCatId"] = new SelectList(_context.ProdSubCat, "ProdSubCatId", "ProdSubCatName", product.SubCatId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProdId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["SubCatId"] = new SelectList(_context.ProdSubCat, "ProdSubCatId", "ProdSubCatName", product.SubCatId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid ProdId, [Bind("ProdId,ProdName,ProdDesc,ProdPrice,ProdImg,SubCatId,Stock")] Product product)
        {
            if (ProdId != product.ProdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProdId))
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
            ViewData["SubCatId"] = new SelectList(_context.ProdSubCat, "ProdSubCatId", "ProdSubCatName", product.SubCatId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.SubCat)
                .SingleOrDefaultAsync(m => m.ProdId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid ProdId)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProdId == ProdId);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return _context.Product.Any(e => e.ProdId == id);
        }
    }
}
