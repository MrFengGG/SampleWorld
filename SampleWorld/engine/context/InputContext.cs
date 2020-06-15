using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SampleWorld.engine.managers
{
    public class InputContext
    {
        public static Matrix CurrentTransform{ get; set; }

        public static Vector2 GetMousePosition()
        {
            MouseState state = Mouse.GetState();
            Vector2 mousePosition = new Vector2(state.X, state.Y);
            return Vector2.Transform(mousePosition, Matrix.Invert(CurrentTransform));
        }
    }
}
