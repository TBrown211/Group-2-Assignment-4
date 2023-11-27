using Raylib_cs;
using System.Numerics;

namespace Group_2_Assignment_4
{
    public class Ball
    {
        Vector2 position;
        Vector2 speed;
        float radius;
        Texture2D texture;
        Sound fireAudio;

        public Ball() 
        {
            radius = 10;
            ResetFireBall();
        }

        public void LoadFireballTexture()
        {
            Image image = Raylib.LoadImage("../../../Assets/Texture/Effects_Fire_0_14.png");
            texture = Raylib.LoadTextureFromImage(image);
        }
        public void LoadFireBallSound()
        {
            Wave wave = Raylib.LoadWave("../../../Assets/Audio/105016__julien-matthey__jm-fx-fireball-01.wav");
            fireAudio = Raylib.LoadSoundFromWave(wave);
        }

        public void Draw()
        {
            float angleOfTexture = MathF.Atan2(speed.Y, speed.X) / MathF.PI *180;
            float roatation = angleOfTexture;

            Raylib.DrawCircleV(position, radius, Color.BLANK);
            Raylib.DrawTexturePro(
                texture,
                new Rectangle(0, 0, texture.Width, texture.Height), //Source Rectangle
                new Rectangle(position.X, position.Y,texture.Width/2, texture.Height/2), //Dest Rectangle
                new Vector2(60, 27), //Origin
                roatation, //Roatation
                Color.WHITE
                );

        }

        public void MoveBall()
        {
            position = position + speed * Raylib.GetFrameTime();
        }

        public void CollideBall()
        {
            float topOfScreen = 0;
            float bottomOfScreen = Raylib.GetScreenHeight();

            bool ballHitsTop = position.Y <= topOfScreen + radius;
            bool ballHitsBottom = position.Y >= bottomOfScreen - radius;

            if (ballHitsTop || ballHitsBottom)
            {
                speed.Y = -speed.Y;
                Raylib.PlaySound(fireAudio);
            }
        }

        public bool BallIsPastLeftEdge() //Checks to see if the ball is past the left side of the screen
        {
            float leftEdge = 0;
            bool hasPastLeft = position.X < leftEdge;
            return hasPastLeft;
        }

        public bool BallIsPastRightEdge() //Checks to see if the ball is past the right side of the screen
        {
            float rightEdge = Raylib.GetScreenWidth();
            bool hasPastRight = position.X > rightEdge;
            return hasPastRight;
        }
        
        public void ResetFireBall() // This will set the fireball at the center of the screen and have it go into a random direction at the start of each round
        {
            position.X = 400;
            position.Y = 300;
            Random direction = new Random();
            speed.X = direction.Next(-200, 200);
            speed.Y = direction.Next(-200, 200);

            if (MathF.Abs(speed.X) < 200)
            {
                if (MathF.Sign(speed.X) > 0) 
                {
                    speed.X = 200;
                }
                else
                {
                    speed.X = -200;
                }
            }

        }

        public void FireBallIsReflected() //Call this when the ball hits the paddle
        {
            position.X = -position.X;
        }

        public Vector2 FireBallPosition() //Call this function when you want to get the position of the fireball for other parts of the code.
        {
            return position; 
        }

        public float FireBallRadius() //Call this function when you want to get the radius of the fireball for other parts of the code.
        {
            return radius;
        }

        public Sound ReturnFireAudio() //Call this function when you want to get the audio for the fireball
        {
            return fireAudio;
        }
    }
}
