using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpticaSanfrancisco.Models;

namespace OpticaSanfrancisco.Controllers
{
    public class NosotrosController : Controller
    
    {
          public IActionResult Index()
        {
            return View();
        }
    }
}