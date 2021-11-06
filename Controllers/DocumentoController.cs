using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpticaSanfrancisco.Data;
using Rotativa.AspNetCore;

namespace OpticaSanfrancisco.Controllers
{
    public class DocumentoController : Controller
    {

        private readonly ApplicationDbContext _context;


        public DocumentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers/ContactPDF
        public async Task<IActionResult> Documento()
        {
           // return View(await _context.Documento.ToListAsync());
             return new ViewAsPdf("Documento", await _context.Productos.ToListAsync())
            {
                 // ...
            };
            
        }
          [HttpGet]
        public IActionResult Formulario()
        {
            return View();
        }

   


     
    }
}