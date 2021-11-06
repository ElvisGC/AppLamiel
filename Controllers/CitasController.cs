using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PasteleriaLaMiel.Data;
using PasteleriaLaMiel.Models;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using Microsoft.EntityFrameworkCore;

namespace PasteleriaLaMiel.Controllers
{
    public class CitasController : Controller
    {
        private readonly ILogger<CitasController> _logger;
        
        private readonly ApplicationDbContext _context;

        public CitasController(ILogger<CitasController> logger,
        ApplicationDbContext context)
        {
            _logger = logger;
            _context=context;
        }
         
         public IActionResult Citas()
        { 
           

            var listacitas = _context.Citas.ToList();
            ViewData["message"]="";
            return View(listacitas);
        }
         [HttpGet]
        public IActionResult NuevaCita()
        {
            return View();
        }
         [HttpPost]
        public IActionResult NuevaCita(Citas Npersonal)
        {
            _context.Add(Npersonal);
            _context.SaveChanges();
            ViewData["Message"] = "La cita ya esta registrada";
            return View();
        }

          /***************BORRAR **********/
        public IActionResult BorrarCitas(int id){
            /*_context.Regiones.First(r =>r.Id==id);*/ /* primera forma de borrar*/
            var citas=_context.Citas.Find(id);// segunda forma 
            _context.Remove(citas);
            _context.SaveChanges();
            return RedirectToAction("Citas");
        }

        /***************EDITAR **********/

         public IActionResult EditarCitas(int id){
             var citas=_context.Citas.Find(id);

            return View(citas);

        }
        [HttpPost]
        public IActionResult EditarCitas(Citas r){
            if(ModelState.IsValid)
            {
                var citas=_context.Citas.Find(r.id);
                citas.TipoDeCita=r.TipoDeCita;
                citas.Nombres=r.Nombres;
                citas.Apellidos=r.Apellidos;
                citas.Email=r.Email;
                citas.Celular=r.Celular;
                citas.DNI=r.DNI;
                citas.Fecha=r.Fecha;
                citas.Hora=r.Hora;
                
               
                _context.SaveChanges();
                
            }
             ViewData["Message"] = "La cita se edito";
            return View(r);
        }
        public IActionResult ExportarExcel()
            {
                string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var citas = _context.Citas.AsNoTracking().ToList();
                using (var libro = new ExcelPackage())
                    {
                        var worksheet = libro.Workbook.Worksheets.Add("Citas");
                        worksheet.Cells["A1"].LoadFromCollection(citas, PrintHeaders: true);
                        for (var col = 1; col < citas.Count + 1; col++)
                            {
                                worksheet.Column(col).AutoFit();
                            }
        // Agregar formato de tabla
        var tabla = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: citas.Count + 1, toColumn: 5), "Pedidos");
        tabla.ShowHeader = true;
        tabla.TableStyle = TableStyles.Light6;
        tabla.ShowTotal = true;

        return File(libro.GetAsByteArray(), excelContentType, "Pedidos.xlsx");
    }
}
    

    }
}