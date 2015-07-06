using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Classes;
using System.Windows.Forms;
using System.Threading;

namespace JogoDeDamas
{
    public class ClienteJogador
    {
        private Boolean _Conectado;
        private Boolean _Iniciado;
        private ClienteClientNetWork _clientNetwork;
        private ClassesTabuleiro _TabuleiroLocal;
        private ClienteTabuleiroLocal _clienteTabuleiroLocal = new ClienteTabuleiroLocal();
        private ClientePecasLocal[] _clientePecasLocal1 = new ClientePecasLocal[12];
        private ClientePecasLocal[] _clientePecasLocal2 = new ClientePecasLocal[12];
        private int _NumJogadorCliente = 1;
        private string _estadoJogador = "";
        private Vector2 _posicaoTextoMsg = new Vector2(0, 0);
        private SpriteFont _arialFont2;
        private Int32 _contaTempoMensagem = 2000;
        private Int32 _pecaSelecionada = -1;
        private Int32 _quadroSelecionado = -1;
        
        public void Iniciar(ref ClienteJogador pJogador, string pipDoServidor, Int32 NumJogadorSel)
        {
            ClassesTabuleiro lTab = new ClassesTabuleiro();

            string sStatus = "";
            Vector2 lTextoMsg = new Vector2(0, 0);

            clientNetwork = new ClienteClientNetWork();
            clientNetwork.Iniciar(pipDoServidor, NumJogadorSel);

            if ((clientNetwork.StatusConexao() == false))
            {
                this.Conectado = false;
                this.EstadoJogador = "SEM_CONEXAO";
                //MessageBox.Show("Não foi possível conectar ao servidor.");                
            }
            else
            {
                this.Conectado = true;
                this.EstadoJogador = "";
            }
            sStatus = this.EstadoJogador;

            Random rnd = new Random(DateTime.Now.Millisecond);
            rnd.Next();
            int iNumJogadorRemoto = rnd.Next(1, 999);
            int iNumJogadorTabuleiro = 0;

            if ((this.Conectado))
            {
                iNumJogadorTabuleiro = clientNetwork.GetNumeroJogador(iNumJogadorRemoto);

                if ((iNumJogadorTabuleiro > 0))
                {
                    lTab = clientNetwork.GetTabuleiro();                    
                }
                this.NumJogadorCliente = iNumJogadorTabuleiro;
            }

            if ((lTab != null))
            {
                TabuleiroLocal = lTab;
            }
            
            {
                TabuleiroLocal.lJogador[0] = new ClassesJogador();
                TabuleiroLocal.lJogador[0].IniciarJogador("1");

                TabuleiroLocal.lJogador[1] = new ClassesJogador();
                TabuleiroLocal.lJogador[1].IniciarJogador("2");
            }

            if ((ClienteTabuleiroLocal != null))
            {
                ClienteTabuleiroLocal = new ClienteTabuleiroLocal();
                ClienteTabuleiroLocal.Iniciar();
            }

            for (int tj = 0; tj < TabuleiroLocal.lJogador.Count(); tj++)
            {
                if ((tj == 0))
                {
                    for (int i = 0; i < pJogador.ClientePecasLocal1.Count(); i++)
                    {
                        pJogador.ClientePecasLocal1[i] = new ClientePecasLocal();
                        if ((pJogador.ClientePecasLocal1[i] != null))
                            pJogador.ClientePecasLocal1[i].Iniciar(TabuleiroLocal, tj, i);
                    }
                }
                else
                {
                    for (int i = 0; i < pJogador.ClientePecasLocal2.Count(); i++)
                    {
                        pJogador.ClientePecasLocal2[i] = new ClientePecasLocal();
                        if ((pJogador.ClientePecasLocal2[i] != null))
                            pJogador.ClientePecasLocal2[i].Iniciar(TabuleiroLocal, tj, i);
                    }
                }
            }

            lTextoMsg.X = (10);
            lTextoMsg.Y = (Principal.ALTURA_TELA - 80);
            this.PosicaoTextoMsg = lTextoMsg;
            
            this.Iniciado = true;
            this.EstadoJogador = sStatus;

        } //Iniciar

