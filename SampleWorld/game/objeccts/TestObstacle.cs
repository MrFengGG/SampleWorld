using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.components;
using SampleWorld.engine.components.physic;
using SampleWorld.engine.components.spirites;
using SampleWorld.engine.gameObjects;
using SampleWorld.engine.respurces;

namespace SampleWorld.game.objeccts
{
    class TestObstacle : GameObject
    {
        public TestObstacle(GameObjectManager manager, GameObject parent) : base(manager, parent)
        {
            Texture2D multiTexture = ResourceLoader.LoadTexture2D(manager.GraphicsDevice, "character", "Content/character.png");
            SpiriteComponent spirite = new SpiriteComponent(multiTexture, this, new Rectangle(112, 0, 16, 16));

            ColliderComponent collider = new ColliderComponent(this, new Vector2(0, 0), new Vector2(16, 16));

            collider.Collider.IsRigid = true;
        }
    }
}
