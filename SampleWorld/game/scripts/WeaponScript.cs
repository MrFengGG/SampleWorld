﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SampleWorld.engine.components;
using SampleWorld.engine.components.scripts;
using SampleWorld.engine.gameObjects;
using SampleWorld.engine.managers;
using SampleWorld.game.objeccts.weapons;
using System;

namespace SampleWorld.game.scripts
{
    class WeaponScript : ScriptComponent
    {
        bool okToShoot = true;

        float shootDistance = 0.2f;

        float shootSpend = 0.2f;

        public WeaponScript(GameObject gameObject) : base(gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            shootSpend += time;
            if(shootSpend >= shootDistance)
            {
                MouseState state = Mouse.GetState();
                Vector2 targetPosition = InputContext.GetMousePosition();
                Vector2 direction = targetPosition - Parent.Position;
                float rotation = CalculateAngleBetweenPoints(Parent.Position.ToPoint(), targetPosition.ToPoint());
                direction.Normalize();
                if (state.LeftButton == ButtonState.Pressed)
                {
                    Bullet bullet = new Bullet(Parent.World, null, direction, Parent.Position, rotation);
                }

                shootSpend = 0;
            }
        }

        private static float CalculateAngleBetweenPoints(Point p1, Point p2)
        {
            // get the difference x and y from the points
            float deltaX = p2.X - p1.X;
            float deltaY = p2.Y - p1.Y;
            // calculate the angle
            float res = (float)(Math.Atan2(deltaY, deltaX));
            return res;
        }
    }
}
