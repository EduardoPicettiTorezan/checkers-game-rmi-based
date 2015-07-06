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
    public class ClienteTabuleiroLocal
    {
        private Texture2D _modelo;
        private Vector2 _posicaoatual = new Vector2(0, 0);
        private Vector2 _posicaooriginal = new Vector2(0, 0);
        private ClienteQuadrosTabuleiro[] _quadros = new ClienteQuadrosTabuleiro[64];

        public ClienteQuadrosTabuleiro[] quadros
        {
            get { return _quadros; }
            set { _quadros = value; }
        }

        public Texture2D modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }
        public Vector2 posicaoatual
        {
            get { return _posicaoatual; }
            set { _posicaoatual = value; }
        }
        public Vector2 posicaooriginal
        {
            get { return _posicaooriginal; }
            set { _posicaooriginal = value; }
        }

        public void Iniciar()
        {
            Vector2 posicaolocal = new Vector2(0, 0);

            int iConta = 0;
            for (int larg = 1; larg <= 8; larg++)
            {
                for (int alt = 1; alt <= 8; alt++)
                {
                    quadros[iConta] = new ClienteQuadrosTabuleiro();

                    posicaolocal.X = ((Principal.LARGURA_TELA / 8) * larg);
                    posicaolocal.Y = ((Principal.ALTURA_TELA / 8) * alt);

                    posicaolocal.X = posicaolocal.X + Principal.DIFX;
                    posicaolocal.Y = posicaolocal.Y + Principal.DIFY;
                    quadros[iConta].posicaoFim = posicaolocal;

                    if ((alt > 1))
                        posicaolocal.Y = quadros[iConta - 1].posicaoFim.Y;
                    else
                        posicaolocal.Y = 0;

                    if ((larg > 1))
                        posicaolocal.X = quadros[iConta - 1].posicaoFim.X;
                    else
                        posicaolocal.X = 0;

                    posicaolocal.X = posicaolocal.X + Principal.DIFX;
                    posicaolocal.Y = posicaolocal.Y + Principal.DIFY;
                    quadros[iConta].posicaoInicio = posicaolocal;                                        

                    //Essas posições é as que vão ser atribuidas à peça
                    quadros[iConta].posicaoXTabuleiro = alt;
                    quadros[iConta].posicaoYTabuleiro = larg;
                    //Essas posições é as que vão ser atribuidas à peça

                    iConta++;
                }
            }
        }

        public void CarregarModelo(ContentManager pContent)
        {
            this.modelo = pContent.Load<Texture2D>("damas_tabuleiro");
        }

        public void DesenharTabuleiro(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(
                this.modelo,
                this.posicaoatual,
                null,
                Color.White,
                0, //Rotação
                this.posicaooriginal,
                1.0f,
                SpriteEffects.None,
                0f);
        }
    }
}