        public Int32 PecaSelecionada
        {
            get { return _pecaSelecionada; }
            set { _pecaSelecionada = value; }
        }

        public Int32 QuadroSelecionado
        {
            get { return _quadroSelecionado; }
            set { _quadroSelecionado = value; }
        }
        
        
        public Int32 ContaTempoMensagem
        {
            get { return _contaTempoMensagem; }
            set { _contaTempoMensagem = value; }
        }
        public SpriteFont ArialFont2
        {
            get { return _arialFont2; }
            set { _arialFont2 = value; }
        }
        public Vector2 PosicaoTextoMsg
        {
            get { return _posicaoTextoMsg; }
            set { _posicaoTextoMsg = value; }
        }

        public String EstadoJogador
        {
            get { return _estadoJogador; }
            set { _estadoJogador = value; }
        }

        public ClienteClientNetWork clientNetwork
        {
            get { return _clientNetwork; }
            set { _clientNetwork = value; }
        }

        public int NumJogadorCliente
        {
            get { return _NumJogadorCliente; }
            set { _NumJogadorCliente = value; }
        }

        public ClassesTabuleiro TabuleiroLocal
        {
            get { return _TabuleiroLocal; }
            set { _TabuleiroLocal = value; }
        }

        public ClienteTabuleiroLocal ClienteTabuleiroLocal
        {
            get { return _clienteTabuleiroLocal; }
            set { _clienteTabuleiroLocal = value; }
        }

        public ClientePecasLocal[] ClientePecasLocal1
        {
            get { return _clientePecasLocal1; }
            set { _clientePecasLocal1 = value; }
        }

        public ClientePecasLocal[] ClientePecasLocal2
        {
            get { return _clientePecasLocal2; }
            set { _clientePecasLocal2 = value; }
        }

        public Boolean Conectado
        {
            get { return _Conectado; }
            set { _Conectado = value; }
        }

        public Boolean Iniciado
        {
            get { return _Iniciado; }
            set { _Iniciado = value; }
        }

        public void jogadorLoadContent(ref ClienteJogador pJogador, Viewport pViewport, ContentManager pContent)
        {
            if ((pJogador.ClienteTabuleiroLocal != null))
                pJogador.ClienteTabuleiroLocal.CarregarModelo(pContent);
            for (int i = 0; i < pJogador.ClientePecasLocal1.Count(); i++)
            {
                if ((pJogador.ClientePecasLocal1[i] != null))
                {
                    pJogador.ClientePecasLocal1[i].CarregarModelo(pJogador, 1, pContent);
                }
            }
            for (int i = 0; i < pJogador.ClientePecasLocal2.Count(); i++)
            {
                if ((pJogador.ClientePecasLocal2[i] != null))
                {
                    pJogador.ClientePecasLocal2[i].CarregarModelo(pJogador, 2, pContent);
                }
            }

        }

        public void jogadorUpdate(ref ClienteJogador pJogador, KeyboardState teclado_estado, MouseState mouseState)
        {
            //PEgar estado e mover a peça.
            //Depois enviar movimentacao ao serivor
            //Se servidor retornar OK, atualizar a tela
            //aguardar pela moviemntaão do outro jogador

            Boolean bClicou = false;
            Rectangle QuadradoMouse;
            Rectangle QuadradoQuadroTabuleiro;

            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                bClicou = true;
                QuadradoMouse = new Rectangle
                                    (Convert.ToInt32(mouseState.X - 1),
                                     Convert.ToInt32(mouseState.Y - 1),
                                     Convert.ToInt32(mouseState.X + 1),
                                     Convert.ToInt32(mouseState.Y + 1));
            }

