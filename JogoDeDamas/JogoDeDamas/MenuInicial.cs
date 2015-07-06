using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JogoDeDamas
{
    public partial class MenuInicial : Form
    {
        public MenuInicial()
        {
            InitializeComponent();
        }

        public static string sIpdoServidor { get; set; }
        public static Int32 iNumJogadorSel { get; set; }

        private void txtIp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Confirma",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if ((txtIp.Text == ""))
            {
                MessageBox.Show("Servidor não executado!");
            }
            else
            {
                sIpdoServidor = txtIp.Text;
                iNumJogadorSel = -1;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnIniciarServidor_Click(object sender, EventArgs e)
        {
            string sCaminhoServidor = "";
            sCaminhoServidor = (@"C:\Users\txg\Documents\visual studio 2010\Projects\Trabalho_RMI\TicketServer\bin\Debug\TicketServer.exe");
            //sCaminhoServidor = (@"" + Application.StartupPath + "\\" + "TicketServer.exe");

            if (File.Exists(sCaminhoServidor))
            {
                System.Diagnostics.Process.Start(sCaminhoServidor);
            }
            else
            {
                MessageBox.Show("Servidor não localizado no diretório: " + Application.StartupPath);
            }
        }
    }
}
