
using Microsoft.Xna.Framework;
using SampleWorld.engine.gameObjects;
using System.Collections.Generic;

namespace SampleWorld.engine.components.animations
{
    class AnimationControllerComponent : DrawableLocalComponent
    {
        Dictionary<string, Animation> animationMap = new Dictionary<string, Animation>();

        private Animation currentAnimation;

        public AnimationControllerComponent(GameObject gameObject, string name, Animation animation) : base(gameObject)
        {
            animationMap[name] = animation;
            currentAnimation = animation;
        }

        //增加动画
        public AnimationControllerComponent AddAnimation(string name, Animation animation)
        {
            animationMap[name] = animation;
            return this;
        }

        public override void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            currentAnimation.Draw(gameTime, Parent.Position, Parent.Scale, Parent.Rotation);
        }

        //播放对应动画
        public AnimationControllerComponent PlayAnimation(string name)
        {
            if (animationMap.ContainsKey(name))
            {
                currentAnimation = animationMap[name];
            }
            return this;
        }
    }
}
