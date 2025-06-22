using System;

namespace TP4_LEANDRO.Modelos
{
    [Serializable]
    public class Cliente // Cambiado a 'public'
    {
        public int ID {  get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public bool Es_Admin { get; set; }
        public string DNI { get; set; }
        public string Calle { get; set; }
        public string NumeroCalle { get; set; }
        public string Provincia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}