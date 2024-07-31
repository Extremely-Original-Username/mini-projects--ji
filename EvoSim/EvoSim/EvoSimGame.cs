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

        private World world;
        private List<Agent> agents;

        public EvoSimGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = false;
            
        }

        #region Main

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = GlobalConfig.arenaWidth;
            _graphics.PreferredBackBufferHeight = GlobalConfig.arenaHeight;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            world = new World(GraphicsDevice);
            agents = getStartingAgents(getBaseAgentSprite());
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Agent agent in agents)
            {
                agent.OnUpdate();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            _spriteBatch.Begin();

            addWorldToSpriteBatch();
            addAgentsToSpriteBatch();

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion

        #region Helpers

        private List<Agent> getStartingAgents(Texture2D sprite)
        {
            var result = new List<Agent>();

            for (int i = 0; i < GlobalConfig.baseAgentCount; i++)
            {
                Random r = new Random();
                result.Add(new Critter(
                    new Transform(
                        new Vector2Int(r.Next() % GlobalConfig.arenaWidth, r.Next() % GlobalConfig.arenaHeight), 
                        new Vector2Int(GlobalConfig.baseAgentSize, GlobalConfig.baseAgentSize)
                        ),
                    sprite
                    ));
            }

            return result;
        }

        private Texture2D getBaseAgentSprite()
        {
            return Texture2D.FromFile(GraphicsDevice, "content/sprites/square.jpg");
        }

        private void addWorldToSpriteBatch()
        {
            _spriteBatch.Draw(world.Texture,
                new Rectangle(
                    Convert.ToInt32(world.Transform.Position.X), Convert.ToInt32(world.Transform.Position.Y),
                    Convert.ToInt32(world.Transform.Size.X), Convert.ToInt32(world.Transform.Size.Y)
                    ),
                Color.White);
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
