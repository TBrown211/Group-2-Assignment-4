using Raylib_cs;
using System.Numerics;

namespace Obstacle_Mapping
{
    internal class Obstacle
    {
        Vector2 obstaclePos;        
        Texture2D obstacleTexture;
        Vector2 obstacleSize;
        float obstacleRotation;
        float obstacleScale;
        Color obstacleColor;
        float obstacleSpeedX = 100;
        float obstacleSpeedY = 100;
        Texture2D mob;
        Random rng = new Random();  

        public Obstacle(Texture2D texture, Vector2 position, float rotation, float scale, Color color)
        {
            //Initializing the required inputs for the obstacle
            obstaclePos = position;
            obstacleTexture = texture;
            obstacleRotation = rotation;
            obstacleScale = scale;
            obstacleColor = color;
            obstacleSpeedY = obstacleSpeedY * rng.Next(1, 5);
        }

        public void DrawObstacle()
        {           
            
            
        }

        public void DrawMobImage()
        {
            Raylib.DrawTextureEx(obstacleTexture, obstaclePos, obstacleRotation, obstacleScale, obstacleColor);            
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

        public Texture2D InitializeMobImage(string filename)
        {
            //Loading texture assets for the obstacles            
            Image mobAsset = Raylib.LoadImage($"../../../../../BG 2.0/BG/{filename}");
            Texture2D obstacleImage = Raylib.LoadTextureFromImage(mobAsset);
            
            return obstacleImage;

        }


       
    }
}
