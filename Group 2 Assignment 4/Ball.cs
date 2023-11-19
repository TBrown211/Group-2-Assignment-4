using Raylib_cs;
using System.Numerics;

namespace Group_2_Assignment_4
{
    internal class Ball
    {
        Vector2 position;
        Vector2 speed;
        float radius;
        public Ball() 
        {
            position.X = 400;
            position.Y = 300;
            radius = 10;
            speed.X = 100;
            speed.Y = 100;
        }

        public void Draw()
        {
            Raylib.DrawCircleV(position, radius, Color.BLACK);
        }

        public void MoveBall()
        {
            position = position + speed * Raylib.GetFrameTime();
        }

        public void CollideBall()
        {
            float topOfScreen = 0;
            float bottomOfScreen = Raylib.GetScreenHeight();

            bool ballHitsTop = position.Y <= topOfScreen + radius;
            bool ballHitsBottom = position.Y >= bottomOfScreen - radius;

            if (ballHitsTop || ballHitsBottom)
            {
                speed.Y = -speed.Y;
            }
        }
    }
}
