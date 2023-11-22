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
            radius = 10;
            ResetFireBall();
        }

        public void Draw()
        {
            Raylib.DrawCircleV(position, radius, Color.RED);
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

        public bool BallIsPastLeftEdge()
        {
            float leftEdge = 0;
            bool hasPastLeft = position.X < leftEdge;
            return hasPastLeft;
        }

        public bool BallIsPastRightEdge()
        {
            float rightEdge = Raylib.GetScreenWidth();
            bool hasPastRight = position.X > rightEdge;
            return hasPastRight;
        }

        public void ResetFireBall()
        {
            position.X = 400;
            position.Y = 300;
            Random direction = new Random();
            speed.X = direction.Next(-200, 200);
            speed.Y = direction.Next(-200, 200);

            if (MathF.Abs(speed.X) < 200)
            {
                if (MathF.Sign(speed.X) > 0) 
                {
                    speed.X = 200;
                }
                else
                {
                    speed.X = -200;
                }
            }

        }

        public void TheSoundOfFireBall()
        {

        }
    }
}
