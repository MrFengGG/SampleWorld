
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.engine.components
{
    public abstract class DrawableLocalComponent : LocalComponent
    {
        public GraphicsDevice GraphicsDevice { get; }

        public SpriteBatch SpriteBatch { get; }

        public DrawableLocalComponent(GameObject gameObject) : base(gameObject){
            GraphicsDevice = gameObject.World.GraphicsDevice;
            SpriteBatch = gameObject.World.SpriteBatch;
        }

        public abstract void Draw(GameTime gameTime);
    }
}
