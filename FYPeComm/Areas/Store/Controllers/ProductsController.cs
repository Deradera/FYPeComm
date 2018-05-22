using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FYPeComm.DAL;
using FYPeComm.Models;

namespace FYPeComm.Areas.Store.Controllers
{
    [Area("Store")]
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Store/Products
        public async Task<IActionResult> Index()
        {
            var productContext = _context.Product.Include(p => p.SubCat);
            return View(await productContext.ToListAsync());
        }

        // GET: Store/Products/Details/5
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

        // GET: Store/Products/Create
        public IActionResult Create()
        {
            ViewData["SubCatId"] = new SelectList(_context.ProdSubCat, "ProdSubCatId", "ProdSubCatName");
            return View();
        }

        // POST: Store/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdId,ProdName,ProdDesc,ProdPrice,ProdImg,SubCatId")] Product product)
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

        // GET: Store/Products/Edit/5
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

        // POST: Store/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProdId,ProdName,ProdDesc,ProdPrice,ProdImg,SubCatId")] Product product)
        {
            if (id != product.ProdId)
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

        // GET: Store/Products/Delete/5
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

        // POST: Store/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProdId == id);
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
