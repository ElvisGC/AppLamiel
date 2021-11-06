using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OpticaSanfrancisco.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<OpticaSanfrancisco.Models.Citas> Citas {get; set;} 
        public DbSet<OpticaSanfrancisco.Models.Contactanos> Contactanos { get; set; }
        public DbSet<OpticaSanfrancisco.Models.Productos> Productos { get; set; }
        public DbSet<OpticaSanfrancisco.Models.Proforma> Carrito { get; set; }



    }
}
