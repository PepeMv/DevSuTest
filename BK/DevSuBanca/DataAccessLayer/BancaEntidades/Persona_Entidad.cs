using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancaEntidades
{
    [Table("persona")]
    public partial class Persona: EntidadBase
    {

        public Persona()
        {

        }
        [Key]
        [Column("Id")]
        public int Id { get; set; }


        [Column("Nombre")]
        public string Nombre { get; set; }



        [Column("Genero")]
        public string Genero { get; set; }


        [Column("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }



        [Column("Identificacion")]
        public string Identificacion { get; set; }



        [Column("Direccion")]
        public string Direccion { get; set; }



        [Column("Telefono")]
        public string Telefono { get; set; }


        public Persona(string nombre,
                       string genero,
                       DateTime fechaNacimiento,
                       string identificacion,
                       string direccion,
                       string telefono)
        {
            Nombre = nombre;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            Identificacion = identificacion;
            Direccion = direccion;
            Telefono = telefono;
        }

    }
}
