using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class ClassesJogador
    {
        private int _NumeroJogador;
        private int _QtdPecasAtivas;
        private Boolean _Conectado;
        private int _NumJogadorRemoto;
        private ClassesPecas[] _Peca = new ClassesPecas[12];

        public void IniciarJogador(String psNumeroJogador)
        {
            Int32 iNumeroJogador = Convert.ToInt32(psNumeroJogador);

            Conectado = false;
            NumJogadorRemoto = 0;

            NumeroJogador = iNumeroJogador;
            QtdPecasAtivas = Peca.Count();

            for (int i = 0; i < _Peca.Count(); i++)
            {

                Peca[i] = new ClassesPecas();

                Peca[i].PecaAtiva = true;
                if (NumeroJogador == 1)
                    Peca[i].CorDaPeca = 0;
                else
                    Peca[i].CorDaPeca = 1;

                Peca[i].NumeroDaPeca = i;

                if ((iNumeroJogador == 2))
                {
                    if ((i == 0))
                    {
                        Peca[i].PosicaoXDaPeca = 1;
                        Peca[i].PosicaoYDaPeca = 1;
                    }
                    else if ((i == 1))
                    {
                        Peca[i].PosicaoXDaPeca = 3;
                        Peca[i].PosicaoYDaPeca = 1;
                    }
                    else if ((i == 2))
                    {
                        Peca[i].PosicaoXDaPeca = 5;
                        Peca[i].PosicaoYDaPeca = 1;
                    }
                    else if ((i == 3))
                    {
                        Peca[i].PosicaoXDaPeca = 7;
                        Peca[i].PosicaoYDaPeca = 1;
                    }
                    else if ((i == 4))
                    {
                        Peca[i].PosicaoXDaPeca = 2;
                        Peca[i].PosicaoYDaPeca = 2;
                    }
                    else if ((i == 5))
                    {
                        Peca[i].PosicaoXDaPeca = 4;
                        Peca[i].PosicaoYDaPeca = 2;
                    }
                    else if ((i == 6))
                    {
                        Peca[i].PosicaoXDaPeca = 6;
                        Peca[i].PosicaoYDaPeca = 2;
                    }
                    else if ((i == 7))
                    {
                        Peca[i].PosicaoXDaPeca = 8;
                        Peca[i].PosicaoYDaPeca = 2;
                    }
                    else if ((i == 8))
                    {
                        Peca[i].PosicaoXDaPeca = 1;
                        Peca[i].PosicaoYDaPeca = 3;
                    }
                    else if ((i == 9))
                    {
                        Peca[i].PosicaoXDaPeca = 3;
                        Peca[i].PosicaoYDaPeca = 3;
                    }
                    else if ((i == 10))
                    {
                        Peca[i].PosicaoXDaPeca = 5;
                        Peca[i].PosicaoYDaPeca = 3;
                    }
                    else if ((i == 11))
                    {
                        Peca[i].PosicaoXDaPeca = 7;
                        Peca[i].PosicaoYDaPeca = 3;
                    }                    
                }
                else if ((iNumeroJogador == 1))
                {
                    if ((i == 0))
                    {
                        Peca[i].PosicaoXDaPeca = 2;
                        Peca[i].PosicaoYDaPeca = 8;
                    }
                    else if ((i == 1))
                    {
                        Peca[i].PosicaoXDaPeca = 4;
                        Peca[i].PosicaoYDaPeca = 8;
                    }
                    else if ((i == 2))
                    {
                        Peca[i].PosicaoXDaPeca = 6;
                        Peca[i].PosicaoYDaPeca = 8;
                    }
                    else if ((i == 3))
                    {
                        Peca[i].PosicaoXDaPeca = 8;
                        Peca[i].PosicaoYDaPeca = 8;
                    }
                    else if ((i == 4))
                    {
                        Peca[i].PosicaoXDaPeca = 1;
                        Peca[i].PosicaoYDaPeca = 7;
                    }
                    else if ((i == 5))
                    {
                        Peca[i].PosicaoXDaPeca = 3;
                        Peca[i].PosicaoYDaPeca = 7;
                    }
                    else if ((i == 6))
                    {
                        Peca[i].PosicaoXDaPeca = 5;
                        Peca[i].PosicaoYDaPeca = 7;
                    }
                    else if ((i == 7))
                    {
                        Peca[i].PosicaoXDaPeca = 7;
                        Peca[i].PosicaoYDaPeca = 7;
                    }
                    else if ((i == 8))
                    {
                        Peca[i].PosicaoXDaPeca = 2;
                        Peca[i].PosicaoYDaPeca = 6;
                    }
                    else if ((i == 9))
                    {
                        Peca[i].PosicaoXDaPeca = 4;
                        Peca[i].PosicaoYDaPeca = 6;
                    }
                    else if ((i == 10))
                    {
                        Peca[i].PosicaoXDaPeca = 6;
                        Peca[i].PosicaoYDaPeca = 6;
                    }
                    else if ((i == 11))
                    {
                        Peca[i].PosicaoXDaPeca = 8;
                        Peca[i].PosicaoYDaPeca = 6;
                    }
                }
            }
        } //IniciarJogador
        public void AutorizaMovimento(int piNumJogador, int piX, int piY)
        {
            if (piNumJogador == 1)
            {
                if ((piX != 1 && piY != 1) ||
                    (piX != 3 && piY != 1) ||
                    (piX != 5 && piY != 1) ||
                    (piX != 7 && piY != 1) ||
                    (piX != 2 && piY != 2) ||
                    (piX != 4 && piY != 2) ||
                    (piX != 6 && piY != 2) ||
                    (piX != 8 && piY != 2) ||
                    (piX != 1 && piY != 3) ||
                    (piX != 3 && piY != 3) ||
                    (piX != 5 && piY != 3) ||
                    (piX != 7 && piY != 3))
                {
                   // Console.WriteLine("Posições Incorretas");
                }
            }
            if (piNumJogador == 2)
            {
                if ((piX != 1 && piY != 8) ||
                    (piX != 3 && piY != 8) ||
                    (piX != 5 && piY != 8) ||
                    (piX != 7 && piY != 8) ||
                    (piX != 2 && piY != 7) ||
                    (piX != 4 && piY != 7) ||
                    (piX != 6 && piY != 7) ||
                    (piX != 8 && piY != 7) ||
                    (piX != 1 && piY != 6) ||
                    (piX != 3 && piY != 6) ||
                    (piX != 5 && piY != 6) ||
                    (piX != 7 && piY != 6))
                {
                   // Console.WriteLine("Posições Incorretas");
                }
            }

        }
        public int NumeroJogador
        {
            get { return _NumeroJogador; }
            set { _NumeroJogador = value; }
        }

        public int QtdPecasAtivas
        {
            get { return _QtdPecasAtivas; }
            set { _QtdPecasAtivas = value; }
        }

        public ClassesPecas[] Peca
        {
            get { return _Peca; }
            set { _Peca = value; }
        }

        public Boolean Conectado
        {
            get { return _Conectado; }
            set { _Conectado = value; }
        }

        public int NumJogadorRemoto
        {
            get { return _NumJogadorRemoto; }
            set { _NumJogadorRemoto = value; }
        }
    }
}
