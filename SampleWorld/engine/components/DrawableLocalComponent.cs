
using Microsoft.Xna.Framework;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.engine.components
{
    public abstract class DrawableLocalComponent : LocalComponent
    {
        public DrawableLocalComponent(IGameObject gameObject) : base(gameObject){}

        public abstract void Draw(GameTime gameTime);
    }
}
