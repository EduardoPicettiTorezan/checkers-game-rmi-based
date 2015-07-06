using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using GameServer;
using Classes;

namespace JogoDeDamas
{
    public class ClienteClientNetWork
    {
        private JogadorInterface _remoteObject;
        public JogadorInterface remoteObject
        {
            get { return _remoteObject; }
            set { _remoteObject = value; }
        }

        public void Iniciar(string pipDoServidor, Int32 piNumJogadorSel)
        {
            TcpChannel tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel, false);

            Type requiredType = typeof(JogadorInterface);
            remoteObject = (JogadorInterface)Activator.GetObject(requiredType,
              @"tcp://" + pipDoServidor + @":9991/ServidorDoJogoDeDamas1");
            /*
            if ((piNumJogadorSel == 1))
            {
                remoteObject = (JogadorInterface)Activator.GetObject(requiredType,
                @"tcp://" + pipDoServidor + @":9991/ServidorDoJogoDeDamas1");
            }
            else
            {
                remoteObject = (JogadorInterface)Activator.GetObject(requiredType,
                @"tcp://" + pipDoServidor + @":9992/ServidorDoJogoDeDamas2");
            }
            */
            //Console.WriteLine(remoteObject.GetJogadorStatus(1));
        }

        public int GetNumeroJogador(int piNumJogadorRemoto)
        {
            try
            {
                if ((remoteObject != null))
                    return remoteObject.GetNumeroJogador(piNumJogadorRemoto);
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }

        public ClassesTabuleiro GetTabuleiro()
        {
            try
            {
                if ((remoteObject != null))
                    return remoteObject.GetTabuleiro();
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public Boolean StatusConexao()
        {
            try
            {
                if ((remoteObject != null))
                    return remoteObject.StatusConexao();
                else
                    return false;
            }
            catch {
                return false;
            }
        }

        public Boolean MoverPeca(int piNumJogador, int piNumPeca, int piX, int piY)
        {
            try
            {
                if ((remoteObject != null))
                    return remoteObject.MoverPeca(piNumJogador, piNumPeca, piX, piY);
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public Int32 GetUltimoJogadorAMover()
        {
            try
            {
                if ((remoteObject != null))
                    return remoteObject.GetUltimoJogadorAMover();
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
        }

        public Int32 GetUltimaPecaAMover()
        {
            try
            {
                if ((remoteObject != null))
                    return remoteObject.GetUltimoPecaAMover();
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
        }

        public Int32 GetXUltimaPeca()
        {
            try
            {
                if ((remoteObject != null))
                    return remoteObject.GetXUltimaPeca();
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
        }
        public Int32 GetYUltimaPeca()
        {
            try
            {
                if ((remoteObject != null))
                    return remoteObject.GetYUltimaPeca();
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
        }

        public Int32 GetUltimoJogadorPecaMorta()
        {
            try
            {
                if ((remoteObject != null))
                    return remoteObject.GetUltimoJogadorPecaMorta();
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
        }

        public Int32 GetUltimaPecaMorta()
        {
            try
            {
                if ((remoteObject != null))
                    return remoteObject.GetUltimaPecaMorta();
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
        }

    }

}
