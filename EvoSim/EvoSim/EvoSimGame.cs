using EvoSim.Library.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EvoSim.Library.Geometry;
using System;
using System.Collections.Generic;

namespace EvoSim
{
    public class EvoSimGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Agent> agents;

        public EvoSimGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        #region Main

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            agents = getStartingAgents(getBaseAgentSprite());
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            _spriteBatch.Begin();

            addAgentsToSpriteBatch();

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        #endregion

        #region Helpers

        private List<Agent> getStartingAgents(Texture2D sprite)
        {
            return new List<Agent>()
            {
                new Agent(new Transform(new Vector2Int(0, 0), new Vector2Int(10, 10)), sprite),
                new Agent(new Transform(new Vector2Int(10, 10), new Vector2Int(10, 10)), sprite),
                new Agent(new Transform(new Vector2Int(20, 20), new Vector2Int(10, 10)), sprite),
                new Agent(new Transform(new Vector2Int(30, 30), new Vector2Int(10, 10)), sprite),
                new Agent(new Transform(new Vector2Int(40, 40), new Vector2Int(10, 10)), sprite)
            };
        }

        private Texture2D getBaseAgentSprite()
        {
            return Texture2D.FromFile(GraphicsDevice, "content/sprites/square.jpg");
        }

        private void addAgentsToSpriteBatch()
        {
            foreach (var agent in agents)
            {
                _spriteBatch.Draw(agent.Texture,
                new Rectangle(
                    Convert.ToInt32(agent.Transform.Position.X) - Convert.ToInt32(agent.Transform.Size.X / 2), Convert.ToInt32(agent.Transform.Position.Y) - Convert.ToInt32(agent.Transform.Size.Y / 2),
                    Convert.ToInt32(agent.Transform.Size.X), Convert.ToInt32(agent.Transform.Size.Y)
                    ),
                Color.White);
            }
        }

        #endregion
    }
}
