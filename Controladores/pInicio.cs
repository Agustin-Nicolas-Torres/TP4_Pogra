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
                string esAdminStr = Client_Conec.GetString(5);
                a.Es_Admin = esAdminStr == "1";
                a.Email = Client_Conec.GetString(6);

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
                Console.WriteLine("El usuario no existe.");
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


        public static bool ValidarAdmin_Tecn(string usuarioSeleccionado, string contraseñaIngresada)
        {
            List<Cliente> clientes = GetAll();
            Cliente cliente = clientes.FirstOrDefault(c => c.Usuario == usuarioSeleccionado);
            if (cliente == null && cliente.Es_Admin)
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

        public static Cliente? BuscarClientePorEmailONombre(string email, string nombreCompleto)
        {
            List<Cliente> clientes = GetAll();
            return clientes.FirstOrDefault(c =>
                (!string.IsNullOrEmpty(email) && c.Email == email) ||
                (!string.IsNullOrEmpty(nombreCompleto) && $"{c.Nombre} {c.Apellido}" == nombreCompleto)
            );
        }

        public static void InsertarCliente(Cliente cliente)
        {
            using (var cmd = new SQLiteCommand("INSERT INTO Usuario (Nombre, Apellido, N_User, Contraseña, Es_Admin, Email, DNI, Calle, NumeroCalle, Provincia, Telefono) VALUES (@Nombre, @Apellido, @N_User, @Contraseña, @Es_Admin, @Email, @DNI, @Calle, @NumeroCalle, @Provincia, @Telefono)", Conexion.Connection))
            {
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@N_User", cliente.Usuario);
                cmd.Parameters.AddWithValue("@Contraseña", cliente.Contraseña);
                cmd.Parameters.AddWithValue("@Es_Admin", cliente.Es_Admin ? 1 : 0);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@DNI", cliente.DNI);
                cmd.Parameters.AddWithValue("@Calle", cliente.Calle);
                cmd.Parameters.AddWithValue("@NumeroCalle", cliente.NumeroCalle);
                cmd.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
