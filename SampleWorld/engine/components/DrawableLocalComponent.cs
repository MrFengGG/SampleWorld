
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.engine.components
{
    public abstract class DrawableLocalComponent : LocalComponent
    {
        public GraphicsDevice GraphicsDevice { get; }

        public SpriteBatch SpriteBatch { get; }

        public DrawableLocalComponent(GameObject gameObject, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch) : base(gameObject){
            GraphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;
        }

        public abstract void Draw(GameTime gameTime);
    }
}
