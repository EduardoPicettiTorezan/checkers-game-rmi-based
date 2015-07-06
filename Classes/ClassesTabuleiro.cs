using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Classes
{
    [Serializable()]
    public class ClassesTabuleiro
    {
        static private ClassesJogador[] _lJogador = new ClassesJogador[2];
        static private Int32 _UltimoJogadorAMoverPeca = 2;
        static private Int32 _UltimaPecaAMover = -1;
        static private Int32 _UltimaPecaMorta = -1;
        static private Int32 _UltimaJogadorPecaMorta = -1;

        public Int32 UltimaPecaAMover
        {
            get { return _UltimaPecaAMover; }
            set { _UltimaPecaAMover = value; }
        }

        public Int32 UltimaPecaMorta
        {
            get { return _UltimaPecaMorta; }
            set { _UltimaPecaMorta = value; }
        }

        public Int32 UltimaJogadorPecaMorta
        {
            get { return _UltimaJogadorPecaMorta; }
            set { _UltimaJogadorPecaMorta = value; }
        }

        public Int32 UltimoJogadorAMoverPeca
        {
            get { return _UltimoJogadorAMoverPeca; }
            set { _UltimoJogadorAMoverPeca = value; }
        }

        public ClassesJogador[] lJogador
        {
            get { return _lJogador; }
            set { _lJogador = value; }
        }        

        public void IniciarTabuleiro () {

            lJogador[0] = new ClassesJogador();
            lJogador[0].IniciarJogador("1");

            lJogador[1] = new ClassesJogador();
            lJogador[1].IniciarJogador("2");
        }

        public int getQtdPecasJogador(int piNumJogador)
        {
            return lJogador[piNumJogador].QtdPecasAtivas;
        }

        public int getUltimaPecaMorta()
        {
            return this.UltimaPecaMorta;
        }

        public int getUltimoJogadorPecaMorta()
        {
            return this.UltimaJogadorPecaMorta;
        }

        public Boolean GetJogadorConectado(int piNumJogador)
        {
            return lJogador[piNumJogador].Conectado;
        }

        public void SetNumJogadorRemoto(int piNumJogador, int piNumJogadorRemoto)
        {
            lJogador[piNumJogador].NumJogadorRemoto = piNumJogadorRemoto;
            lJogador[piNumJogador].Conectado = true;
        }

        public Boolean MoverPeca(int piNumJogador, int piNumPeca, int piX, int piY)
        {

            Boolean bMovValido = true;

            if ((piNumJogador == 0))
            {
                if ((piY >= this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca))
                    bMovValido = false;
            }
            else
            {
                if ((piY <= this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca))
                    bMovValido = false;
            }

            if ((this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca % 2 == 0) &&
                (piY % 2 == 0))
                bMovValido = false;

            if ((this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca % 2 != 0) &&
                (piY % 2 != 0))
                bMovValido = false;

            if ((this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoXDaPeca == piX))
                bMovValido = false;

            if ((this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca == piY))
                bMovValido = false;

            if ((bMovValido))
            {
                if ((piNumJogador == 0))
                {
                    if ((this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca <= 6))
                    {
                        for (int i = 0; i < this.lJogador[1].Peca.Count(); i++)
                        {
                            if ((this.lJogador[0].Peca[i].PecaAtiva))
                            {
                                if ((this.lJogador[1].Peca[i].PosicaoYDaPeca == this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca - 1) &&
                                    (this.lJogador[1].Peca[i].PosicaoXDaPeca == this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoXDaPeca + 1) &&
                                    (this.lJogador[1].Peca[i].PosicaoXDaPeca != piX) &&
                                    (this.lJogador[1].Peca[i].PosicaoYDaPeca != piY))
                                    bMovValido = false;
                                else if
                                    ((this.lJogador[1].Peca[i].PosicaoXDaPeca == piX) &&
                                     (this.lJogador[1].Peca[i].PosicaoYDaPeca == piY))
                                {
                                    this.lJogador[1].Peca[i].PecaAtiva = false;
                                    this.UltimaPecaMorta = i;
                                    this.UltimaJogadorPecaMorta = 1;
                                }

                                if ((this.lJogador[1].Peca[i].PosicaoYDaPeca == this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca - 1) &&
                                    (this.lJogador[1].Peca[i].PosicaoXDaPeca == this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoXDaPeca - 1) &&
                                    (this.lJogador[1].Peca[i].PosicaoXDaPeca != piX) &&
                                    (this.lJogador[1].Peca[i].PosicaoYDaPeca != piY))
                                    bMovValido = false;
                                else if
                                    ((this.lJogador[1].Peca[i].PosicaoXDaPeca == piX) &&
                                     (this.lJogador[1].Peca[i].PosicaoYDaPeca == piY))
                                {
                                    this.lJogador[1].Peca[i].PecaAtiva = false;
                                    this.UltimaPecaMorta = i;
                                    this.UltimaJogadorPecaMorta = 1;
                                }
                            }
                        } //for
                    } //if
                } //if
                else
                {
                    if ((this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca <= 6))
                    {
                        for (int i = 0; i < this.lJogador[0].Peca.Count(); i++)
                        {
                            if ((this.lJogador[0].Peca[i].PecaAtiva))
                            {
                                if ((this.lJogador[0].Peca[i].PosicaoYDaPeca == this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca + 1) &&
                                    (this.lJogador[0].Peca[i].PosicaoXDaPeca == this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoXDaPeca + 1) &&
                                    (this.lJogador[0].Peca[i].PosicaoXDaPeca != piX) &&
                                    (this.lJogador[0].Peca[i].PosicaoYDaPeca != piY))
                                    bMovValido = false;
                                else if
                                    ((this.lJogador[0].Peca[i].PosicaoXDaPeca == piX) &&
                                     (this.lJogador[0].Peca[i].PosicaoYDaPeca == piY))
                                {
                                    this.lJogador[0].Peca[i].PecaAtiva = false;
                                    this.UltimaPecaMorta = i;
                                    this.UltimaJogadorPecaMorta = 0;
                                }

                                if ((this.lJogador[0].Peca[i].PosicaoYDaPeca == this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca + 1) &&
                                    (this.lJogador[0].Peca[i].PosicaoXDaPeca == this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoXDaPeca - 1) &&
                                    (this.lJogador[0].Peca[i].PosicaoXDaPeca != piX) &&
                                    (this.lJogador[0].Peca[i].PosicaoYDaPeca != piY))
                                    bMovValido = false;
                                else if
                                    ((this.lJogador[0].Peca[i].PosicaoXDaPeca == piX) &&
                                     (this.lJogador[0].Peca[i].PosicaoYDaPeca == piY))
                                {
                                    this.lJogador[0].Peca[i].PecaAtiva = false;
                                    this.UltimaPecaMorta = i;
                                    this.UltimaJogadorPecaMorta = 0;
                                }
                            }
                        } //for
                    } //if
                } //else
            }

            if ((bMovValido))
            {
                this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoXDaPeca = piX;
                this.lJogador[piNumJogador].Peca[piNumPeca].PosicaoYDaPeca = piY;

                this.UltimoJogadorAMoverPeca = piNumJogador + 1;
                this.UltimaPecaAMover = piNumPeca;
                return true;
            }
            else            
                return false;            

        }

        public Int32 getUltimoJogadorAMoverPeca()
        {
            return this.UltimoJogadorAMoverPeca;
        }

        public Int32 GetUltimoPecaAMover()
        {
            return this.UltimaPecaAMover;
        }

        public Int32 GetXUltimaPeca()
        {
            return this.lJogador[this.UltimoJogadorAMoverPeca - 1].Peca[this.UltimaPecaAMover].PosicaoXDaPeca;
        }

        public Int32 GetYUltimaPeca()
        {
            return this.lJogador[this.UltimoJogadorAMoverPeca - 1].Peca[this.UltimaPecaAMover].PosicaoYDaPeca;
        }

        [OnDeserializing()]
        public void OnDeserializing(StreamingContext cont)
        {
            //Console.WriteLine("Descompactando dados para processamento.");
        }

        [OnDeserialized()]
        public void OnDeserialized(StreamingContext cont)
        {
            // Console.WriteLine("Dados descompactados.");
        }

        [OnSerializing()]
        public void OnSerializing(StreamingContext cont)
        {
            // Console.WriteLine("Compactando dados para envio.");
        }

        [OnSerialized()]
        public void OnSerialized(StreamingContext cont)
        {
            // Console.WriteLine("Dados compactados.");
        }        
    }
}
