using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PasteleriaLaMiel.Models;
using PasteleriaLaMiel.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace PasteleriaLaMiel.Controllers
{
    
    public class ContactanosController : Controller
    {
        private readonly ILogger<ContactanosController> _logger;
        private readonly ApplicationDbContext _context;

        public ContactanosController(ILogger<ContactanosController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Contactanos()
        {
            return View();
        }

        public IActionResult Index()
        {
            var listacontactanos = _context.Contactanos.ToList();
            ViewData["message"]="";
            return View(listacontactanos);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public IActionResult Create(Contactanos objContactanos)
        {
            _context.Add(objContactanos);
            _context.SaveChanges();
            ViewData["Message"] = "El Mensaje fue enviado con éxito";
            return View();
        }
public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactanos = await _context.Contactanos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactanos == null)
            {
                return NotFound();
            }

            return View(contactanos);
        }
    


 [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactanos = await _context.Contactanos.FindAsync(id);
            _context.Contactanos.Remove(contactanos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





   public IActionResult ExportarExcel()
            {
                string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var contactanos = _context.Contactanos.AsNoTracking().ToList();
                using (var libro = new ExcelPackage())
                    {
                        var worksheet = libro.Workbook.Worksheets.Add("Contactanos");
                        worksheet.Cells["A1"].LoadFromCollection(contactanos, PrintHeaders: true);
                        for (var col = 1; col < contactanos.Count + 1; col++)
                            {
                                worksheet.Column(col).AutoFit();
                            }
        // Agregar formato de tabla
        var tabla = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: contactanos.Count + 1, toColumn: 5), "Contactanos");
        tabla.ShowHeader = true;
        tabla.TableStyle = TableStyles.Light6;
        tabla.ShowTotal = true;

        return File(libro.GetAsByteArray(), excelContentType, "Contactanos.xlsx");
    }
}
    




    }
}
