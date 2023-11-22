using Raylib_cs;
using System.Numerics;

namespace Obstacle_Mapping
{
    internal class Obstacle
    {
        Vector2 obstaclePos;
        Vector2 obstacleSize;
        Color obstacleColor;
        int obstacleSpeedX = 100;
        int obstacleSpeedY = 100;        

        public Obstacle(Vector2 position, Vector2 size, Color color)
        {
            //Initializing the required inputs for the obstacle
            obstaclePos = position;
            obstacleSize = size;
            obstacleColor = color;
        }

        public void DrawObstacle()
        {
            //Draw the obstacle on screen
            Raylib.DrawRectangleV(obstaclePos, obstacleSize, obstacleColor);
        }

        public void MoveObstacle()
        {
            obstaclePos += obstaclePos * new Vector2(obstacleSpeedX, obstacleSpeedY) * Raylib.GetFrameTime();          
        } 

        public void ObstacleScreenBoundaries()
        {
            float topBorder = 0;
            float bottomBorder = Raylib.GetScreenHeight();
            bool obstacleTopCollide = obstaclePos.Y >= topBorder;
            bool obstacleBottomCollide = obstaclePos.Y <= bottomBorder;

            if (obstacleTopCollide)
            {
                obstacleSpeedY += obstacleSpeedY;
            }
            if (obstacleBottomCollide)
            {
                obstacleSpeedY -= obstacleSpeedY;
            }
        }

       
    }
}
