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

            SQLiteCommand cmd = new SQLiteCommand("SELECT ID, Nombre, Apellido, N_User, Contraseña, Es_Admin, Email, Es_Tecn FROM Usuario");
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
                object esAdminValue = Client_Conec.GetValue(5);
                a.Es_Admin = !Client_Conec.IsDBNull(5) && Client_Conec.GetInt32(5) == 1;
                a.Email = Client_Conec.GetString(6);
                a.Es_Tecn = !Client_Conec.IsDBNull(7) && Client_Conec.GetInt32(7) == 1;

                Cliente.Add(a);
            }
            return Cliente;
        }

        //Valida que el usuario y la contraseña ingresada coincidan con un usuario existente en la base de datos.
        public static bool Validar(string usuarioSeleccionado, string contraseñaIngresada)
        {
            List<Cliente> clientes = GetAll();
            Cliente cliente = clientes.FirstOrDefault(c => c.Usuario == usuarioSeleccionado);
            if (cliente == null)
            {
                return false;
            }

            // Solo compara la contraseña del usuario encontrado
            if (cliente.Contraseña == contraseñaIngresada)
            {
                if (cliente.Es_Admin)
                    Console.WriteLine("Bienvenido Administrador");
                else
                    Console.WriteLine("Bienvenido Usuario");
                return true;
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta.");
                return false;
            }

        }


        public static bool ValidarAdmin(string usuarioSeleccionado, string contraseñaIngresada)
        {
            List<Cliente> clientes = GetAll();
            Cliente cliente = clientes.FirstOrDefault(c => c.Usuario == usuarioSeleccionado);
            if (cliente == null)
            {
                Console.WriteLine("El usuario no existe.");
                return false;
            }

            if (cliente.Contraseña == contraseñaIngresada)
            {
                if (cliente.Es_Admin)
                {
                    Console.WriteLine("Bienvenido Administrador");
                    return true;
                }
                else
                {
                    Console.WriteLine("El usuario no es administrador.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta.");
                return false;
            }
        }

        public static bool ValidarTec(string usuarioSeleccionado, string contraseñaIngresada)
        {
            List<Cliente> clientes = GetAll();
            Cliente cliente = clientes.FirstOrDefault(c => c.Usuario == usuarioSeleccionado);
            if (cliente == null)
            {
                Console.WriteLine("El usuario no existe.");
                return false;
            }

            if (cliente.Contraseña == contraseñaIngresada)
            {
                if (cliente.Es_Admin)
                {
                    Console.WriteLine("Bienvenido Administrador");
                    return true;
                }
                else
                {
                    Console.WriteLine("El usuario no es administrador.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta.");
                return false;
            }
        }

    }
}
