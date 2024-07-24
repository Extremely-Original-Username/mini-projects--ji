using EvoSim.Library.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EvoSim.Library.Geometry;
using System;

namespace EvoSim
{
    public class EvoSimGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Agent testAgent;

        public EvoSimGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Texture2D square = Texture2D.FromFile(GraphicsDevice, "content/sprites/square.jpg");
            testAgent = new Agent(new Transform(new Vector2Int(50, 50), new Vector2Int(10, 10)), square);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            testAgent.Jitter();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            _spriteBatch.Begin();

            _spriteBatch.Draw(testAgent.Texture, 
                new Rectangle(
                    Convert.ToInt32(testAgent.Transform.Position.X), Convert.ToInt32(testAgent.Transform.Position.Y),
                    Convert.ToInt32(testAgent.Transform.Size.X), Convert.ToInt32(testAgent.Transform.Size.Y)
                    ),
                Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
