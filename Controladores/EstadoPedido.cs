using System;
using TP4_LEANDRO.Modelos;

namespace TP4_LEANDRO.Controladores
{
    public enum EstadoPedido
    {
        Ingresado,
        EnProceso,
        Finalizado
    }

    internal class Pedido
    {
        public Cliente Cliente { get; set; }
        public string NumeroSeguimiento { get; set; }
        public EstadoPedido Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}