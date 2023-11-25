using Raylib_cs;
using System.Numerics;

namespace Group_2_Assignment_4
{
    internal class Program
    {
        // If you need variables in the Program class (outside functions), you must mark them as static
        static string title = "Game Title";
        static Paddles paddleLeft;
        static Paddles paddleRight;
        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(800, 600, title);
            // Set the target frames-per-second (FPS)
            Raylib.SetTargetFPS(60);

            // Setup your game. This is a function YOU define.
            Setup();

            // Loop so long as window should not close
            while (!Raylib.WindowShouldClose())
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.WHITE);

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
            paddleLeft = new Paddles(25);
            paddleRight = new Paddles(Raylib.GetScreenWidth() - 45);
        }

        static void Update()
        {
            paddleLeft.DrawPaddles();
            paddleRight.DrawPaddles();

        }
    }
}