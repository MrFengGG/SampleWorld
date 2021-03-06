﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.engine.components.camera
{
    public class Camera
    {
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }
        public Vector2 ScreenCenter { get; protected set; }
        public Matrix Transform { get; set; }
        public float Speed { get; set; }

        public GameObject Follow { get; set; }

        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        protected float viewportHeight;

        protected float viewportWidth;

        public Camera(GameObject follow, GraphicsDevice graphicsDevice)
        {
            Follow = follow;
            viewportWidth = graphicsDevice.Viewport.Width;
            viewportHeight = graphicsDevice.Viewport.Height;
            ScreenCenter = new Vector2(viewportWidth / 2, viewportHeight / 2);
            Scale = 1;
            Speed = 1.25f;
        }

        public void Update(GameTime gameTime)
        {
            Transform = Matrix.Identity *
                        Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                        Matrix.CreateRotationZ(Rotation) *
                        Matrix.CreateTranslation(Origin.X, Origin.Y, 0) *
                        Matrix.CreateScale(new Vector3(Scale, Scale, Scale));

            Origin = ScreenCenter / Scale;

            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X += (Follow.Position.X - Position.X) * Speed * delta;
            position.Y += (Follow.Position.Y - Position.Y) * Speed * delta;
        }

    }
}
