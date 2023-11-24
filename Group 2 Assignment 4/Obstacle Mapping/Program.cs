using Raylib_cs;
using System.Numerics;
using System.Reflection.Emit;

namespace Obstacle_Mapping
{
    internal class Program
    {
        static public Obstacle[] obstacles;
        static int obstacleWidth = 50;
        static int obstacleHeight = 50;
        static Vector2 obstaclePosition;
        static Random rng = new Random();
        static Texture2D level;
        static Texture2D mob;

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

                Raylib.ClearBackground(Color.BLANK);
                

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


            Raylib.DrawTexture(level, 0, 0, Color.WHITE);
            Raylib.DrawTextureV(mob, obstaclePosition, Color.WHITE);
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].DrawObstacle();
                obstacles[i].MoveObstacle();
                obstacles[i].ObstacleScreenBoundaries();
            }


        }

        static public void Lvl1()
        {
            //Initializing the first level 
            level = LevelTextures("battleback10.png");
            mob = LevelTextures("Mobs_02.png");
            int obsRows = 4;
            int obsCols = 1;
            obstacles = new Obstacle[obsRows * obsCols];
            for (int i = 0; i < obstacles.Length; i++)
            {
                int verticalIndex = i / obsCols;
                obstaclePosition.X = 400;
                obstaclePosition.Y = 50 + (150 * verticalIndex);
                obstacles[i] = new Obstacle(new Vector2(obstaclePosition.X, obstaclePosition.Y), new Vector2(obstacleWidth, obstacleHeight), Color.RED);

            }

        }

        static public void Lvl2()
        {
            level = LevelTextures("battleback9.png");
            int obsRows = 2;
            int obsCols = 2;
            obstacles = new Obstacle[obsRows * obsCols];

            for (int i = 0; i < obstacles.Length; i++)
            {
                int horizontalIndex = i % obsCols;
                int verticalIndex = i / obsCols;
                obstaclePosition.X = 250 + (250 * horizontalIndex);
                obstaclePosition.Y = 100 + (350 * verticalIndex);
                obstacles[i] = new Obstacle(new Vector2(obstaclePosition.X, obstaclePosition.Y), new Vector2(obstacleWidth, obstacleHeight), Color.VIOLET);
            }

        }

        static public void Lvl3()
        {
            level = LevelTextures("battleback8.png");
            mob = LevelTextures("Mobs_02.png");
            obstacles = new Obstacle[2];


            for (int i = 0; i < obstacles.Length; i++)
            {
                int horizontalIndex = i;
                obstaclePosition.X = 250 + (250 * horizontalIndex);
                obstaclePosition.Y = 50;
                obstacles[i] = new Obstacle(new Vector2(obstaclePosition.X, obstaclePosition.Y), new Vector2(obstacleWidth, obstacleHeight), Color.GOLD);

            }

        }

        static public Texture2D LevelTextures(string filename)
        {
            //Loading textures for level background
            Image levelBackground = Raylib.LoadImage($"../../../../../BG 2.0/BG/{filename}");
            Texture2D mapTexture = Raylib.LoadTextureFromImage(levelBackground);

            return mapTexture;
        }



    }
}