using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4_LEANDRO.Modelos;

namespace TP4_LEANDRO.Controladores
{
    internal class pRegistro
    {
        public static void Registrar_User(
    string usuario,
    string nombre,
    string apellido,
    string dni,
    string calle,
    string numeroCalle,
    string provincia,
    string email,
    string telefono,
    string contraseñaIngresada)
        {

            // Verifica si el usuario ya existe en la base de datos
            List<Cliente> clientes = pInicio.GetAll();
            // Si el usuario ya existe, no se realiza la inserción
            Cliente cliente = clientes.FirstOrDefault(c => c.Usuario == usuario);

            if (cliente != null)
            {
                return;
            }

            using (var cmdCheck = new SQLiteCommand("SELECT COUNT(*) FROM Usuario WHERE Telefono = @telefono", Conexion.Connection))
            {
                cmdCheck.Parameters.AddWithValue("@telefono", Convert.ToInt64(telefono));
                long count = (long)cmdCheck.ExecuteScalar();
                if (count > 0)
                {
                    // El teléfono ya existe, no se realiza la inserción
                    return;
                }
            }

            // Verifica si el ID ya existe
            int nuevoId = 1;
            using (var cmdId = new SQLiteCommand("SELECT IFNULL(MAX(ID), 0) + 1 FROM Usuario", Conexion.Connection))
            {
                object result = cmdId.ExecuteScalar();
                nuevoId = Convert.ToInt32(result);
            }

            using (var cmdCheckId = new SQLiteCommand("SELECT COUNT(*) FROM Usuario WHERE ID = @id", Conexion.Connection))
            {
                cmdCheckId.Parameters.AddWithValue("@id", nuevoId);
                long countId = (long)cmdCheckId.ExecuteScalar();
                if (countId > 0)
                {
                    // El ID ya existe, no se realiza la inserción
                    return;
                }
            }

            string query = @"INSERT INTO Usuario (ID, Nombre, Apellido, N_User, Contraseña, Es_Admin, Email, Es_Tecn, DNI, Calle, NumeroCalle, Provincia, Telefono)
            VALUES
            (@id, @nombre, @apellido, @usuario, @contraseña, 0, @email, 0, @dni, @calle, @numeroCalle, @provincia, @telefono)";


            using (SQLiteCommand cmd = new SQLiteCommand(query, Conexion.Connection))
            {
                cmd.Parameters.AddWithValue("@id", nuevoId);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseñaIngresada);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@dni", Convert.ToInt32(dni));
                cmd.Parameters.AddWithValue("@calle", calle);
                cmd.Parameters.AddWithValue("@numeroCalle", Convert.ToInt32(numeroCalle));
                cmd.Parameters.AddWithValue("@provincia", provincia);
                cmd.Parameters.AddWithValue("@telefono", Convert.ToInt64(telefono));
                cmd.ExecuteNonQuery();
            }
        }
    }
}