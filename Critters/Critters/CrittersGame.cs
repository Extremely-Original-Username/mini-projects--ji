using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Model.Config;
using Model.Geometry;
using System.Collections.Generic;
using System;
using System.Linq;
using Model.Objects;

namespace Critters
{
    public class CrittersGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private World world;
        private List<Agent> agents;

        private Texture2D worldSprite;
        private Dictionary<Agent, Texture2D> agentSprites;

        public CrittersGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
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

            world = new World(GlobalConfig.arenaWidth, GlobalConfig.arenaHeight);
            worldSprite = GenerateWorldSprite(world);

            agents = getStartingAgents();
            agentSprites = GenerateAgentSprites(agents);
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

        private List<Agent> getStartingAgents()
        {
            var result = new List<Agent>();

            Random r = new Random();
            for (int i = 0; i < GlobalConfig.baseAgentCount; i++)
            {
                result.Add(new Critter(world, 
                        new Vector2<int>(r.Next() % world.Width, r.Next() % world.Height),
                        new Vector2<int>(GlobalConfig.baseAgentSize, GlobalConfig.baseAgentSize),
                        new Vector2<float>()
                    ));
            }

            return result;
        }

        private void addWorldToSpriteBatch()
        {
            _spriteBatch.Draw(worldSprite,
                new Rectangle(
                    0, 0,
                    world.Width, world.Height
                    ),
                Color.White);
        }

        private void addAgentsToSpriteBatch()
        {
            foreach (var agent in agents)
            {
                _spriteBatch.Draw(agentSprites[agent],
                new Rectangle(
                    Convert.ToInt32(agent.Position.X) - Convert.ToInt32(agent.Size.X / 2), Convert.ToInt32(agent.Position.Y) - Convert.ToInt32(agent.Size.Y / 2),
                    Convert.ToInt32(agent.Size.X), Convert.ToInt32(agent.Size.Y)
                    ),
                Color.White);
            }
        }

        private Texture2D GenerateWorldSprite(World world)
        {
            var result = new Texture2D(GraphicsDevice, world.Width, world.Height);
            var dataColors = new Color[result.Width * result.Height];

            for (int y = 0; y < world.Height; y++)
            {
                for (int x = 0; x < world.Width; x++)
                {
                    float lightLevel = world.lightMap[x, y];
                    float value = 255f * lightLevel;
                    dataColors[y * world.Width + x] = new Color(
                        Convert.ToInt32(255f * lightLevel),
                        Convert.ToInt32(255f * lightLevel),
                        Convert.ToInt32(255f * lightLevel),
                        1000);
                }
            }

            result.SetData(dataColors);
            return result;
        }

        private Texture2D GenerateAgentSprite(Agent agent)
        {
            var result = new Texture2D(GraphicsDevice, agent.Size.X, agent.Size.Y);
            var dataColors = new Color[result.Width * result.Height];
            for (var i = 0; i < dataColors.Count(); i++)
            {
                dataColors[i] = new Color(255, 255, 255, 255);
            }

            result.SetData(dataColors);
            return result;
        }

        private Dictionary<Agent, Texture2D> GenerateAgentSprites(List<Agent> agents)
        {
            Dictionary < Agent, Texture2D > result = new Dictionary<Agent, Texture2D> ();

            foreach (var agent in agents)
            {
                result.Add(agent, GenerateAgentSprite(agent));
            }

            return result;
        }

        #endregion
    }
}
