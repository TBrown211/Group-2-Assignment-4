using Raylib_cs;
using System.Numerics;

namespace Group_2_Assignment_4
{
    public class Paddles
    {
        Vector2 paddlePosition;
        Vector2 paddleSize;
        float speed;
        KeyboardKey upArrow;
        KeyboardKey downArrow;


        public Paddles(float paddlePositionX, KeyboardKey upArrow, KeyboardKey downArrow)
        {
            paddlePosition.X = paddlePositionX;
            paddlePosition.Y = Raylib.GetScreenHeight() / 2;
            paddleSize.X = 5;
            paddleSize.Y = 100;

            speed = 300;

            this.upArrow = upArrow;
            this.downArrow = downArrow;
        }

        public void DrawPaddles()
        {
            Raylib.DrawRectangleV(paddlePosition, paddleSize, Color.BLUE);
        }

        public void Move()
        {
            float movementY = 0;

            if (Raylib.IsKeyDown(upArrow))
            {
                movementY -= speed;
            }

            if (Raylib.IsKeyDown(downArrow))
            {
                movementY += speed;
            }

            paddlePosition.Y += movementY * Raylib.GetFrameTime();

            if (paddlePosition.Y < 0)
            {
                paddlePosition.Y = 0;
            }
            else if (paddlePosition.Y > Raylib.GetScreenHeight() - paddleSize.Y)
            {
                paddlePosition.Y = Raylib.GetScreenHeight() - paddleSize.Y;
            }


        }

        public void MovePaddles()
        {
            float movementY = 0;

            if (Raylib.IsKeyDown(upArrow))
            {
                movementY -= speed;
            }

            if (Raylib.IsKeyDown(downArrow))
            {
                movementY += speed;
            }

            paddlePosition.Y += movementY * Raylib.GetFrameTime();

            if (paddlePosition.Y < 0)
            {
                paddlePosition.Y = 0;
            }
            else if (paddlePosition.Y > Raylib.GetScreenHeight() - paddleSize.Y)
            {
                paddlePosition.Y = Raylib.GetScreenHeight() - paddleSize.Y;
            }

        }

    }
}
