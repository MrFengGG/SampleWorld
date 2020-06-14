using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.components;
using SampleWorld.engine.components.animations;
using SampleWorld.engine.components.camera;
using SampleWorld.engine.components.physic;
using SampleWorld.engine.gameObjects;
using SampleWorld.engine.respurces;
using SampleWorld.game.scripts;

namespace SampleWorld.game.objeccts
{
    class TestGameObject : GameObject
    {
        public TestGameObject(GameObjectManager manager, GameObject parent) : base(manager, parent)
        {
            manager.AddObject(this);
            Texture2D multiTexture = ResourceLoader.LoadTexture2D(manager.GraphicsDevice, "character", "Content/character.png");
            Animation moveDownAnimation = new Animation(manager.SpriteBatch,new AnimationFrame(multiTexture, new Rectangle(0, 0, 16, 16)));
            moveDownAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(16, 0, 16, 16)));
            moveDownAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(0, 0, 16, 16)));
            moveDownAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(32, 0, 16, 16)));

            Animation moveUpAnimation = new Animation(manager.SpriteBatch, new AnimationFrame(multiTexture, new Rectangle(144, 0, 16, 16)));
            moveUpAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(160, 0, 16, 16)));
            moveUpAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(144, 0, 16, 16)));
            moveUpAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(176, 0, 16, 16)));

            Animation moveLeftAnimation = new Animation(manager.SpriteBatch, new AnimationFrame(multiTexture, new Rectangle(48, 0, 16, 16)));
            moveLeftAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(48, 0, 16, 16)));
            moveLeftAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(64, 0, 16, 16)));
            moveLeftAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(48, 0, 16, 16)));
            moveLeftAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(80, 0, 16, 16)));

            Animation moveRightAnimation = new Animation(manager.SpriteBatch, new AnimationFrame(multiTexture, new Rectangle(96, 0, 16, 16)));
            moveRightAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(112, 0, 16, 16)));
            moveRightAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(96, 0, 16, 16)));
            moveRightAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(128, 0, 16, 16)));

            Animation stopDownAnimation = new Animation(manager.SpriteBatch, new AnimationFrame(multiTexture, new Rectangle(0, 0, 16, 16)));
            Animation stopUpAnimation = new Animation(manager.SpriteBatch, new AnimationFrame(multiTexture, new Rectangle(144, 0, 16, 16)));
            Animation stopLeftAnimation = new Animation(manager.SpriteBatch, new AnimationFrame(multiTexture, new Rectangle(48, 0, 16, 16)));
            Animation stopRightAnimation = new Animation(manager.SpriteBatch, new AnimationFrame(multiTexture, new Rectangle(96, 0, 16, 16)));
            AnimationControllerComponent animationController = new AnimationControllerComponent(this, manager.GraphicsDevice, manager.SpriteBatch, "moveUp", moveUpAnimation);
            animationController.AddAnimation("moveDown", moveDownAnimation);
            animationController.AddAnimation("moveLeft", moveLeftAnimation);
            animationController.AddAnimation("moveRight", moveRightAnimation);
            animationController.AddAnimation("stopDown", stopDownAnimation);
            animationController.AddAnimation("stopUp", stopUpAnimation);
            animationController.AddAnimation("stopLeft", stopLeftAnimation);
            animationController.AddAnimation("stopRight", stopRightAnimation);
            animationController.PlayAnimation("moveLeft");

            MoveScript moveSceipt = new MoveScript(this);

            MoveAnimationScript moveAnimationScript = new MoveAnimationScript(this);

            ColliderComponent collider = new ColliderComponent(this, new Vector2(0, 0), new Vector2(16, 16));
            collider.Collider.IsRigid = true;

            WeaponScript weaponScript = new WeaponScript(this);
        }
    }
}
