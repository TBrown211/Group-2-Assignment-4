using Raylib_cs;
using System.Numerics;

namespace Obstacle_Mapping
{
    internal class Obstacle
    {
        Vector2 obstaclePos;
        Vector2 obstacleSize;
        Color obstacleColor;
        float obstacleSpeedX = 100;
        float obstacleSpeedY = 100;
        Texture2D mob;
        Random rng = new Random();  

        public Obstacle(Vector2 position, Vector2 size, Color color)
        {
            //Initializing the required inputs for the obstacle
            obstaclePos = position;
            obstacleSize = size;
            obstacleColor = color;
            obstacleSpeedY = obstacleSpeedY * rng.NextSingle();
        }

        public void DrawObstacle()
        {            
            //Draw the obstacle on screen
            Raylib.DrawRectangleV(obstaclePos, obstacleSize, obstacleColor);
        }

        public void MoveObstacle()
        {
            obstaclePos.Y = obstaclePos.Y + obstacleSpeedY * Raylib.GetFrameTime();
        } 

        public void ObstacleScreenBoundaries()
        {
            float topBorder = 0;
            float bottomBorder = Raylib.GetScreenHeight();
            bool obstacleTopCollide = obstaclePos.Y <= topBorder;
            bool obstacleBottomCollide = obstaclePos.Y + obstacleSize.Y >= bottomBorder;

            if (obstacleTopCollide)
            {
                obstacleSpeedY = -obstacleSpeedY;
            }
            if (obstacleBottomCollide)
            {
                obstacleSpeedY = -obstacleSpeedY;
            }
        }

        public Texture2D DrawMobImage(string filename)
        {
            //Loading texture assets for the obstacles            
            Image mobAsset = Raylib.LoadImage($"../../../../../BG 2.0/BG/{filename}");
            Texture2D obstacleImage = Raylib.LoadTextureFromImage(mobAsset);
            
            return obstacleImage;

        }

       
    }
}
