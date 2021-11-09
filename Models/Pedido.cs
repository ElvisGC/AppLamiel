using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PasteleriaLaMiel.Models
{
     
    [Table("t_pedido")]
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("apellidos")]
        public string Apellidos { get; set; }

        [Column("celular")]
        public string Celular { get; set; }

       


        [Column("email")]
        public string Email { get; set; }


      



        [Column("mensaje")]
        public string Mensaje { get; set; }
        
         [NotMapped]
        public String Status {get; set;}
    

        
    }


    
}