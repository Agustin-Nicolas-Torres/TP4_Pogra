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
                a.Es_Admin = esAdminValue is int i ? i == 1 :
                             esAdminValue is long l ? l == 1 :
                             esAdminValue is string s ? s == "1" || s.ToLower() == "true" :
                             false;
                a.Email = Client_Conec.GetString(6);

                // Asignar Es_Tecnico correctamente
                object esTecValue = Client_Conec.GetValue(7);
                a.Es_Tecn = esTecValue is int n ? n == 1 :
                               esTecValue is long m ? m == 1 :
                               esTecValue is string b ? b == "1" || b.ToLower() == "true" :
                               false;

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
            // Solo compara la contraseña del usuario encontrado
            if (cliente.Contraseña == contraseñaIngresada && cliente.Es_Admin)
            {
                Console.WriteLine("Bienvenido Administrador");
                return true;
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta o no es un administrador.");
                return false;
            }
        }

        public static bool Validar_Tecn(string usuarioSeleccionado, string contraseñaIngresada)
        {
            List<Cliente> clientes = GetAll();
            Cliente cliente = clientes.FirstOrDefault(c => c.Usuario == usuarioSeleccionado);
            if (cliente == null)
            {
                return false;
            }
            // Solo compara la contraseña del usuario encontrado y si es técnico
            if (cliente.Contraseña == contraseñaIngresada && cliente.Es_Tecn)
            {
                Console.WriteLine("Bienvenido Técnico");
                return true;
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta o no es técnico.");
                return false;
            }
        }

    }
}
