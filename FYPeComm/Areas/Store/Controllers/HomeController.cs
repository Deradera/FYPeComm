using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FYPeComm.Models;
using FYPeComm.DAL;
using Microsoft.EntityFrameworkCore;

namespace FYPeComm.Controllers
{
    [Area("Store")]
    public class HomeController : Controller
    {
        private readonly ProductContext _context;

        public HomeController(ProductContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductSelection()
        {
            var productContext = _context.Product.Include(p => p.SubCat);
            return View(await productContext.ToListAsync());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
