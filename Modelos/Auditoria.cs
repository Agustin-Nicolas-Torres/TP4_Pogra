using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_LEANDRO.Modelos
{
    [Serializable]
    public class Auditoria
    {
        public int ID { get; set; }
        public string Fecha { get; set; }
        public string Usuario { get; set; }
        public string Accion { get; set; }

    }
}
