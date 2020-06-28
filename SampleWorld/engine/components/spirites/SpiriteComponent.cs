using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.gameObjects;
using SampleWorld.engine.support;

namespace SampleWorld.engine.components.spirites
{
    public class SpiriteComponent : DrawableLocalComponent
    {
        public Texture2D Texture { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public Color TextureColor { get; set; }

        public float Depth { get; set; }

        public Vector2 Origin { get; set; }

        public Vector2 Position { get; set; }

        public SpiriteComponent(Texture2D texture, GameObject gameObject) : base(gameObject)
        {
            Texture = texture;
            TextureColor = Color.White;
            Depth = gameObject.Depth;
            Origin = new Vector2(1, 1);
            SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public SpiriteComponent(Texture2D texture, GameObject gameObject, Rectangle rectangle) : this(texture, gameObject)
        {
            SourceRectangle = rectangle;
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(Texture, Parent.Position + Position, SourceRectangle, TextureColor,
                Parent.Rotation, Origin, Parent.Scale, SpriteEffects.None, Depth);
        }
    }
}
