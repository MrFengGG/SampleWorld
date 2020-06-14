using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SampleWorld.engine.components;
using SampleWorld.engine.gameObjects;
using SampleWorld.game.objeccts.weapons;

namespace SampleWorld.game.scripts
{
    class WeaponScript : LocalComponent
    {
        public WeaponScript(GameObject gameObject) : base(gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();
            Vector2 direction = new Vector2(state.X - Parent.Position.X, state.Y - Parent.Position.Y);
            if (state.LeftButton == ButtonState.Pressed) {
                Bullet bullet = new Bullet(Parent.ObjectManager, Parent, direction);
                Parent.ObjectManager.AddObject(bullet);
            }
        }
    }
}
