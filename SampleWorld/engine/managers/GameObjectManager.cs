using Microsoft.Xna.Framework;
using SampleWorld.engine.gameObjects;
using System.Collections.Generic;

namespace SampleWorld.engine.components
{
    class GameObjectManager : DrawableGameComponent
    {
        List<ILocalComponent> components = new List<ILocalComponent>();

        List<IGameObject> roots = new List<IGameObject>();

        public GameObjectManager(Game game) : base(game)
        {
            game.Components.Add(this);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach(ILocalComponent component in components)
            {
                DrawableLocalComponent drawableComponent = component as DrawableLocalComponent;
                if(drawableComponent != null)
                {
                    drawableComponent.Draw(gameTime);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (ILocalComponent component in components)
            {
                component.Update(gameTime);
            }
        }

        public void AddComponent(ILocalComponent localComponent)
        {
            components.Add(localComponent);
        }

        public void RemoveComponent(ILocalComponent localComponent)
        {
            components.Remove(localComponent);
        }

        public void RemoveObject(IGameObject gameObject)
        {
            roots.Remove(gameObject);
        }
    }
}
