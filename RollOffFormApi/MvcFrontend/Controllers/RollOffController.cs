using Microsoft.AspNetCore.Mvc;
using MvcFrontend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFrontend.Controllers
{
    public class RollOffController : Controller
    {
        

        private readonly IRollOff _services;

        public RollOffController(IRollOff service)
        {
            _services = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index()
        {
            var products = await _services.Find();
            return View(products);
        }
    }
}

