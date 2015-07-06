using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Classes;

namespace JogoDeDamas
{
    public class ClienteQuadrosTabuleiro
    {
        private int _iNumeroPosicao = 0;
        private Vector2 _posicaoInicio = new Vector2(0, 0);
        private Vector2 _posicaoFim = new Vector2(0, 0);

        //Essas posições é as que vão ser atribuidas à peça
        private int _posicaoXTabuleiro = 0;
        private int _posicaoYTabuleiro = 0;
        //Essas posições é as que vão ser atribuidas à peça

        public int posicaoXTabuleiro
        {
            get { return _posicaoXTabuleiro; }
            set { _posicaoXTabuleiro = value; }
        }

        public int posicaoYTabuleiro
        {
            get { return _posicaoYTabuleiro; }
            set { _posicaoYTabuleiro = value; }
        }

        public int iNumeroPosicao
        {
            get { return _iNumeroPosicao; }
            set { _iNumeroPosicao = value; }
        }

        public Vector2 posicaoInicio
        {
            get { return _posicaoInicio; }
            set { _posicaoInicio = value; }
        }

        public Vector2 posicaoFim
        {
            get { return _posicaoFim; }
            set { _posicaoFim = value; }
        }
    }
}
