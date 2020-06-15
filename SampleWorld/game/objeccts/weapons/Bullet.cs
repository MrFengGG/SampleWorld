using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.components;
using SampleWorld.engine.components.spirites;
using SampleWorld.engine.gameObjects;
using SampleWorld.engine.respurces;
using SampleWorld.game.scripts;

namespace SampleWorld.game.objeccts.weapons
{
    class Bullet : GameObject
    {
        public Bullet(GameObjectManager manager, GameObject parent, Vector2 direction) : base(manager, parent)
        {
            MoveDirectScript moveDirectScript = new MoveDirectScript(this, 1, direction, 5);
            Texture2D texture = ResourceLoader.LoadTexture2D(manager.GraphicsDevice, "bullet", "Content/bullet.png");
            SpiriteComponent spirite = new SpiriteComponent(texture, this);
        }
    }
}
