using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PasteleriaLaMiel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PasteleriaLaMiel.Models.Pedido> Pedido {get; set;} 
        public DbSet<PasteleriaLaMiel.Models.Contactanos> Contactanos { get; set; }
        public DbSet<PasteleriaLaMiel.Models.Productos> Productos { get; set; }
        public DbSet<PasteleriaLaMiel.Models.Proforma> Carrito { get; set; }



    }
}
