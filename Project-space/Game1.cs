using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Project_space
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ship;
        Vector2 shipPosition = new Vector2(400, 400);
        int shipSpeed = 3;
        KeyboardState tangentbord = Keyboard.GetState();
        KeyboardState keyboardOne = Keyboard.GetState();
        KeyboardState keyboardTwo = Keyboard.GetState(); 
        Texture2D BulletBild;
        Rectangle BulletRectangle;
        bool shoot = false;
        Texture2D background;
        Vector2 backgroundposition = new Vector2(0, 0);

        Texture2D aliens;
        List<Vector2> alienpositioner = new List<Vector2>();
        int alienspeed = 1;

        Dictionary<string, int> settings = new Dictionary<string, int>();

        List<Rectangle> bricks = new List<Rectangle>();

        public Game1()

        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

          
        }

        protected override void Initialize()     
        
        {
      
           
            for (int x = 0; x < 11; x++)

            {
                for (int y = 0; y < 3; y++)
                {
                    alienpositioner.Add(new Vector2(60 + 60 * x, 60 + 60 * y));
                }
            }
            base.Initialize();

            settings["shootSpeed"] = 7;
            settings["moveX"] = 2;
            settings["alienShootSpeed"] = 10;

        }


        protected override void LoadContent()

        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ship = Content.Load<Texture2D>("space invaders ship (1)");
            background = Content.Load<Texture2D>("space background");

            aliens = Content.Load<Texture2D>("space invaders alien");

            BulletBild = Content.Load<Texture2D>("playerBullet");
            BulletRectangle = new Rectangle(400, 400, BulletBild.Width / 2, BulletBild.Height / 2);

        }

        protected override void Update(GameTime gameTime)

        {
            keyboardTwo = keyboardOne;
            keyboardOne = Keyboard.GetState();




            if (keyboardOne.IsKeyDown(Keys.Left) && (shipPosition.X > 0))
            {
                shipPosition.X -= shipSpeed;
                if (!shoot)
                {
                    BulletRectangle.X -= shipSpeed;
                }

            }


            if (keyboardOne.IsKeyDown(Keys.Right) && (shipPosition.X > 0))
            {
                shipPosition.X += shipSpeed;
                if (!shoot)
                {
                    BulletRectangle.X += shipSpeed;
                }


            }
            if (keyboardOne.IsKeyDown(Keys.Space) && (keyboardTwo.IsKeyUp(Keys.Space)))
            {
                shoot = true;
                
            }
            if (shoot)
            {
                BulletRectangle.Y -= 5;
            }

            if (shoot)
            {
                if (BulletRectangle.Y > 0)
                {
                    BulletRectangle.Y -= settings["shootSpeed"];
                }
                else if (BulletRectangle.Y <= 0)
                {
                    shoot = false;
                    BulletRectangle.Y = (int)shipPosition.X;
                }
            }

           
        base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(background, backgroundposition, Color.White);
            spriteBatch.End();
            spriteBatch.Begin();
            spriteBatch.Draw(ship, shipPosition, Color.White);
            spriteBatch.End();

            spriteBatch.Begin();
            spriteBatch.Draw(BulletBild, BulletRectangle, Color.White);
            spriteBatch.End();

            spriteBatch.Begin();
            foreach (Vector2 alienPosition in alienpositioner)
            {
                spriteBatch.Draw(aliens, alienPosition, Color.White);
            }
            spriteBatch.End();


            base.Draw(gameTime);

        }



    }
}
