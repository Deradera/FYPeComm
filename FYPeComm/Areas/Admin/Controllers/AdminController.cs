using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FYPeComm.DAL;
using FYPeComm.Models;

namespace FYPeComm.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ProductContext _context;

        public AdminController(ProductContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult ProductDetail()
        //{
        //    return View();
        //}

        //public IActionResult Products()
        //{
        //    return View();
        //}
    }
}