                //Nenhuma peça selecionada.
                if ((pJogador.PecaSelecionada >= 0) &&
                    (pJogador.QuadroSelecionado >= 0))
                {
                    Boolean bMoveu = false;
                    int posX = 0, posY = 0, xMoverPara = 0, yMoverPara = 0;
                    Vector2 posicaoTemp1 = new Vector2(0, 0);
                    Vector2 posicaoTemp2 = new Vector2(0, 0);

                    //MOver peça para o quadro
                    if ((pJogador.NumJogadorCliente <= 1))
                    {
                        posicaoTemp1 = this.ClienteTabuleiroLocal.quadros[pJogador.QuadroSelecionado].posicaoInicio;
                    }
                    else if ((pJogador.NumJogadorCliente >= 2))
                    {
                        posicaoTemp2 = this.ClienteTabuleiroLocal.quadros[pJogador.QuadroSelecionado].posicaoInicio;
                    }

                    //Local
                    posX = Convert.ToInt32(((this.ClienteTabuleiroLocal.quadros[pJogador.QuadroSelecionado].posicaoFim.X - Principal.DIFX) / Convert.ToInt32(Principal.LARGURA_TELA / 8)));
                    posY = Convert.ToInt32(((this.ClienteTabuleiroLocal.quadros[pJogador.QuadroSelecionado].posicaoFim.Y - Principal.DIFY) / Convert.ToInt32(Principal.ALTURA_TELA / 8)));

                    xMoverPara = posX + 1;
                    yMoverPara = posY;                    

                    bMoveu = pJogador.clientNetwork.MoverPeca(
                               pJogador.NumJogadorCliente - 1,
                               pJogador.PecaSelecionada,
                               xMoverPara,
                               yMoverPara);
                    

                    if ((bMoveu)) 
                    {

                        if ((pJogador.NumJogadorCliente <= 1))
                        {
                            pJogador.ClientePecasLocal1[pJogador.PecaSelecionada].PosicaoAtual = posicaoTemp1;
                        }
                        else if ((pJogador.NumJogadorCliente >= 2))
                        {
                            pJogador.ClientePecasLocal2[pJogador.PecaSelecionada].PosicaoAtual = posicaoTemp2;
                        }

                        pJogador.TabuleiroLocal.lJogador[pJogador.NumJogadorCliente - 1].Peca[pJogador.PecaSelecionada].PosicaoXDaPeca = xMoverPara;
                        pJogador.TabuleiroLocal.lJogador[pJogador.NumJogadorCliente - 1].Peca[pJogador.PecaSelecionada].PosicaoYDaPeca = yMoverPara;
                       
                        if ((pJogador.NumJogadorCliente <= 1))
                        {
                            for (int i = 0; i < pJogador.ClientePecasLocal1.Count(); i++)
                            {
                                pJogador.ClientePecasLocal1[i].Iniciar(pJogador.TabuleiroLocal, 0, i);
                            }
                        }
                        else if ((pJogador.NumJogadorCliente >= 2))
                        {
                            for (int i = 0; i < pJogador.ClientePecasLocal1.Count(); i++)
                            {
                                pJogador.ClientePecasLocal2[i].Iniciar(pJogador.TabuleiroLocal, 1, i);
                            }
                        }

                        Int32 iUltJogPecaMorta = -1, iUltPecaAMorrer = -1;

                        pJogador.PecaSelecionada = -1;
                        pJogador.QuadroSelecionado = -1;
                        pJogador.EstadoJogador = "AGUARDANDO_OUTRO_JOGADOR";

                        iUltJogPecaMorta = pJogador.clientNetwork.GetUltimoJogadorPecaMorta();
                        if ((iUltJogPecaMorta >= 0))
                        {
                            iUltPecaAMorrer = pJogador.clientNetwork.GetUltimaPecaAMover();

                            if ((iUltPecaAMorrer >= 0))
                            {
                                if ((iUltJogPecaMorta == 0))
                                {
                                    pJogador.ClientePecasLocal1[iUltJogPecaMorta].Ativa = false;
                                }
                                else
                                {
                                    pJogador.ClientePecasLocal2[iUltJogPecaMorta].Ativa = false;
                                }
                            }
                        }
                    }
                    else
                    {

                        pJogador.PecaSelecionada = -1;
                        pJogador.QuadroSelecionado = -1;
                        pJogador.EstadoJogador = "MOVIMENTACAO_INVALIDA";
                    } //else                 

                } //if
                else if ((bClicou) &&
                         (pJogador.EstadoJogador != "AGUARDANDO_OUTRO_JOGADOR") &&
                        (pJogador.PecaSelecionada <= -1) &&
                         (pJogador.QuadroSelecionado <= -1))
                {
                    int xLarg = 0, yLarg = 0;

                     xLarg = (Principal.LARGURA_TELA / 8);
                     yLarg = (Principal.ALTURA_TELA / 8);

                    if ((pJogador.NumJogadorCliente <= 1))
                    {
                        for (int i = 0; i < pJogador.ClientePecasLocal1.Count(); i++)
                        {

                            if ((pJogador.ClientePecasLocal1[i].PosicaoAtual.X <= mouseState.X) &&
                                (pJogador.ClientePecasLocal1[i].PosicaoAtual.X + xLarg >= mouseState.X) &&
                                (pJogador.ClientePecasLocal1[i].PosicaoAtual.Y <= mouseState.Y) &&
                                (pJogador.ClientePecasLocal1[i].PosicaoAtual.Y + yLarg >= mouseState.Y))
                            {
                                pJogador.PecaSelecionada = i;
                                pJogador.EstadoJogador = "SELECIONOU_PECA";
                            }

                            //if ((ClientePecasLocal1[i].EspacoPeca.Intersects(QuadradoMouse)))
                            //{                                
                            //}
                        } //for
                    }
                    else if ((pJogador.NumJogadorCliente >= 2))
                    {                        

                        for (int i = 0; i < pJogador.ClientePecasLocal2.Count(); i++)
                        {

                            if ((pJogador.ClientePecasLocal2[i].PosicaoAtual.X <= mouseState.X) &&
                                (pJogador.ClientePecasLocal2[i].PosicaoAtual.X + xLarg >= mouseState.X) &&
                                (pJogador.ClientePecasLocal2[i].PosicaoAtual.Y <= mouseState.Y) &&
                                (pJogador.ClientePecasLocal2[i].PosicaoAtual.Y + yLarg >= mouseState.Y))
                            {
                                pJogador.PecaSelecionada = i;
                                pJogador.EstadoJogador = "SELECIONOU_PECA";
                            }

                            //if ((ClientePecasLocal2[i].EspacoPeca.Intersects(QuadradoMouse)))
                            //{
                            //}
                        } //for
                    }

                    Thread.Sleep(500);

                } //(pJogador.PecaSelecionada <= -1)
                else if ((bClicou) &&
                         (pJogador.EstadoJogador != "AGUARDANDO_OUTRO_JOGADOR") &&
                         (pJogador.QuadroSelecionado <= -1) &&
                         (pJogador.PecaSelecionada >= 0))
                {
                    int xLarg = 0, yLarg = 0;

                    xLarg = (Principal.LARGURA_TELA / 8);
                    yLarg = (Principal.ALTURA_TELA / 8);

                    for (int i = 0; i < this.ClienteTabuleiroLocal.quadros.Count(); i++)
                    {
                        QuadradoQuadroTabuleiro =
                                 new Rectangle
                                       (Convert.ToInt32(ClienteTabuleiroLocal.quadros[i].posicaoInicio.X),
                                        Convert.ToInt32(ClienteTabuleiroLocal.quadros[i].posicaoInicio.Y),
                                        Convert.ToInt32(ClienteTabuleiroLocal.quadros[i].posicaoFim.X),
                                        Convert.ToInt32(ClienteTabuleiroLocal.quadros[i].posicaoFim.Y));

                        if ((ClienteTabuleiroLocal.quadros[i].posicaoInicio.X <= mouseState.X) &&
                            (ClienteTabuleiroLocal.quadros[i].posicaoInicio.X + xLarg >= mouseState.X) &&
                            (ClienteTabuleiroLocal.quadros[i].posicaoInicio.Y <= mouseState.Y) &&
                            (ClienteTabuleiroLocal.quadros[i].posicaoInicio.Y + yLarg >= mouseState.Y))
                        {
                            pJogador.QuadroSelecionado = i;
                            pJogador.EstadoJogador = "SELECIONOU_QUADRO";
                        }

                        //if ((QuadradoQuadroTabuleiro.Intersects(QuadradoMouse)))
                        //{                            
                        //}  //if

                    } //for

                    Thread.Sleep(500);
                }
                else if ((pJogador.EstadoJogador == "AGUARDANDO_OUTRO_JOGADOR") ||
                         (pJogador.EstadoJogador == ""))
                {
                    Int32 iUtlJogadorAMover = -1;
                    
                    iUtlJogadorAMover = pJogador.clientNetwork.GetUltimoJogadorAMover();
                    
                    if ((iUtlJogadorAMover > -1) &&
                        (iUtlJogadorAMover != pJogador.NumJogadorCliente)) {

                            pJogador.EstadoJogador = "";

                            iUtlJogadorAMover = iUtlJogadorAMover - 1;

                            Int32 iUltimaPecaAMover = -1;
                            Int32 iPosXUltimaPeca = 0;
                            Int32 iPosYUltimaPeca = 0;

                            iUltimaPecaAMover = pJogador.clientNetwork.GetUltimaPecaAMover();

                            if ((iUltimaPecaAMover >= 0))
                            {

                                iPosXUltimaPeca = pJogador.clientNetwork.GetXUltimaPeca();
                                iPosYUltimaPeca = pJogador.clientNetwork.GetYUltimaPeca();

                                if ((iUtlJogadorAMover == 0))
                                {

                                    pJogador.TabuleiroLocal.lJogador[iUtlJogadorAMover].Peca[iUltimaPecaAMover].PosicaoXDaPeca = iPosXUltimaPeca;
                                    pJogador.TabuleiroLocal.lJogador[iUtlJogadorAMover].Peca[iUltimaPecaAMover].PosicaoYDaPeca = iPosYUltimaPeca;

                                    pJogador.ClientePecasLocal1[iUltimaPecaAMover].Iniciar(pJogador.TabuleiroLocal, iUtlJogadorAMover, iUltimaPecaAMover);

                                }
                                else
                                {
                                    pJogador.TabuleiroLocal.lJogador[iUtlJogadorAMover].Peca[iUltimaPecaAMover].PosicaoXDaPeca = iPosXUltimaPeca;
                                    pJogador.TabuleiroLocal.lJogador[iUtlJogadorAMover].Peca[iUltimaPecaAMover].PosicaoYDaPeca = iPosYUltimaPeca;

                                    pJogador.ClientePecasLocal2[iUltimaPecaAMover].Iniciar(pJogador.TabuleiroLocal, iUtlJogadorAMover, iUltimaPecaAMover);
                                }
                            }                        
                    }
                }

                
        }

        public void jogadorDraw(ref ClienteJogador pJogador, SpriteBatch pSpriteBatch)
        {

            if ((pJogador.ClienteTabuleiroLocal != null))
                pJogador.ClienteTabuleiroLocal.DesenharTabuleiro(pSpriteBatch);

            for (int i = 0; i < pJogador.ClientePecasLocal1.Count(); i++)
            {
                if ((pJogador.ClientePecasLocal1[i] != null))
                    pJogador.ClientePecasLocal1[i].DesenharPecas(pJogador, pSpriteBatch);
            }

            for (int i = 0; i < pJogador.ClientePecasLocal2.Count(); i++)
            {
                if ((pJogador.ClientePecasLocal2[i] != null))
                    pJogador.ClientePecasLocal2[i].DesenharPecas(pJogador, pSpriteBatch);
            }
        }
    }
}
