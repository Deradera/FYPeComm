using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FYPeComm.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult ViewProduct()
        {
            return View();
        }
    }
}