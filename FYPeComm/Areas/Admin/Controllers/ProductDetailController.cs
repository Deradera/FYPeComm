using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FYPeComm.DAL;
using FYPeComm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FYPeComm.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ProductDetailController : Controller
    {
        private readonly ProductContext _context;

        public ProductDetailController(ProductContext context)
        {
            _context = context;
        }

        public IActionResult ViewProduct()
        {
            return View();
        }

        // GET: ProdSizeColourLinks
        public async Task<IActionResult> ProductDetailIndex()
        {
            var productContext = _context.ProductSizeColourLinks.Include(p => p.Colour).Include(p => p.Prod).Include(p => p.Size);
            return View(await productContext.ToListAsync());
        }

        // GET: ProdSizeColourLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodSizeColourLink = await _context.ProductSizeColourLinks
                .Include(p => p.Colour)
                .Include(p => p.Prod)
                .Include(p => p.Size)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (prodSizeColourLink == null)
            {
                return NotFound();
            }

            return View(prodSizeColourLink);
        }

        // GET: ProdSizeColourLinks/Create
        public IActionResult Create()
        {
            ViewData["ColourId"] = new SelectList(_context.Colour, "ColourId", "ColourName");
            ViewData["ProdId"] = new SelectList(_context.Product, "ProdId", "ProdDesc");
            ViewData["SizeId"] = new SelectList(_context.Size, "SizeId", "SizeName");
            return View();
        }

        // POST: ProdSizeColourLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdId,SizeId,ColourId,Id")] ProdSizeColourLink prodSizeColourLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodSizeColourLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProductDetailIndex));
            }
            ViewData["ColourId"] = new SelectList(_context.Colour, "ColourId", "ColourName", prodSizeColourLink.ColourId);
            ViewData["ProdId"] = new SelectList(_context.Product, "ProdId", "ProdDesc", prodSizeColourLink.ProdId);
            ViewData["SizeId"] = new SelectList(_context.Size, "SizeId", "SizeName", prodSizeColourLink.SizeId);
            return View(prodSizeColourLink);
        }

        // GET: ProdSizeColourLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodSizeColourLink = await _context.ProductSizeColourLinks.SingleOrDefaultAsync(m => m.Id == id);
            if (prodSizeColourLink == null)
            {
                return NotFound();
            }
            ViewData["ColourId"] = new SelectList(_context.Colour, "ColourId", "ColourName", prodSizeColourLink.ColourId);
            ViewData["ProdId"] = new SelectList(_context.Product, "ProdId", "ProdDesc", prodSizeColourLink.ProdId);
            ViewData["SizeId"] = new SelectList(_context.Size, "SizeId", "SizeName", prodSizeColourLink.SizeId);
            return View(prodSizeColourLink);
        }

        // POST: ProdSizeColourLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdId,SizeId,ColourId,Id")] ProdSizeColourLink prodSizeColourLink)
        {
            if (id != prodSizeColourLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodSizeColourLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdSizeColourLinkExists(prodSizeColourLink.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ProductDetailIndex));
            }
            ViewData["ColourId"] = new SelectList(_context.Colour, "ColourId", "ColourName", prodSizeColourLink.ColourId);
            ViewData["ProdId"] = new SelectList(_context.Product, "ProdId", "ProdDesc", prodSizeColourLink.ProdId);
            ViewData["SizeId"] = new SelectList(_context.Size, "SizeId", "SizeName", prodSizeColourLink.SizeId);
            return View(prodSizeColourLink);
        }

        // GET: ProdSizeColourLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodSizeColourLink = await _context.ProductSizeColourLinks
                .Include(p => p.Colour)
                .Include(p => p.Prod)
                .Include(p => p.Size)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (prodSizeColourLink == null)
            {
                return NotFound();
            }

            return View(prodSizeColourLink);
        }

        // POST: ProdSizeColourLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodSizeColourLink = await _context.ProductSizeColourLinks.SingleOrDefaultAsync(m => m.Id == id);
            _context.ProductSizeColourLinks.Remove(prodSizeColourLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ProductDetailIndex));
        }

        private bool ProdSizeColourLinkExists(int id)
        {
            return _context.ProductSizeColourLinks.Any(e => e.Id == id);
        }
    }
}