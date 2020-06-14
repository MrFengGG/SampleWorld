
using Microsoft.Xna.Framework;

namespace SampleWorld.engine.components.physic
{
    public abstract class Collider
    {
        public bool IsRigid { get; set; }

        public abstract bool Detection(Collider other);

        public abstract bool Detection(Collider other, ref Vector2 moveDelta);

        public abstract void UpdatePosition(Vector2 position);
   
    }
}
