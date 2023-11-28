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
        public Paddles paddles;
        

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

        public bool BallCollisionCheck(Ball ball)
        {
            Vector2 ballPosition = ball.FireBallPosition();
            float ballRadius = ball.FireBallRadius();

            float leftOfFireBall = ballPosition.X - ballRadius;
            float rightOfFireBall = ballPosition.X + ballRadius;
            float topOfFireBall = ballPosition.Y - ballRadius;
            float bottomOfFireBall = ballPosition.Y + ballRadius;

            float topOfObstacle = obstaclePos.Y;
            float bottomOfObstacle = obstaclePos.Y + obstacleTexture.Height;
            float leftOfObstacle = obstaclePos.X;
            float rightOfObstacle = obstaclePos.X + obstacleTexture.Width;

            bool ballTouchesTop = bottomOfFireBall >= topOfObstacle;
            bool ballTouchesBottom = topOfFireBall <= bottomOfObstacle;
            bool ballTouchesLeft = leftOfFireBall <= rightOfObstacle;
            bool ballTouchesRight = rightOfFireBall >= leftOfObstacle;
            bool fireBallHitsObstacle = ballTouchesTop && ballTouchesBottom && ballTouchesLeft && ballTouchesRight;

            if (fireBallHitsObstacle)
            {
                ball.FireBallsReflected();
            }

            return fireBallHitsObstacle;

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
