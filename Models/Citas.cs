using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OpticaSanfrancisco.Models
{
     [Table ("Citas")]
    public class Citas
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [Column("id")]
        public int id { get; set; }

        [Column("TipoDeCita")]
        public string TipoDeCita { get; set; }


        /*---------------Informacion de datos personales ---------------*/

        [Column("Nombres")]
        public string Nombres { get; set; }

        [Column("Apellidos")]
        public string Apellidos { get; set; }

        [Column("Email")]
        public string Email{get; set;}

        [Column("Celular")]
        public int Celular{get; set;}
        
        [Column("DNI")]
        public int DNI { get; set; }
        
        /*----------- Seleccion de Hora ------------*/
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public string Hora {get; set;}
    }
}