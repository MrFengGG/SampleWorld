using Microsoft.Xna.Framework;

namespace SampleWorld.engine.components.physic
{
    class SampleCollider : Collider
    {
        public Rectangle Rectangle;

        public SampleCollider(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

        public override bool Detection(Collider other)
        {
            if(other is SampleCollider)
            {
                return Rectangle.Intersects((other as SampleCollider).Rectangle);
            }
            return false;
        }

        public override bool Detection(Collider other, ref Vector2 moveDelta)
        {
            if (other is SampleCollider)
            {
                Rectangle otherRectangle = (other as SampleCollider).Rectangle;
                bool isIntersect = false;
                if ((moveDelta.X > 0 && this.IsTouchingLeft(otherRectangle, moveDelta)) ||
                    (moveDelta.X < 0 && this.IsTouchingRight(otherRectangle, moveDelta)))
                {
                    isIntersect = true;
                    if (IsRigid)
                    {
                        moveDelta.X = 0;
                    }
                }

                if ((moveDelta.Y > 0 && this.IsTouchingTop(otherRectangle, moveDelta)) ||
                    (moveDelta.Y < 0 && this.IsTouchingBottom(otherRectangle, moveDelta)))
                {
                    isIntersect = true;
                    if (IsRigid)
                    {
                        moveDelta.Y = 0;
                    }
                }
                return isIntersect;
            }
            return false;
        }

        public override void UpdatePosition(Vector2 position)
        {
            Rectangle.Location = new Point((int)position.X, (int)position.Y);
            //Rectangle.Offset(new Point((int)position.X, (int)position.Y));
        }

        private bool IsTouchingLeft(Rectangle other, Vector2 velocity)
        {
            return this.Rectangle.Right + velocity.X > other.Left &&
              this.Rectangle.Left < other.Left &&
              this.Rectangle.Bottom > other.Top &&
              this.Rectangle.Top < other.Bottom;
        }

        private bool IsTouchingRight(Rectangle other, Vector2 velocity)
        {
            return this.Rectangle.Left + velocity.X < other.Right &&
              this.Rectangle.Right > other.Right &&
              this.Rectangle.Bottom > other.Top &&
              this.Rectangle.Top < other.Bottom;
        }

        private bool IsTouchingTop(Rectangle other, Vector2 velocity)
        {
            return this.Rectangle.Bottom + velocity.Y > other.Top &&
              this.Rectangle.Top < other.Top &&
              this.Rectangle.Right > other.Left &&
              this.Rectangle.Left < other.Right;
        }

        private bool IsTouchingBottom(Rectangle other, Vector2 velocity)
        {
            return this.Rectangle.Top + velocity.Y <other.Bottom &&
              this.Rectangle.Bottom > other.Bottom &&
              this.Rectangle.Right > other.Left &&
              this.Rectangle.Left < other.Right;
        }
    }
}
