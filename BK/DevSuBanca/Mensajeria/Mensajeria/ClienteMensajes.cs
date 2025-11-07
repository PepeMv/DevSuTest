namespace Mensajeria
{
    public class NuevoClienteMe
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }
        public bool Estado { get; set; }


        public NuevoClienteMe(string nombre,
                            string genero,
                            DateTime fechaNacimiento,
                            string identificacion,
                            string direccion,
                            string telefono,
                            string contrasenia,
                            bool estado)
        {
            Nombre = nombre;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            Identificacion = identificacion;
            Direccion = direccion;
            Telefono = telefono;
            Contrasenia = contrasenia;
            Estado = estado;
        }
    }


    public class ActualizaClienteMe
    {
        public int IdentificadorCliente { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }
        public bool Estado { get; set; }


        public ActualizaClienteMe(int identificadorCliente,
                                string nombre,
                                string genero,
                                DateTime fechaNacimiento,
                                string identificacion,
                                string direccion,
                                string telefono,
                                string contrasenia,
                                bool estado)
        {
            IdentificadorCliente = identificadorCliente;
            Nombre = nombre;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            Identificacion = identificacion;
            Direccion = direccion;
            Telefono = telefono;
            Contrasenia = contrasenia;
            Estado = estado;
        }

    }


    public class EliminaClienteMe
    {
        public int IdentificadorCliente { get; set; }

        public EliminaClienteMe(int identificadorCliente)
        {
            IdentificadorCliente = identificadorCliente;
        }
    }



    public class ResumenCliente
    {
        public int IdentificadorCliente { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }

        public bool Estado { get; set; }

        public ResumenCliente(int identificadorCliente,
                                string nombre,
                                string genero,
                                DateTime fechaNacimiento,
                                string identificacion,
                                string direccion,
                                string telefono,
                                string contrasenia,
                                bool estado)
        {
            IdentificadorCliente = identificadorCliente;
            Nombre = nombre;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            Identificacion = identificacion;
            Direccion = direccion;
            Telefono = telefono;
            Contrasenia = contrasenia;
            Estado = estado;
        }

    }

}
