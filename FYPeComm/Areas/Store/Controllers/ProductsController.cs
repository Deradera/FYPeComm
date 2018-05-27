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

            var RelevantPSCL = _context.ProductSizeColourLinks.Where(p => p.ProdId == product.ProdId);
            var RelevantColours = _context.Colour.Where(c => RelevantPSCL.Any(p => p.ColourId == c.ColourId)).ToList();
            var RelevantSizes = _context.Size.Where(s => RelevantPSCL.Any(p => p.SizeId == s.SizeId)).ToList();

            return View(product);
        }

        public bool IsDisabled(Product product)
        {

        }

    }
}
