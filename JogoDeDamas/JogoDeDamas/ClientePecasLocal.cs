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
    public class ClientePecasLocal
    {
        private Texture2D _modelo;
        private Vector2 _posicaoatual = new Vector2(0, 0);
        private Vector2 _posicaooriginal = new Vector2(0, 0);
        Rectangle _espacoPeca;
        private Boolean _Ativa = true;

        public Rectangle EspacoPeca
        {
            get { return _espacoPeca; }
            set { _espacoPeca = value; }
        }

        public Boolean Ativa
        {
            get { return _Ativa; }
            set { _Ativa = value; }
        }

        public Texture2D modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }
        public Vector2 PosicaoAtual
        {
            get { return _posicaoatual; }
            set { _posicaoatual = value; }
        }
        public Vector2 PosicaoOriginal
        {
            get { return _posicaooriginal; }
            set { _posicaooriginal = value; }
        }

        public void Iniciar(ClassesTabuleiro pTabuleiro, int pIdDoJogador,int pIdDaPeca)
        {
            if ((pTabuleiro.lJogador[pIdDoJogador] != null))
            {
                Vector2 pos = new Vector2(0, 0); ;
                try
                {
                    int xRealU, yRealU, xReal, yReal;

                    xRealU = ((Principal.LARGURA_TELA) / 8);
                    yRealU = ((Principal.ALTURA_TELA) / 8);

                    xReal = (xRealU * (pTabuleiro.lJogador[pIdDoJogador].Peca[pIdDaPeca].PosicaoXDaPeca - 1));
                    yReal = (yRealU * (pTabuleiro.lJogador[pIdDoJogador].Peca[pIdDaPeca].PosicaoYDaPeca - 1));

                    pos.X = Principal.DIFX + xReal;
                    pos.Y = Principal.DIFY + yReal;
                }
                finally
                {
                    PosicaoAtual = pos;
                    //PosicaoOriginal = PosicaoAtual;
                }
            }
        }

        public void CarregarModelo(ClienteJogador pJogador, int piNumJogador, ContentManager pContent)
        {
            int xLarg = 0, yLarg = 0;

            if ((piNumJogador == 1))
               this.modelo = pContent.Load<Texture2D>("peca_preta");
            else
               this.modelo = pContent.Load<Texture2D>("peca_branca");

            pJogador.ArialFont2 = pContent.Load<SpriteFont>("SpriteFont2");

            xLarg = (Principal.LARGURA_TELA / 8);
            yLarg = (Principal.ALTURA_TELA / 8);
            
            this.EspacoPeca = new Rectangle
                                    (Convert.ToInt32(this.PosicaoAtual.X),
                                     Convert.ToInt32(this.PosicaoAtual.Y),
                                     Convert.ToInt32(xLarg),
                                     Convert.ToInt32(yLarg));
        }

        public void DesenharPecas(ClienteJogador pJogador, SpriteBatch pSpriteBatch)
        {
            string sMsg = "";

            if ((this.Ativa))
            {
                pSpriteBatch.Draw(
                    this.modelo,
                    this.PosicaoAtual,
                    null,
                    Color.White,
                    0, //Rotação
                    this.PosicaoOriginal,
                    1.0f,
                    SpriteEffects.None,
                    0f);
            }

            if ((pJogador.EstadoJogador == ""))
                pJogador.ContaTempoMensagem = 2000;            
            else
            {
                pJogador.ContaTempoMensagem = pJogador.ContaTempoMensagem - 1;
                if ((pJogador.ContaTempoMensagem <= 0))
                {
                    if ((pJogador.EstadoJogador == "SELECIONOU_PECA"))
                    {
                        pJogador.ContaTempoMensagem = 2000;
                        pJogador.EstadoJogador = "SELECIONE_QUADRO";
                    }
                    else if ((pJogador.EstadoJogador == "SELECIONOU_QUADRO"))
                    {
                        pJogador.ContaTempoMensagem = 2000;
                        pJogador.EstadoJogador = "MOVENDO_PECA";
                    }
                    else if ((pJogador.EstadoJogador == "AGUARDANDO_OUTRO_JOGADOR"))
                        pJogador.ContaTempoMensagem = 2000;
                    else
                        pJogador.EstadoJogador = "";
                }
            } //else

            if ((pJogador.EstadoJogador == "AGUARDANDO_SELECAO"))
                sMsg = "Selecione a peca para mover.";
            else if ((pJogador.EstadoJogador == "AGUARDANDO_MOVIMENTO"))
                sMsg = "Selecione local para mover a peca.";
            else if ((pJogador.EstadoJogador == "AGUARDANDO_SELECAO"))
                sMsg = "Selecione a peca para mover.";
            else if ((pJogador.EstadoJogador == "MOVIMENTACAO_INVALIDA"))
                sMsg = "Movimentacao nao permitida. Selecione outra peca.";
            else if ((pJogador.EstadoJogador == "AGUARDANDO_OUTRO_JOGADOR"))
                sMsg = "Aguardando outro jogador.";
            else if ((pJogador.EstadoJogador == "GANHOU"))
                sMsg = "Voce ganhou.";
            else if ((pJogador.EstadoJogador == "PERDEU"))
                sMsg = "Voce perdeu.";
            else if ((pJogador.EstadoJogador == "SEM_CONEXAO"))
                sMsg = "Nao conectado ao servidor.";
            else if ((pJogador.EstadoJogador == "SELECIONE_QUADRO"))
                sMsg = "Selecione o local para mover a peca.";
            else if ((pJogador.EstadoJogador == "SELECIONOU_PECA"))           
                sMsg = "Selecionou peca: " + Convert.ToString(pJogador.PecaSelecionada + 1);
            else if ((pJogador.EstadoJogador == "SELECIONOU_QUADRO"))
                sMsg = "Selecionou quadro: " + Convert.ToString(pJogador.QuadroSelecionado);
            else if ((pJogador.EstadoJogador == "MOVENDO_PECA"))
                sMsg = "Movendo a peca.";
            else
            {
                if ((pJogador.EstadoJogador != ""))
                {
                    sMsg = pJogador.EstadoJogador;
                    pJogador.EstadoJogador = "";
                }
                else
                {
                    sMsg = "";
                }
            }

           if ((sMsg != "")) {
              pSpriteBatch.DrawString(
                   pJogador.ArialFont2,
                   sMsg,
                   pJogador.PosicaoTextoMsg,
                   Color.BlueViolet);
           } //if ((sMsg != "")) {
        }
    }
}
