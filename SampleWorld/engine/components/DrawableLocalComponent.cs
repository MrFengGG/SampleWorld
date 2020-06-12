
using Microsoft.Xna.Framework;

namespace SampleWorld.engine.components
{
    abstract class DrawableLocalComponent : LocalComponent
    {
        public abstract void Draw(GameTime gameTime);
    }
}
