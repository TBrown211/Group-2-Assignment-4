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
        Texture2D leftShield = LoadTexture2D("leftshield.png");
        Texture2D rightShield = LoadTexture2D("rightshield.png");
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

        public void DrawPaddleLeft()
        {
            Raylib.DrawTextureV(leftShield, paddlePosition, Color.WHITE);
        }

        public void DrawPaddleRight()
        {
            Raylib.DrawTextureV(rightShield, paddlePosition, Color.WHITE);
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

            // Makes sure the paddles stay on the screen

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

        // Checks if a paddle has hit the ball yet, if it does bool hasHit is true
        // hasHit can be used to change the direction of the ball.
        public void HitBall(FakeBall ball)
        {
            Vector2 ballPosition = ball.GetPosition();
            float ballRadius = ball.GetRadius();

            float ballLeftEdge = ballPosition.X - ballRadius;
            float ballRightEdge = ballPosition.X + ballRadius;
            float ballTopEdge = ballPosition.Y - ballRadius;
            float ballBottomEdge = ballPosition.Y + ballRadius;

            float paddleLeftEdge = paddlePosition.X;
            float paddleRightEdge = paddlePosition.X + paddleSize.X;
            float paddleTopEdge = paddlePosition.Y;
            float paddleBottomEdge = paddlePosition.Y + paddleSize.Y;

            bool hitRightEdge = ballLeftEdge <= paddleRightEdge;
            bool hitLeftEdge = ballRightEdge >= paddleLeftEdge;
            bool hitTopEdge = ballBottomEdge >= paddleTopEdge;
            bool hitBottomEdge = ballTopEdge <= paddleBottomEdge;

            bool hasHit = hitRightEdge && hitLeftEdge && hitTopEdge && hitBottomEdge;
        }

        static Texture2D LoadTexture2D(string fileName)
        {
            Image image = Raylib.LoadImage($"../../../../resources/textures/{fileName}");
            Texture2D texture = Raylib.LoadTextureFromImage(image);
            return texture;
        }

    }
}
