using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Animating_in_monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator = new Random();
        List<Color> colors = new List<Color>();
        Color backgroundColor;

        Texture2D tribbleGreyTexture;
        Rectangle tribbleGrayRect;
        Vector2 tribbleGreySpeed;

        Texture2D tribbleBrownTexture;
        Rectangle tribbleBrownRect;
        Vector2 tribbleBrownSpeed;

        Texture2D tribbleCreamTexture;
        Rectangle tribbleCreamRect;
        Vector2 tribbleCreamSpeed;

        Texture2D tribbleOrangeTexture;
        Rectangle tribbleOrangeRect;
        Vector2 tribbleOrangeSpeed;

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tribbleGrayRect = new Rectangle(300, 10, 100, 100);
            tribbleGreySpeed = new Vector2(3, 2);
            
            tribbleBrownRect = new Rectangle(700, 0, 100, 100);
            tribbleBrownSpeed = new Vector2(-10, 5);
            
            tribbleCreamRect = new Rectangle(400, 10, 100, 100);
            tribbleCreamSpeed = new Vector2(0, 10);
            
            tribbleOrangeRect = new Rectangle(300, 40, 100, 100);
            tribbleOrangeSpeed = new Vector2(20, 0);

            for (int i = 0; i < 100; i++)
            {
                int r = generator.Next(256);               
                int g = generator.Next(256);                
                int b = generator.Next(256);
                colors.Add(new Color(r, g, b));               
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribbleGrayRect.X += (int)tribbleGreySpeed.X;
            if (tribbleGrayRect.Right >= _graphics.PreferredBackBufferWidth || tribbleGrayRect.Left <= 0)
                tribbleGreySpeed.X *= -1;
                    

            tribbleGrayRect.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGrayRect.Bottom >= _graphics.PreferredBackBufferHeight || tribbleGrayRect.Top <= 0 )
                tribbleGreySpeed.Y *= -1;

            //have it actually pull a value >:(

            tribbleGrayRect.X += (int)tribbleGreySpeed.X;
            if (tribbleGrayRect.Right >= _graphics.PreferredBackBufferWidth || tribbleGrayRect.Left <= 0)
                GraphicsDevice.Clear(backgroundColor);


            tribbleGrayRect.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGrayRect.Bottom >= _graphics.PreferredBackBufferHeight || tribbleGrayRect.Top <= 0)
                GraphicsDevice.Clear(backgroundColor);


            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            if (tribbleBrownRect.Right >= _graphics.PreferredBackBufferWidth || tribbleBrownRect.Left <= 0)
                tribbleBrownSpeed.X *= -1;

            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
            if (tribbleBrownRect.Bottom >= _graphics.PreferredBackBufferHeight || tribbleBrownRect.Top <= 0)
                tribbleBrownSpeed.Y *= -1;
            

            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            if (tribbleCreamRect.Top > _graphics.PreferredBackBufferHeight)
                tribbleCreamRect.Y = 0 - tribbleCreamRect.Height;
            

            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            if (tribbleOrangeRect.Left >= _graphics.PreferredBackBufferWidth)
                tribbleOrangeRect.X = 0 - tribbleOrangeRect.Width;
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();


            _spriteBatch.Draw(tribbleGreyTexture, tribbleGrayRect, Color.White);

            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
