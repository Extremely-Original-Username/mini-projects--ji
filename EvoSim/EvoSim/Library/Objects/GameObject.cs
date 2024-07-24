using EvoSim.Library.Geometry;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSim.Library.Objects
{
    public abstract class GameObject
    {
        public Transform Transform { get; set; }
        public Texture2D Texture {  get; set; }

        public GameObject(GraphicsDevice graphicsDevice)
        {
            Transform = new Transform();
            Texture = new Texture2D(graphicsDevice, Convert.ToInt32(Transform.Size.X), Convert.ToInt32(Transform.Size.Y));
        }

        public GameObject(Transform transform, Texture2D texture)
        {
            Transform = transform;
            Texture = texture;
        }
    }
}
