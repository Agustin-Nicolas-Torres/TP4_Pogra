using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4_LEANDRO.Modelos;

namespace TP4_LEANDRO.Controladores
{
    internal class pAusitoria
    {
        public static List<Auditoria> GetAllAuditoria()
        {
            List<Auditoria> Audit = new List<Auditoria>();
            // Asegura que la conexión esté abierta
            SQLiteCommand cmd = new SQLiteCommand("SELECT ID, Fecha, Usuario, Accion FROM Auditoria");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader Audit_Conec = cmd.ExecuteReader();

            while (Audit_Conec.Read())
            {
                // Crea una nueva instancia de Auditoria y asigna los valores leídos
                Auditoria a = new Auditoria();
                a.ID = Audit_Conec.GetInt32(0);
                a.Fecha = Audit_Conec.GetString(1);
                a.Usuario = Audit_Conec.GetString(2);
                a.Accion= Audit_Conec.GetString(3);

                Audit.Add(a);
            }
            return Audit;
        }

        public static void Registrar_Auditoria(
    string fecha,
    string usuario,
    string accion)
        {
            // Verifica si ya existe un registro igual
            using (var cmdCheck = new SQLiteCommand("SELECT COUNT(*) FROM Auditoria WHERE Fecha = @fecha AND Usuario = @usuario AND Accion = @accion", Conexion.Connection))
            {
                cmdCheck.Parameters.AddWithValue("@fecha", fecha);
                cmdCheck.Parameters.AddWithValue("@usuario", usuario);
                cmdCheck.Parameters.AddWithValue("@accion", accion);
                long count = (long)cmdCheck.ExecuteScalar();
                if (count > 0)
                {
                    return;
                }
            }

            // Calcula el nuevo ID 
            int nuevoId = 1;
            using (var cmdId = new SQLiteCommand("SELECT IFNULL(MAX(Id), 0) + 1 FROM Auditoria", Conexion.Connection))
            {
                object result = cmdId.ExecuteScalar();
                nuevoId = Convert.ToInt32(result);
            }

            // Inserta el registro
            string query = @"INSERT INTO Auditoria (Id, Fecha, Usuario, Accion)
                     VALUES (@id, @fecha, @usuario, @accion)";

            using (var cmd = new SQLiteCommand(query, Conexion.Connection))
            {
                cmd.Parameters.AddWithValue("@id", nuevoId);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@accion", accion);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
