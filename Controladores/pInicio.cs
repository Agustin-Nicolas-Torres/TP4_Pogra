using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4_LEANDRO.Modelos;
using System.Data.SQLite;

namespace TP4_LEANDRO.Controladores
{
    internal class pInicio
    {
        public static List<Cliente> GetAll()
        {
            List<Cliente> Cliente = new List<Cliente>();

            SQLiteCommand cmd = new SQLiteCommand("SELECT ID, Nombre, Apellido, N_User, Contraseña, Es_Admin, Email FROM Usuario");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader Client_Conec = cmd.ExecuteReader();

            while (Client_Conec.Read())
            {
                Cliente a = new Cliente();
                a.ID = Client_Conec.GetInt32(0);
                a.Nombre = Client_Conec.GetString(1);
                a.Apellido = Client_Conec.GetString(2);
                a.Usuario = Client_Conec.GetString(3);
                a.Contraseña = Client_Conec.GetString(4);
                a.Es_Admin = Client_Conec.GetInt32(5) == 0;
                a.Email = Client_Conec.GetString(6);

                Cliente.Add(a);

            }
            return Cliente;
        }
    }
}
