using Raylib_cs;
using System.Numerics;

namespace Group_2_Assignment_4
{
    internal class Program
    {
        // If you need variables in the Program class (outside functions), you must mark them as static
        static string title = "Medievil Pong";
        static Ball ball;
        static int leftPlayerScore = 0;
        static int rightPlayerScore = 0;

        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(800, 600, title);
            // Set the target frames-per-second (FPS)
            Raylib.SetTargetFPS(60);
            //Intalize the audio
            Raylib.InitAudioDevice();

            // Setup your game. This is a function YOU define.
            Setup();

            // Loop so long as window should not close
            while (!Raylib.WindowShouldClose())
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.RAYWHITE);

                // Your game code here. This is a function YOU define.
                Update();

                // Stop drawing to the canvas, begin displaying the frame
                Raylib.EndDrawing();
            }
            // Close the window
            Raylib.CloseWindow();
        }

        static void Setup()
        {
            ball = new Ball();
            ball.LoadFireballTexture();
            ball.LoadFireBallSound();
        }

        static void Update()
        {

            ball.MoveBall();
            ball.CollideBall();
            if (ball.BallIsPastRightEdge())
            {
                leftPlayerScore++;
                ball.ResetFireBall();
            }
            if (ball.BallIsPastLeftEdge())
            {
                rightPlayerScore++;
                ball.ResetFireBall();
            }

            Raylib.DrawText(leftPlayerScore.ToString(), 50, 50, 32, Color.BLACK);
            Raylib.DrawText(rightPlayerScore.ToString(), 750, 50, 32, Color.BLACK);

            ball.Draw();
        }

    }
}