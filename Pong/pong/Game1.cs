using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UI;
namespace pong
{
    public enum Scene{MainMenu,PongGame,Scores};
    
    public class Game1 : Game
    {
        private Scene scene;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D ButtonTexture;
        public Button botaoteste;
        Vector2 Buttonpos = new Vector2(20,20);
        Vector2 Buttonsize = new Vector2(50, 50);

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            scene = Scene.MainMenu;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            switch(scene)
            {
                case Scene.MainMenu:
                    ButtonTexture = Content.Load<Texture2D>("texturabotao");
                    botaoteste = new Button(ButtonTexture, Buttonsize);
                    botaoteste.setPosition(Buttonpos);
                    break;
            }
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            switch (scene)
            {
                case Scene.MainMenu:
                    botaoteste.Update(Mouse.GetState());
                    if (botaoteste.isClicked == true)
                    {
                        scene = Scene.PongGame;
                    }
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
                    break;
            }

            // Termina o desenho
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}