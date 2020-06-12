
using Microsoft.Xna.Framework;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.engine.components
{
    public class LocalComponent : ILocalComponent
    {
        private bool isActive;

        private IGameObject parent;

        public LocalComponent(IGameObject gameObject)
        {
            parent = gameObject;
            gameObject.AddComponent(this);
        }

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

        public void Update(GameTime gameTime) { }
    }
}
