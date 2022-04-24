using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassDragonArchive.Controllers
{
    public class PageTwoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
