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
        static Random rng = new Random();
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
                Raylib.ClearBackground(Color.BLACK);

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
            Lvl1();   

        }

        static void Update()
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].DrawObstacle();
            }
           
        }




        static public void Lvl1()
        {
            //Initializing the first level 
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

        public void Lvl2()
        {
            int obsRows = 2;
            int obsCols = 2;
            obstacles = new Obstacle[obsRows * obsCols];

            for (int i = 0; i < obstacles.Length; i++)
            {
                int horizontalIndex = i % obsCols;
                int verticalIndex = i / obsCols;
                int obstaclePositionX = 250 + (250 * horizontalIndex);
                int obstaclePositionY = 100 + (300 * verticalIndex);
                obstacles[i] = new Obstacle(new Vector2(obstaclePositionX, obstaclePositionY), new Vector2(obstacleWidth, obstacleHeight), Color.VIOLET);
            }

        }

        public void Lvl3()
        {
            //
            float time = (float)Raylib.GetTime();
            float secondPerCycle = time / 5;
            float cycle = secondPerCycle * MathF.Tau;

            //Positioning of our wave
            float waveStartY = 0f;
            float waveOffset = MathF.Cos(cycle) * 600;
            float obstaclePositionY = waveStartY + waveOffset;
            
            obstacles = new Obstacle[2];
            
            
            for(int i = 0;i < obstacles.Length; i++)
            {
                int horizontalIndex = i;
                float obstaclePositionX = 250 + (250 * horizontalIndex);
                 obstacles[i] = new Obstacle(new Vector2(obstaclePositionX, obstaclePositionY), new Vector2(obstacleWidth, obstacleHeight), Color.GOLD);
                
            }

        }
    }
}
