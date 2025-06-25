using System;

namespace TP4_LEANDRO.Modelos
{
    [Serializable] // Puede ser transmitido a través de la red o guardado en un archivo
    public class Cliente 
    {
        public int ID {  get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public bool Es_Admin { get; set; }
        public bool Es_Tecn { get; set; }
        public string DNI { get; set; }
        public string Calle { get; set; }
        public string NumeroCalle { get; set; }
        public string Provincia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}