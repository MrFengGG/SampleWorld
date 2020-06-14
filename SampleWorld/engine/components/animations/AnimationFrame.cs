using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SampleWorld.engine.components.animations
{
    class AnimationFrame
    {
        public Texture2D Texture { get; set; }

        public Rectangle Rectangle { get; set; }

        public AnimationFrame(Texture2D texture)
        {
            Texture = texture;
            Rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public AnimationFrame(Texture2D texture, Rectangle rectangle)
        {
            Texture = texture;
            this.Rectangle = rectangle;
        }
    }
}
