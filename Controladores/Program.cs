namespace TP4_LEANDRO.Controladores
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {

            // https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Conexion.OpenConnection();
            Application.Run(new Form1());
        }
    }
}