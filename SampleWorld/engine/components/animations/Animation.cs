
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace SampleWorld.engine.components.animations
{
    class Animation
    {

        public Color TextureColor { get; set; }

        public Vector2 Origin { get; set; }

        private SpriteBatch spriteBatch;

        //精灵列表
        List<AnimationFrame> frames = new List<AnimationFrame>();
        //当前动画时间
        TimeSpan timeIntoAnimation;
        //每个精灵显示时间
        TimeSpan frameSpan = TimeSpan.FromSeconds(.25);
        //动画总时间
        TimeSpan Duration
        {
            get
            {
                return TimeSpan.FromSeconds(frameSpan.TotalSeconds * frames.Count);
            }
        }

        //更新每帧显示时间,值越小,动画播放速度越快
        public void UpdateTimeSpan(double value)
        {
            if (value != frameSpan.TotalSeconds)
            {
                frameSpan = value > 0 ? TimeSpan.FromSeconds(value) : frameSpan;
            }
        }
        //新增帧
        public Animation AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            return this;
        }
        public Animation(SpriteBatch spriteBatch, AnimationFrame firstFrame)
        {
            frames.Add(firstFrame);
            TextureColor = Color.White;
            this.spriteBatch = spriteBatch;
        }

        public void Update(GameTime gameTime)
        {
            double secondsIntoAnimation = timeIntoAnimation.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds;

            double remainder = secondsIntoAnimation % Duration.TotalSeconds;

            timeIntoAnimation = TimeSpan.FromSeconds(remainder);
        }

        public void Draw(GameTime gameTime, Vector2 position, Vector2 scale, float rotation, float Depth)
        {
            AnimationFrame currentFrame = getCurrentFrame();
            if (currentFrame != null)
            {
                spriteBatch.Draw(currentFrame.Texture, position, currentFrame.Rectangle, TextureColor,
                    rotation, Origin, scale, SpriteEffects.None, Depth);
            }
        }

        //获取当前精灵
        private AnimationFrame getCurrentFrame()
        {
            AnimationFrame currentFrame = null;
            TimeSpan accumulatedTime = new TimeSpan();
            foreach (var spirite in frames)
            {
                if (accumulatedTime + frameSpan >= timeIntoAnimation)
                {
                    currentFrame = spirite;
                    break;
                }
                else
                {
                    accumulatedTime += frameSpan;
                }
            }
            return currentFrame;
        }
    }
}
