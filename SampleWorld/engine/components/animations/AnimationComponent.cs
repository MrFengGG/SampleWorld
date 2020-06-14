using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.engine.components.animations
{
    class AnimationComponent : DrawableLocalComponent
    {
        Animation animation;

        public AnimationComponent(GameObject gameObject, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, AnimationFrame firstFrame) : base(gameObject, graphicsDevice, spriteBatch)
        {
            animation = new Animation(spriteBatch, firstFrame);
        }

        public override void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            animation.Draw(gameTime, Parent.Position, Parent.Scale, Parent.Rotation);
        }
    }
}
