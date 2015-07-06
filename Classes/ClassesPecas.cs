using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class ClassesPecas
    {
        private int _NumeroDaPeca;
        private int _PosicaoXDaPeca;
        private int _PosicaoYDaPeca;
        private int _CorDaPeca;
        private bool _PecaAtiva;


        public int NumeroDaPeca
        {
            get { return _NumeroDaPeca; }
            set { _NumeroDaPeca = value; }
        }

        public int PosicaoXDaPeca
        {
            get { return _PosicaoXDaPeca; }
            set { _PosicaoXDaPeca = value; }
        }

        public int PosicaoYDaPeca
        {
            get { return _PosicaoYDaPeca; }
            set { _PosicaoYDaPeca = value; }
        }

        public int CorDaPeca
        {
            get { return _CorDaPeca; }
            set { _CorDaPeca = value; }
        }

        public bool PecaAtiva
        {
            get { return _PecaAtiva; }
            set { _PecaAtiva = value; }
        }
    }
}
