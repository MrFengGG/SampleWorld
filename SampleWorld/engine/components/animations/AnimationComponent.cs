using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.gameObjects;
using SampleWorld.engine.support;

namespace SampleWorld.engine.components.animations
{
    class AnimationComponent : DrawableLocalComponent, IDepthAdjustable
    {
        Animation animation;

        public float Depth { get; set; }

        public AnimationComponent(GameObject gameObject, AnimationFrame firstFrame) : base(gameObject)
        {
            Depth = gameObject.Depth;
            animation = new Animation(SpriteBatch, firstFrame);
        }

        public override void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            animation.Draw(gameTime, Parent.Position, Parent.Scale, Parent.Rotation, Depth);
        }
    }
}
