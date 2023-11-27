using Raylib_cs;
using System.Numerics;

namespace Group_2_Assignment_4
{
    internal class Obstacle
    {
        Vector2 obstaclePos;        
        Texture2D obstacleTexture;
        Vector2 obstacleSize = new Vector2(50, 50);
        float obstacleRotation;
        float obstacleScale;
        Color obstacleColor;       
        float obstacleSpeedY = 100;        
        Random rng = new Random();  
        static Ball ball = new Ball();

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
       

        public void DrawMobImage()
        {
            Raylib.DrawRectangleV(obstaclePos, obstacleSize, Color.VIOLET);
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

        public void BallCollisionCheck()
        {
            float topOfObstacle = obstaclePos.Y;
            float bottomOfObstacle = obstaclePos.Y + obstacleSize.Y;
            float leftOfObstacle = obstaclePos.X;
            float rightOfObstacle = obstaclePos.X + obstacleSize.X;

            bool isBallTouchingTop = ball.FireBallPosition().Y + ball.FireBallRadius() >= topOfObstacle;
            bool isBallTouchingBottom = ball.FireBallPosition().Y - ball.FireBallRadius() <= bottomOfObstacle;
            bool isBallTouchingLeft = ball.FireBallPosition().X + ball.FireBallRadius() >= leftOfObstacle;
            bool isBallTouchingRight = ball.FireBallPosition().X - ball.FireBallRadius() <= rightOfObstacle;

            if (isBallTouchingLeft || isBallTouchingRight)
            {
                ball.FireBallIsReflected();
            }
            else if (isBallTouchingTop || isBallTouchingBottom)
            {
                ball.FireBallIsReflected();
            }

            if (Raylib.CheckCollisionCircleRec(ball.FireBallPosition(), 
                ball.FireBallRadius(), 
                new Rectangle(obstaclePos.X, obstaclePos.Y, obstacleSize.X, obstacleSize.Y)))
            {
                ball.FireBallPosition();
            }

        }

        public Vector2 MobPosition()
        {
            return obstaclePos;
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
