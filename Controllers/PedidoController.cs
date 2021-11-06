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
    
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly ApplicationDbContext _context;

        public PedidoController(ILogger<PedidoController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Pedido()
        {
            return View();
        }

        public IActionResult Index()
        {
            var listapedido = _context.Pedido.ToList();
            ViewData["message"]="";
            return View(listapedido);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public IActionResult Create(Pedido objPedido)
        {
            _context.Add(objPedido);
            _context.SaveChanges();
            ViewData["Message"] = "Se  genero su pedido";
            return View();
        }




public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }
    


 

 [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }







   public IActionResult ExportarExcel()
            {
                string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var pedido = _context.Pedido.AsNoTracking().ToList();
                using (var libro = new ExcelPackage())
                    {
                        var worksheet = libro.Workbook.Worksheets.Add("Pedido");
                        worksheet.Cells["A1"].LoadFromCollection(pedido, PrintHeaders: true);
                        for (var col = 1; col < pedido.Count + 1; col++)
                            {
                                worksheet.Column(col).AutoFit();
                            }
        // Agregar formato de tabla
        var tabla = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: pedido.Count + 1, toColumn: 5), "Pedido");
        tabla.ShowHeader = true;
        tabla.TableStyle = TableStyles.Light6;
        tabla.ShowTotal = true;

        return File(libro.GetAsByteArray(), excelContentType, "Pedido.xlsx");
    }
}
    




    }
}
