
using Microsoft.Xna.Framework;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.engine.components
{
    abstract class LocalComponent : ILocalComponent
    {
        private bool isActive;

        private IGameObject parent;

        public void Active()
        {
            isActive = true;
        }

        public IGameObject GetParent()
        {
            return parent;
        }

        public bool IsActive()
        {
            return isActive;
        }

        public void Passive()
        {
            isActive = false;
        }

        public abstract void Update(GameTime gameTime);
    }
}
