using Microsoft.Xna.Framework;
using SampleWorld.engine.components.scripts;
using SampleWorld.engine.events;
using SampleWorld.engine.gameObjects;
using System.Collections.Generic;

namespace SampleWorld.engine.components.physic
{
    public class ColliderComponent : LocalComponent
    {
        public Vector2 Position { get; set; }

        public Collider Collider { get; }

        public float Level { get; }

        public ColliderComponent(GameObject gameObject, Vector2 position, Vector2 scale) : base(gameObject)
        {
            Position = position;
            Vector2 targetPosition = new Vector2(Parent.Position.X + Position.X, Parent.Position.Y + Position.Y);
            Collider = new SampleCollider(new Rectangle((int)targetPosition.X, (int)targetPosition.Y, (int)(targetPosition.X + scale.X), (int)(targetPosition.Y + scale.Y)));
            Level = 1;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 position = new Vector2(Parent.Position.X + Position.X, Parent.Position.Y + Position.Y);
            Collider.UpdatePosition(position);
        }

        public override void OnEvent(EventArgs eventArgs)
        {
            List<ScriptComponent> scripts = Parent.GetComponentList<ScriptComponent>();
            foreach(ScriptComponent script in scripts)
            {
                script.OnEvent(eventArgs);
            }
        }
    }
}
