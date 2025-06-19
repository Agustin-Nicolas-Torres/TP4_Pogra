using System;

namespace TP4_LEANDRO.Modelos
{
    [Serializable]
    public class Cliente // Cambiado a 'public'
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Calle { get; set; }
        public string NumeroCalle { get; set; }
        public string Provincia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}