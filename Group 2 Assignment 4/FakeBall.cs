using Raylib_cs;
using System.Numerics;

namespace Group_2_Assignment_4
{

    // Made a fake ball so that paddle code can run without errors,
    // we can replace this fake ball afterward with the real ball code.

    public class FakeBall
    {
        Vector2 position;
        Vector2 speed;
        float radius;
        public FakeBall()
        {

        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public float GetRadius()
        {
            return radius;
        }
    }
}
