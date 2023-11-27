
using Raylib_cs;
using System.Numerics;

namespace Group_2_Assignment_4
{
    internal class Program
    {
        // If you need variables in the Program class (outside functions), you must mark them as static

        //Obstacle Constants
        static public Obstacle[] obstacles;        

        static int obstaclePositionX;
        static int obstaclePositionY;
        static Random rng = new Random();
        static Texture2D level;
        static Texture2D mob;        
        
        
        


        static string title = "Medievil Pong";
        static Ball ball;
        static int leftPlayerScore = 0;
        static int rightPlayerScore = 0;
        static Paddles paddleLeft;
        static Paddles paddleRight;


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

            LevelSetup();
            

            ball = new Ball();
            ball.LoadFireballTexture();
            ball.LoadFireBallSound();
            paddleLeft = new Paddles(25, KeyboardKey.KEY_W,KeyboardKey.KEY_S);
            paddleRight = new Paddles(Raylib.GetScreenWidth() - 45, KeyboardKey.KEY_UP,KeyboardKey.KEY_DOWN);


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


            paddleLeft.DrawPaddleLeft();
            paddleRight.DrawPaddleRight();
            paddleLeft.MovePaddles();
            paddleRight.MovePaddles();
            
            Raylib.DrawTexture(level, 0, 0, Color.WHITE);
            StationaryLevelUpdate();
            


        }

        //Setup code for the levels
        static public void LevelSetup()
        {
            Lvl1();

        }

        //Update code for the each level 
        static public void StationaryLevelUpdate() //Code for levels with no movement to the obstacles (levels 1, 2)
        {          
            for (int i = 0; i < obstacles.Length; i++)
            {
                
                obstacles[i].DrawMobImage();
                obstacles[i].MobPosition();
                obstacles[i].BallCollisionCheck();
            }
        }

        static public void MovementLevelUpdate() //Code for levels with movement (level 3)
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].DrawMobImage();
                obstacles[i].MoveObstacle();
                obstacles[i].ObstacleScreenBoundaries();
                obstacles[i].BallCollisionCheck();
                
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
                obstaclePositionX = 400;
                obstaclePositionY = 50 + (150 * verticalIndex);
                obstacles[i] = new Obstacle(mob, new Vector2(obstaclePositionX, obstaclePositionY), 0, 1.3f, Color.WHITE);

            }

        }

        static public void Lvl2()
        {
            //Initializing the second level
            level = LevelTextures("battleback9.png");
            mob = LevelTextures("Mobs_03.png");
            int obsRows = 2;
            int obsCols = 2;
            obstacles = new Obstacle[obsRows * obsCols];

            for (int i = 0; i < obstacles.Length; i++)
            {
                int horizontalIndex = i % obsCols;
                int verticalIndex = i / obsCols;
                obstaclePositionX = 250 + (250 * horizontalIndex);
                obstaclePositionY = 100 + (350 * verticalIndex);

                obstacles[i] = new Obstacle(mob, new Vector2(obstaclePositionX, obstaclePositionY), 0, 1.3f, Color.WHITE);
            }

        }

        static public void Lvl3()
        {
            //Initializing the third level
            level = LevelTextures("battleback8.png");
            mob = LevelTextures("Mobs_05.png");
            obstacles = new Obstacle[2];


            for (int i = 0; i < obstacles.Length; i++)
            {
                int horizontalIndex = i;
                obstaclePositionX = 250 + (250 * horizontalIndex);
                obstaclePositionY = 50;
                obstacles[i] = new Obstacle(mob, new Vector2(obstaclePositionX, obstaclePositionY), 0, 1.3f, Color.WHITE);

            }

        }

        static public Texture2D LevelTextures(string filename)
        {
            //Loading textures for level background and mob obstacles
            Image levelBackground = Raylib.LoadImage($"../../../BG 2.0/BG/{filename}");
            Texture2D mapTexture = Raylib.LoadTextureFromImage(levelBackground);

            return mapTexture;
        }

    }
}