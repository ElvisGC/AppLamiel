using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PasteleriaLaMiel.Data;
using PasteleriaLaMiel.Models;
using Microsoft.AspNetCore.Identity;
using Rotativa.AspNetCore;

namespace PasteleriaLaMiel.Controllers
{
    public class ProformaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProformaController(ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Proforma
        public async Task<IActionResult> Carrito()
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.Carrito select o;
            items = items.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(userID));
            
            return View(await items.ToListAsync());
        }

        // GET: Proforma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.Carrito
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proforma == null)
            {
                return NotFound();
            }

            return View(proforma);
        }

        // GET: Proforma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proforma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,Quantity,Price")] Proforma proforma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proforma);
        }

        // GET: Proforma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.Carrito.FindAsync(id);
            if (proforma == null)
            {
                return NotFound();
            }
            return View(proforma);
        }

        // POST: Proforma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantity,Price")] Proforma proforma)
        {
            if (id != proforma.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proforma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProformaExists(proforma.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Carrito));
            }
            return View(proforma);
        }

        // GET: Proforma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.Carrito
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proforma == null)
            {
                return NotFound();
            }

            return View(proforma);
        }

        // POST: Proforma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proforma = await _context.Carrito.FindAsync(id);
            _context.Carrito.Remove(proforma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProformaExists(int id)
        {
            return _context.Carrito.Any(e => e.ID == id);
        }
        public IActionResult Proceso()
        {
            var listContactos=_context.Carrito.ToList();
            return View(listContactos);
        }

         public async Task<IActionResult> Documento()
        {
           // return View(await _context.Documento.ToListAsync());
             var userID = _userManager.GetUserName(User);
            var items = from o in _context.Carrito select o;
            items = items.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(userID));
            
           return new ViewAsPdf("Documento",await items.ToListAsync());
        }
//****************************************************************************************
       [HttpPost]
        public IActionResult BorrarRegion(int id) {
            var carrito = _context.Carrito.Find(id);
            _context.Remove(carrito);
            _context.SaveChanges();

            return RedirectToAction("Carrito");
        }
          public IActionResult Editar(int id) {
            var region = _context.Carrito.Find(id);
            return View(region);
        }

        [HttpPost]
        public IActionResult Editar(Proforma r) {
            if (ModelState.IsValid) {
                var region = _context.Carrito.Find(r.ID);
                region.Quantity = r.Quantity;
                _context.SaveChanges();
                return RedirectToAction("Carrito");
            }
            return View(r);
        }

        public IActionResult EditarConfirmacion() {
            return View();
        }
    }
}
