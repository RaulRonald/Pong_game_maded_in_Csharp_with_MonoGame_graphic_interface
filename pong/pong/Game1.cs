using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UI;
using ObjectsScene;
using System;
namespace pong
{
    public enum Scene{MainMenu,PongGame,Scores};
    
    public class Game1 : Game
    {
        private Scene scene;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D ButtonTexture,PlayersTexture,bolatexture,pongbarrertexture;
        Button botaoteste;
        PongPlayer player1, player2;
        ball bola;
        Vector2 Buttonpos, player1pos, player2pos, bolapos;
        Vector2 Buttonsize, playersize, bolasize;
        Rectangle barrerarea;
        Color barrercolor;
        SpriteFont font;
        int WindowWidth;
        int WindowHight;
        int pointp1, pointp2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 810;  // Largura desejada
            _graphics.PreferredBackBufferHeight = 720; // Altura desejada
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            scene = Scene.MainMenu;
            
            WindowWidth = _graphics.PreferredBackBufferWidth;
            WindowHight = _graphics.PreferredBackBufferHeight;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            switch(scene)
            {
                case Scene.MainMenu:
                    Buttonpos = new Vector2(300, 180);
                    Buttonsize = new Vector2(200, 200);
                    ButtonTexture = Content.Load<Texture2D>("texturabotao");
                    botaoteste = new Button(ButtonTexture, Buttonsize);
                    botaoteste.setPosition(Buttonpos);
                    font = Content.Load<SpriteFont>("fonte");
                    break;
            }
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            switch (scene)
            {
                case Scene.MainMenu:
                    botaoteste.Update(Mouse.GetState());
                    if (botaoteste.isClicked == true)
                    {
                        pointp1 = 0;
                        pointp2 = 0;
                        bolapos = new Vector2(250, 250);
                        player1pos = new Vector2(10, 300);
                        player2pos = new Vector2(720, 300);
                        bolasize = new Vector2(25, 25);
                        playersize = new Vector2(25, 50);
                        barrerarea = new Rectangle(360,0,16,720);
                        barrercolor = Color.White;
                        bolatexture = Content.Load<Texture2D>("pongball");
                        pongbarrertexture = Content.Load<Texture2D>("pongbarrer");
                        PlayersTexture = Content.Load<Texture2D>("PongPlayer");
                        bola = new ball(bolatexture, bolasize);
                        player1 = new PongPlayer(PlayersTexture, playersize);
                        player2 = new PongPlayer(PlayersTexture, playersize);
                        bola.setPosition(bolapos);
                        bola.setXvelocity(2);
                        bola.setYvelocity(2);
                        player1.setPosition(player1pos);
                        player2.setPosition(player2pos);
                        botaoteste = null;
                        scene = Scene.PongGame;
                        LoadContent();
                    }
                    break;
                case Scene.PongGame:
                    if(pointp1 == 5 || pointp2 == 5)
                    {
                        scene = Scene.Scores;
                    }
                    if (state.IsKeyDown(Keys.W))
                    {
                        Vector2 posy = new Vector2(player1.getposition().X,player1.getposition().Y - 3);
                        player1.setPosition(posy);
                    }
                    else if (state.IsKeyDown(Keys.S))
                    {
                        Vector2 posy = new Vector2(player1.getposition().X, player1.getposition().Y + 3);
                        player1.setPosition(posy);
                    }
                    if (state.IsKeyDown(Keys.Up))
                    {
                        Vector2 posy = new Vector2(player2.getposition().X, player2.getposition().Y - 3);
                        player2.setPosition(posy);
                    }
                    else if (state.IsKeyDown(Keys.Down))
                    {
                        Vector2 posy = new Vector2(player2.getposition().X, player2.getposition().Y + 3);
                        player2.setPosition(posy);
                    }
                    player1.Update();
                    player2.Update();
                    // colisão com a janela
                    if ((bola.getposition().X + bolasize.X) >= WindowWidth)
                    {
                        bola.setXvelocity(((int)bola.getvelocity().X * -1));
                        bola.setPosition(bolapos);
                        pointp1++;
                        Console.WriteLine("PLAYER 1 : " + pointp1 + " PLAYER 2 :" + pointp2);
                    }
                    if (bola.getposition().X <= 0)
                    {
                        bola.setXvelocity((int)bola.getvelocity().X * -1);
                        bola.setPosition(bolapos);
                        pointp2++;
                        Console.WriteLine("PLAYER 1 : " + pointp1 + " PLAYER 2 :" + pointp2);
                    }
                    if ((bola.getposition().Y) <= 0)
                    {
                        bola.setYvelocity(((int)bola.getvelocity().Y * -1));
                    }
                    if (bola.getposition().Y + bolasize.Y >= WindowHight)
                    {
                        bola.setYvelocity((int)bola.getvelocity().Y * -1);
                    }
                    //colisão com os players
                    if (bola.getposition().Y <= player1.getposition().Y + playersize.Y && bola.getposition().Y + bolasize.Y >= player1.getposition().Y)
                    {
                        if(bola.getposition().X <= player1.getposition().X + playersize.X)
                        {
                            bola.setXvelocity((int)bola.getvelocity().X * -1);
                        }
                    }
                    if (bola.getposition().Y <= player2.getposition().Y + playersize.Y && bola.getposition().Y + bolasize.Y >= player2.getposition().Y)
                    {
                        if (bola.getposition().X + bolasize.X >= player2.getposition().X)
                        {
                            bola.setXvelocity((int)bola.getvelocity().X * -1);
                        }
                    }
                    bola.Update();
                    break;
            }
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            // Inicia o desenho
            _spriteBatch.Begin();
            switch (scene)
            {
                case Scene.MainMenu:
                    // Desenha o botão
                    botaoteste.Draw(_spriteBatch);
                    break;
                case Scene.PongGame:
                    player1.Draw(_spriteBatch);
                    player2.Draw(_spriteBatch);
                    bola.Draw(_spriteBatch);
                    _spriteBatch.Draw(pongbarrertexture, barrerarea, barrercolor);
                    _spriteBatch.DrawString(font, pointp1.ToString(), new Vector2(330, 50), Color.White);
                    _spriteBatch.DrawString(font, pointp2.ToString(), new Vector2(390, 50), Color.White);
                    break;
            }

            // Termina o desenho
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}