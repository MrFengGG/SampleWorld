
using Microsoft.Xna.Framework;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.engine.components
{
    public class LocalComponent : ILocalComponent
    {
        private bool isActive;

        public GameObject Parent { get; }

        public LocalComponent(GameObject gameObject)
        {
            Parent = gameObject;
            gameObject.AddComponent(this);
        }

        public void Active()
        {
            isActive = true;
        }

        public bool IsActive()
        {
            return isActive;
        }

        public void Passive()
        {
            isActive = false;
        }

        public virtual void Update(GameTime gameTime) { }
    }
}
