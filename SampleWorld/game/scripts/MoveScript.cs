using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SampleWorld.engine.components;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.game.scripts
{
    class MoveScript : LocalComponent
    {
        public float Speed { get; set; }

        public MoveScript(GameObject gameObject) : base(gameObject)
        {
            Speed = 100;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 position = Parent.Position;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * Speed;
            }
            Parent.Position = position;
        }
    }
}
