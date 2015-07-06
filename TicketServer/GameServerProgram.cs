using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Classes;
using System.Collections.Generic;


namespace GameServer
{    
    class Principal
    {
        static private ClassesTabuleiro _Tabuleiro = new ClassesTabuleiro();
        private ClassesPecas[] _Peca = new ClassesPecas[12];
        private int _QtdPecasInativas;        

        static public ClassesTabuleiro Tabuleiro
        {
            get { return _Tabuleiro; }
            set { _Tabuleiro = value; }
        }

        static void Main(string[] args)
        {
            Tabuleiro.IniciarTabuleiro();

            GameServer();
        }
       
        static void GameServer()
        {
            //Servidor 1
            Console.WriteLine("Servidor do jogo iniciado...");

            //RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType,"ServidorDoJogoDeDamas", WellKnownObjectMode.SingleCall);

            TcpChannel tcpChannel1 = new TcpChannel(9991);
            ChannelServices.RegisterChannel(tcpChannel1, false);
            Type commonInterfaceType1 = Type.GetType("GameServer.Jogador");           
            RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType1, "ServidorDoJogoDeDamas1", WellKnownObjectMode.Singleton);
            Console.WriteLine("Registrado canal do jogador 1.");

            /*
            TcpChannel tcpChannel2 = new TcpChannel(9992);
            ChannelServices.RegisterChannel(tcpChannel2, false);
            Type commonInterfaceType2 = Type.GetType("GameServer.Jogador");
            RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType2, "ServidorDoJogoDeDamas2", WellKnownObjectMode.Singleton);
            Console.WriteLine("Registrado canal do jogador 2.");
             */

            System.Console.WriteLine("Pressione ENTER para sair.");
            System.Console.ReadLine();

        }

    }

    public interface JogadorInterface
    {
        string GetJogadorStatus(int piNumJogador);
        int GetNumeroJogador(int piNumJogadorRemoto);
        ClassesTabuleiro GetTabuleiro();

        Boolean MoverPeca(int piNumJogador, int piNumPeca, int piX, int piY);
        Boolean StatusConexao();
        Int32 GetUltimoJogadorAMover();
        Int32 GetUltimoPecaAMover();
        Int32 GetXUltimaPeca();
        Int32 GetYUltimaPeca();
        Int32 GetUltimoJogadorPecaMorta();
        Int32 GetUltimaPecaMorta();
    }

    public class Jogador : MarshalByRefObject, JogadorInterface
    {
        public int GetNumeroJogador(int piNumJogadorRemoto)
        {
            if ((Principal.Tabuleiro.GetJogadorConectado(0) == false)) {
                Principal.Tabuleiro.SetNumJogadorRemoto(0, piNumJogadorRemoto);
                Console.WriteLine("Cliente 1 conectou com ID: " + Convert.ToString(piNumJogadorRemoto));
                return 1;
            }
            else if ((Principal.Tabuleiro.GetJogadorConectado(1) == false)) {
                Principal.Tabuleiro.SetNumJogadorRemoto(1, piNumJogadorRemoto);
                Console.WriteLine("Cliente 2 conectou com ID: " + Convert.ToString(piNumJogadorRemoto));
                return 2;
            }
            else
                return 0;
        }

        public string GetJogadorStatus(int piNumJogador)
        {
            if ((Principal.Tabuleiro.getQtdPecasJogador(piNumJogador) > 0))
            {
                Console.WriteLine("Jogador " + Convert.ToString(piNumJogador) + " está ativo.");
                return "ATIVO";
            }
            else
            {
                Console.WriteLine("Jogador " + Convert.ToString(piNumJogador) + " está inativo.");
                return "INATIVO";
            }
        } //GetJogadorStatus

        public ClassesTabuleiro GetTabuleiro()
        {
            //Console.WriteLine("Retornando objeto serializado TABULEIRO");
            return Principal.Tabuleiro;
        } //GetTabuleiro

        public Boolean MoverPeca(int piNumJogador, int piNumPeca, int piX, int piY)
        {
            Console.WriteLine(@"Movimentação de peça do jogador: " + Convert.ToString(piNumJogador + 1) + 
                             @", peça: " + Convert.ToString(piNumPeca + 1) +
                             @", posição X: " + Convert.ToString(piX) + 
                             @", posição Y: " + Convert.ToString(piY));
            return Principal.Tabuleiro.MoverPeca(piNumJogador, piNumPeca, piX, piY);
        }
        public Boolean StatusConexao()
        {
            return true;
        }

        public Int32 GetUltimoJogadorAMover()
        {
            return Principal.Tabuleiro.getUltimoJogadorAMoverPeca();
        }

        public Int32 GetUltimoPecaAMover()
        {
            return Principal.Tabuleiro.GetUltimoPecaAMover();
        }

        public Int32 GetXUltimaPeca()
        {
            return Principal.Tabuleiro.GetXUltimaPeca();
        }

        public Int32 GetYUltimaPeca()
        {
            return Principal.Tabuleiro.GetYUltimaPeca();
        }

        public Int32 GetUltimoJogadorPecaMorta()
        {
            return Principal.Tabuleiro.getUltimoJogadorPecaMorta();
        }
        public Int32 GetUltimaPecaMorta()
        {
            return Principal.Tabuleiro.getUltimaPecaMorta();
        }
    }
}