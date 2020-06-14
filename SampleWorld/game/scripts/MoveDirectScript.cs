
using Microsoft.Xna.Framework;
using SampleWorld.engine.components;
using SampleWorld.engine.gameObjects;

namespace SampleWorld.game.scripts
{
    class MoveDirectScript : LocalComponent
    {
        public float Speed{ get; set;}
        public Vector2 Direction { get; set; }
        private float liveSeconds = 0;
        private float aliveSeconds = 10;

        public MoveDirectScript(GameObject gameObject, float speed, Vector2 direction, float liveSeconds) : base(gameObject)
        {
            Speed = speed;
            Direction = direction;
            aliveSeconds = liveSeconds;
        }

        public override void Update(GameTime gameTime)
        {
            float second = (float)gameTime.ElapsedGameTime.TotalSeconds;
            liveSeconds += second;
            if(aliveSeconds > 0 && liveSeconds > aliveSeconds)
            {
                Parent.Destory();
            }
            Parent.Position = new Vector2(Direction.X * Speed * second, Direction.Y * Speed * second);

        }
    }
}
