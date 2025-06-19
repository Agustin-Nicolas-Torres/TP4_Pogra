using TP4_LEANDRO.Controladores;
using TP4_LEANDRO.Modelos;

public class Pedido
{
    public Cliente Cliente { get; set; }
    public string NumeroSeguimiento { get; set; }
    public EstadoPedido Estado { get; set; }
    public DateTime Fecha { get; set; }
}