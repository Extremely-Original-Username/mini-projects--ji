﻿using Microsoft.Xna.Framework;
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
using Critters.Drawing;
using Model.Genetics;

namespace Critters
{
    public class CrittersGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private World world;

        private Texture2D worldSprite;
        private Dictionary<Agent, Texture2D[]> agentSprites = new Dictionary<Agent, Texture2D[]>();

        private SpriteHelper spriteHelper;

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
            spriteHelper = new SpriteHelper(GraphicsDevice);

            world = new World(GlobalConfig.arenaWidth, GlobalConfig.arenaHeight);
            worldSprite = spriteHelper.GenerateWorldSprite(world);

            LoadEvents();

            var startingAgents = getStartingAgents();
            foreach (var agent in startingAgents)
            {
                world.addAgent(agent);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            world.Update();

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
            for (int i = 0; i < GlobalConfig.baseCritterCount; i++)
            {
                DNA dna = new DNA();
                for (int j = 0; j < GlobalConfig.baseEvolution; j++) dna.Evolve();
                result.Add(new Critter(world, 
                        new Vector2<int>(r.Next() % world.Width, r.Next() % world.Height),
                        new Vector2<int>(GlobalConfig.baseAgentSize, GlobalConfig.baseAgentSize),
                        new Vector2<float>(),
                        dna
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
            foreach (var agent in world.getAgents())
            {
                if (agent.GetType() == typeof(Critter))
                {
                    for (int i = 0; i < agentSprites[agent].Length; i++)
                    {
                        var currentSprite = (SpriteHelper.PartTexture)agentSprites[agent][i];
                        var partPosition = ((Critter)agent).getPartPosition(currentSprite.Part);

                        _spriteBatch.Draw(currentSprite,
                        new Rectangle(
                            Convert.ToInt32(partPosition.X) - Convert.ToInt32(agent.Size.X / 2), Convert.ToInt32(partPosition.Y) - Convert.ToInt32(agent.Size.Y / 2),
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

        private void LoadEvents()
        {
            world.OnAgentCreated += (x) => {
                if (x.GetType() == typeof(Critter))
                {
                    agentSprites.Add(x, spriteHelper.GenerateCritterSprite((Critter)x));
                    return;
                }
                agentSprites.Add(x, spriteHelper.GenerateAgentSprite(x));
            };
        }

        #endregion
    }
}
