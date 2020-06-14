
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SampleWorld.engine.components;
using SampleWorld.engine.components.animations;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.game.scripts
{
    class MoveAnimationScript : LocalComponent
    {
        bool up;
        bool down;
        bool left;
        bool right;

        public MoveAnimationScript(GameObject gameObject) : base(gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {
            AnimationControllerComponent animationController = Parent.GetComponent<AnimationControllerComponent>();
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                up = true;
                animationController.PlayAnimation("moveUp");
            }
            else
            {
                up = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                right = true;
                animationController.PlayAnimation("moveRight");
            }
            else
            {
                right = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                left = true;
                animationController.PlayAnimation("moveLeft");
            }
            else
            {
                left = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                down = true;
                animationController.PlayAnimation("moveDown");
            }
            else
            {
                down = false;
            }
        }
    }
}
