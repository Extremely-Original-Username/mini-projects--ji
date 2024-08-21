using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Model.Config;
using Model.Geometry;
using System.Collections.Generic;
using System;
using System.Linq;
using Model.Objects;
using Model.Genetics.Parts;
using Model.Genetics.Parts.Base;

namespace Critters
{
    public class CrittersGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private World world;
        private List<Agent> agents;

        private Texture2D worldSprite;
        private Dictionary<Agent, Texture2D[]> agentSprites;

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
                if (agent.GetType() == typeof(Critter))
                {
                    _spriteBatch.Draw(agentSprites[agent][0],
                        new Rectangle(
                            Convert.ToInt32(agent.Position.X) - Convert.ToInt32(agent.Size.X / 2), Convert.ToInt32(agent.Position.Y) - Convert.ToInt32(agent.Size.Y / 2),
                            Convert.ToInt32(agent.Size.X), Convert.ToInt32(agent.Size.Y)
                            ),
                        Color.White);
                    for (int i = 1; i < agentSprites[agent].Length; i++)
                    {
                        var partOffset = PartDef.GetPartPosition(i - 1, GlobalConfig.maxChildParts, agent.FacingAngle.toAngle());
                        partOffset.X *= GlobalConfig.baseAgentSize / 1.5;
                        partOffset.Y *= GlobalConfig.baseAgentSize / 1.5;

                        _spriteBatch.Draw(agentSprites[agent][i],
                        new Rectangle(
                            Convert.ToInt32(agent.Position.X) - Convert.ToInt32(agent.Size.X / 2) + (int)partOffset.X, Convert.ToInt32(agent.Position.Y) - Convert.ToInt32(agent.Size.Y / 2) + (int)partOffset.Y,
                            Convert.ToInt32(agent.Size.X), Convert.ToInt32(agent.Size.Y)
                            ),
                        Color.White);
                    }
                }
                else
                {
                    _spriteBatch.Draw(agentSprites[agent][0],
                        new Rectangle(
                            Convert.ToInt32(agent.Position.X) - Convert.ToInt32(agent.Size.X / 2), Convert.ToInt32(agent.Position.Y) - Convert.ToInt32(agent.Size.Y / 2),
                            Convert.ToInt32(agent.Size.X), Convert.ToInt32(agent.Size.Y)
                            ),
                        Color.White);
                }
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

        private Texture2D GenerateCircleSprite(Vector2<int> size, Color color)
        {
            // Create a new Texture2D with the specified width and height
            var result = new Texture2D(GraphicsDevice, size.X, size.Y);

            // Initialize a color array for the texture data
            var dataColors = new Color[result.Width * result.Height];

            // Calculate the radius of the circle
            int radius = Math.Min(size.X, size.Y) / 2 - 1; //-1 helps with smaller sizes
            int centerX = size.X / 2;
            int centerY = size.Y / 2;

            for (var y = 0; y < size.Y; y++)
            {
                for (var x = 0; x < size.X; x++)
                {
                    // Calculate the distance from the center of the texture
                    int distX = x - centerX;
                    int distY = y - centerY;
                    double distance = Math.Sqrt(distX * distX + distY * distY);

                    // If the distance is less than or equal to the radius, color the pixel
                    if (distance <= radius)
                    {
                        dataColors[y * size.X + x] = color; // White color with full opacity
                    }
                    else
                    {
                        dataColors[y * size.X + x] = new Color(0, 0, 0, 0); // Transparent
                    }
                }
            }

            // Set the texture data
            result.SetData(dataColors);

            return result;
        }

        private Texture2D[] GenerateAgentSprite(Agent agent)
        {
            return new Texture2D[1] { GenerateCircleSprite(agent.Size, new Color(255, 255, 255, 255)) };
        }

        private Texture2D[] GenerateCritterSprite(Critter agent)
        {
            return GeneratePartSprite(agent.BasePart);
        }

        private Texture2D[] GeneratePartSprite(Part part)
        {
            List<Texture2D> result = new List<Texture2D>() { GenerateCircleSprite(part.Size, part.Definition.Name == "Photosynthesis" ? new Color(100, 255, 100, 255) : new Color(255, 255, 255, 255)) };
            foreach (var child in part.Children)
            {
                if (child != null && child.Definition != null)
                {
                    result.AddRange(GeneratePartSprite(child));
                }
            }

            return result.ToArray();
        }

        private Dictionary<Agent, Texture2D[]> GenerateAgentSprites(List<Agent> agents)
        {
            Dictionary < Agent, Texture2D[]> result = new Dictionary<Agent, Texture2D[]> ();

            foreach (var agent in agents)
            {
                if (agent.GetType() == typeof(Critter))
                {
                    result.Add(agent, GenerateCritterSprite((Critter)agent));
                }
                else result.Add(agent, GenerateAgentSprite(agent));
            }

            return result;
        }

        #endregion
    }
}
