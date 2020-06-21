using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.components;
using SampleWorld.engine.components.physic;
using SampleWorld.engine.components.spirites;
using SampleWorld.engine.gameObjects;
using SampleWorld.engine.respurces;
using SampleWorld.game.scripts;

namespace SampleWorld.game.objeccts.weapons
{
    class Bullet : GameObject
    {
        public Bullet(World manager, GameObject parent, Vector2 direction, Vector2 position, float rotation) : base(manager, parent)
        {
            MoveDirectScript moveDirectScript = new MoveDirectScript(this, 1000, direction, rotation, 1);
            Texture2D texture = ResourceLoader.LoadTexture2D(manager.GraphicsDevice, "bullet", "Content/bullet.png");
            SpiriteComponent spirite = new SpiriteComponent(texture, this);

            ColliderComponent collider = new ColliderComponent(this, new Vector2(0, 0), new Vector2(16, 16));
            collider.Collider.IsRigid = true;
            Scale = new Vector2(0.1f, 0.1f);
            Position = position;
            Rotation = rotation;
        }
    }
}
