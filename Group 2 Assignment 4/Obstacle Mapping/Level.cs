﻿using Raylib_cs;
using System.Numerics;

namespace Obstacle_Mapping
{
    internal class Level
    {
        static public Obstacle[] obstacles;
        static int obstacleWidth = 50;
        static int obstacleHeight = 50;
        static Vector2 obstaclePosition;        
        static Random rng = new Random();        
        static Texture2D level;        
        
        public Level()
        {
             
        }

        
        static void LevelSetup()
        {
            Lvl3();

        }

        static void LevelUpdate()
        {
            Raylib.DrawTexture(level, 0, 0, Color.WHITE);

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
            level = BackgroundTextures("battleback10.png");
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
            level = BackgroundTextures("battleback9.png");
            int obsRows = 2;
            int obsCols = 2;
            obstacles = new Obstacle[obsRows * obsCols];

            for (int i = 0; i < obstacles.Length; i++)
            {
                int horizontalIndex = i % obsCols;
                int verticalIndex = i / obsCols;
                obstaclePosition.X = 250 + (250 * horizontalIndex);
                obstaclePosition.Y = 100 + (300 * verticalIndex);
                obstacles[i] = new Obstacle(new Vector2(obstaclePosition.X, obstaclePosition.Y), new Vector2(obstacleWidth, obstacleHeight), Color.VIOLET);
            }

        }

        static public void Lvl3()
        {
            
            obstacles = new Obstacle[2];
            
            
            for(int i = 0;i < obstacles.Length; i++)
            {             
                int horizontalIndex = i;
                float obstaclePositionX = 250 + (250 * horizontalIndex);
                float obstaclePositionY = 50;                
                 obstacles[i] = new Obstacle(new Vector2(obstaclePositionX, obstaclePositionY), new Vector2(obstacleWidth, obstacleHeight), Color.GOLD);
               
            }

        }

        static public Texture2D BackgroundTextures(string filename)
        {            
            //Loading textures for level background
            Image levelBackground = Raylib.LoadImage($"../../../../../BG 2.0/BG/{filename}");
            Texture2D mapTexture = Raylib.LoadTextureFromImage(levelBackground);

            return mapTexture;
        }
    }
}
