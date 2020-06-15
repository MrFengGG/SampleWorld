
using Microsoft.Xna.Framework;
using SampleWorld.engine.components;
using SampleWorld.engine.gameObjects;
using System;

namespace SampleWorld.game.scripts
{
    class MoveDirectScript : LocalComponent
    {
        public float Speed{ get; set;}
        public Vector2 Direction { get; set; }
        public float Rotation { get; set; }
        private float liveSeconds = 0;
        private float aliveSeconds = 10;

        public MoveDirectScript(GameObject gameObject, float speed, Vector2 direction, float rotation, float liveSeconds) : base(gameObject)
        {
            Speed = speed;
            Direction = direction;
            aliveSeconds = liveSeconds;
            Rotation = rotation;
        }

        public override void Update(GameTime gameTime)
        {
            float second = (float)gameTime.ElapsedGameTime.TotalSeconds;
            liveSeconds += second;
            if(aliveSeconds > 0 && liveSeconds > aliveSeconds)
            {
                Parent.Destory();
            }
            Parent.Position = Parent.Position + Speed * second * Direction;
            Parent.Rotation = Rotation;
        }
    }
}
