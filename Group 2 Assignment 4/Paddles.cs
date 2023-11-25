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


        public Paddles(float paddlePositionX)
        {
            paddlePosition.X = paddlePositionX;
            paddlePosition.Y = Raylib.GetScreenHeight() / 2;
            paddleSize.X = 5;
            paddleSize.Y = 100;

            speed = 300;


        }

        public void DrawPaddles()
        {
            Raylib.DrawRectangleV(paddlePosition, paddleSize, Color.BLUE);
        }


    }
}
