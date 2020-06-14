using Microsoft.Xna.Framework;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.engine.components.physic
{
    public class ColliderComponent : LocalComponent
    {
        public Vector2 Position { get; set; }

        public Collider Collider { get; }

        public ColliderComponent(GameObject gameObject, Vector2 position, Vector2 scale) : base(gameObject)
        {
            Position = position;
            Vector2 targetPosition = new Vector2(Parent.Position.X + Position.X, Parent.Position.Y + Position.Y);
            Collider = new SampleCollider(new Rectangle((int)targetPosition.X, (int)targetPosition.Y, (int)(targetPosition.X + scale.X), (int)(targetPosition.Y + scale.Y)));
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 position = new Vector2(Parent.Position.X + Position.X, Parent.Position.Y + Position.Y);
            Collider.UpdatePosition(position);
        }
    }
}
