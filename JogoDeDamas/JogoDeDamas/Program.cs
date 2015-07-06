using System;
using System.Windows.Forms;

namespace JogoDeDamas
{
#if WINDOWS || XBOX
    static class Program
    {
        public static string sProgramIpDoServidor = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MenuInicial serve = new MenuInicial())
            {
                if (serve.ShowDialog() == DialogResult.OK)
                {
                    sProgramIpDoServidor = MenuInicial.sIpdoServidor;
                    using (Principal game = new Principal())
                    {
                        game.Run();
                    }
                }
            }
        }
    }
#endif
}
