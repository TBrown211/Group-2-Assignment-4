using Raylib_cs;
using System.Numerics;

namespace Obstacle_Mapping
{
    internal class Obstacle
    {
        Vector2 obstaclePos;
        Vector2 obstacleSize;
        Color obstacleColor;
        public Obstacle(Vector2 position, Vector2 size, Color color)
        {
            obstaclePos = position;
            obstacleSize = size;
            obstacleColor = color;
        }

        public void DrawObstacle()
        {
            Raylib.DrawRectangleV(obstaclePos, obstacleSize, obstacleColor);
        }
    }
}
