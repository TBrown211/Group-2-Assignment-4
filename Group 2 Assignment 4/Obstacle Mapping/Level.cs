using Raylib_cs;
using System.Numerics;

namespace Obstacle_Mapping
{
    internal class Level
    {
        static public Obstacle[] obstacles;
        static int obstacleWidth = 50;
        static int obstacleHeight = 50;
        static float obstacleSpeedX = 100;
        static float obstacleSpeedY = 100;

        static string title = "Game Title";

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
            Lvl3();
            


        }

        static void Update()
        {
            for (int j = 0; j < obstacles.Length; j++)
            {
                obstacles[j].DrawObstacle();

            }



        }

        static public void Lvl1()
        {
            int obsRows = 4;
            int obsCols = 1;
            obstacles = new Obstacle[obsRows * obsCols];
            for (int i = 0; i < obstacles.Length; i++)
            {                
                int verticalIndex = i / obsCols;
                int obstaclePositionX = 400;
                int obstaclePositionY = 50 + (150 * verticalIndex);
                obstacles[i] = new Obstacle(new Vector2(obstaclePositionX, obstaclePositionY), new Vector2(obstacleWidth, obstacleHeight), Color.RED);               

            }
            
        }

        static public void Lvl2()
        {
            int obsRows = 2;
            int obsCols = 2;
            obstacles = new Obstacle[obsRows * obsCols];

            for (int i = 0; i < obstacles.Length; i++)
            {
                int horizontalIndex = i % obsCols;
                int verticalIndex = i / obsCols;
                int obstaclePositionX = 300 + (150 * horizontalIndex);
                int obstaclePositionY = 50 + (400 * verticalIndex);
                obstacles[i] = new Obstacle(new Vector2(obstaclePositionX, obstaclePositionY), new Vector2(obstacleWidth, obstacleHeight), Color.VIOLET);
            }

        }

        static public void Lvl3()
        {
            Vector2 startPosition = new Vector2(350, 350);
            obstacleSpeedX = startPosition.X * obstacleSpeedX + Raylib.GetFrameTime();
            obstacleSpeedY = startPosition.Y * obstacleSpeedY + Raylib.GetFrameTime();
            obstacles = new Obstacle[1];
            bool objectMoveUp = startPosition.X <= 500;
            bool objectMoveLeft = startPosition.Y >= 150;
            bool objectMoveDown = startPosition.X >= 250;
            bool objectMoveRight = startPosition.Y <= 350;
            
            for(int i = 0;i < obstacles.Length; i++)
            {
                float obstacleMovX = startPosition.X + obstacleSpeedX;
                float obstacleMovY = startPosition.Y;
                obstacles[i] = new Obstacle(new Vector2(obstacleMovX, obstacleMovY), new Vector2(obstacleWidth, obstacleHeight), Color.GOLD);
                if (objectMoveUp)
                {
                    obstacleMovX = startPosition.X;
                    obstacleMovY = startPosition.Y - obstacleSpeedY;

                }
                else if (objectMoveLeft)
                {
                    obstacleMovX = startPosition.X - obstacleSpeedX;
                    obstacleMovX = startPosition.Y;
                }
                else if (objectMoveDown)
                {
                    obstacleMovX = startPosition.X;
                    obstacleMovX = startPosition.Y + obstacleSpeedY;
                }
                else if(objectMoveRight)
                {
                    obstacleMovX = startPosition.X + obstacleSpeedX;
                    obstacleMovX = startPosition.Y;
                }
                else
                {

                }
            }

        }
    }
}
