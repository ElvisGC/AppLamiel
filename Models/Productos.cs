using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasteleriaLaMiel.Models
{
    [Table("t_product")]
    public class Productos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}
        public String Codigo {get; set;}
        public String Familia { get; set; }
        public String Linea { get; set; }
        public String Categoria { get; set; }
        public String Diseño { get; set; }
        public String Descripcion_Producto { get; set; }
        public String Marca { get; set; }
        public String Material { get; set; }
        public String Talla { get; set; }
        public String Kalibre { get; set; }
        public String Color { get; set; }
        public String Descrip_Color { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public String Imagen { get; set; }
      
        public String Status { get; set; }
       


        public virtual ICollection<Proforma> ProformaItems { get; set; }

    }
}