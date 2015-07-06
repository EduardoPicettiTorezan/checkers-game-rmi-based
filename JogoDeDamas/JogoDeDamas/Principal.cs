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

namespace JogoDeDamas
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 

    public class Principal : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ClienteJogador lJogador = new ClienteJogador();
        KeyboardState teclado_estado;

        public const int LARGURA_TELA = 600;
        public const int ALTURA_TELA = 625;


        public const int DIFY = 4;
        public const int DIFX = 4;

        public Principal()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = LARGURA_TELA;
            graphics.PreferredBackBufferHeight = ALTURA_TELA;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            this.IsMouseVisible = true;
            if ((lJogador.Iniciado == false))
                lJogador.Iniciar(ref lJogador, MenuInicial.sIpdoServidor, MenuInicial.iNumJogadorSel);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //carga das texturas
            Viewport viewport = graphics.GraphicsDevice.Viewport;

            if ((lJogador.Iniciado == false))
                lJogador.Iniciar(ref lJogador, MenuInicial.sIpdoServidor, MenuInicial.iNumJogadorSel);

            lJogador.jogadorLoadContent(ref lJogador, viewport, Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            //Captura ação no teclado.
            teclado_estado = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();            

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            lJogador.jogadorUpdate(ref lJogador, teclado_estado, mouseState);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            lJogador.jogadorDraw(ref lJogador, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
