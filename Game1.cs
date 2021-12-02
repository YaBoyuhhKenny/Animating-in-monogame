using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        int randomX;
        int randomY;
        int randomXSpeed;
        int randomYSpeed;

        Tribble rgbTribble;

        Tribble blueTribble;

        Tribble purpleTribble;

        Texture2D tribbleGreyTexture;
        Tribble greyTribble;

        Texture2D tribbleBrownTexture;
        Tribble brownTribble;

        Texture2D tribbleCreamTexture;
        Tribble creamTribble;

        Texture2D tribbleIntroTexture;

        Texture2D tribbleOrangeTexture;
        Tribble orangeTribble;

        SoundEffect Coo;

        MouseState mouseState;
        Screen currentScreen;

        enum Screen
        {
            Intro,
            TribbleYard
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here           

            for (int i = 0; i < 100; i++)
            {
                int r = generator.Next(256);               
                int g = generator.Next(256);                
                int b = generator.Next(256);
                colors.Add(new Color(r, g, b));               
            }


            randomX = generator.Next(0, _graphics.PreferredBackBufferWidth - 100);
            randomY = generator.Next(0, _graphics.PreferredBackBufferHeight - 100);
            randomXSpeed = generator.Next(-50, 50);
            randomYSpeed = generator.Next(-50, 50);

            backgroundColor = colors[generator.Next(colors.Count)];

            currentScreen = Screen.Intro;
            base.Initialize();


            greyTribble = new Tribble(tribbleGreyTexture, new Rectangle(300, 10, 100, 100), new Vector2(8, 6));
            brownTribble = new Tribble(tribbleBrownTexture, new Rectangle(700, 0, 100, 100), new Vector2(-10, 7));
            creamTribble = new Tribble(tribbleCreamTexture, new Rectangle(400, 10, 100, 100), new Vector2(0, 10));
            orangeTribble = new Tribble(tribbleOrangeTexture, new Rectangle(300, 40, 100, 100), new Vector2(20, 0));
            blueTribble = new Tribble(tribbleOrangeTexture, new Rectangle(400, 30, 100, 100), new Vector2(20, 15));
            rgbTribble = new Tribble(tribbleGreyTexture, new Rectangle(200, 60, 100, 100), new Vector2(9, 8));
            purpleTribble = new Tribble(tribbleCreamTexture, new Rectangle(randomX, randomY, 100, 100), new Vector2(randomXSpeed, randomYSpeed));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            Coo = Content.Load<SoundEffect>("Coo");
            tribbleIntroTexture = Content.Load<Texture2D>("tribble_intro");
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (currentScreen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    currentScreen = Screen.TribbleYard;
            }
            else if(currentScreen == Screen.TribbleYard)
            {
                greyTribble.Move();
                if (greyTribble.Bounds.Top <= 0 || greyTribble.Bounds.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    greyTribble.BounceTopBottom();
                    backgroundColor = colors[generator.Next(colors.Count)];
                    Coo.Play();
                }
                if (greyTribble.Bounds.Left <= 0 || greyTribble.Bounds.Right >= _graphics.PreferredBackBufferWidth)
                {
                    greyTribble.BounceLeftRight();
                    backgroundColor = colors[generator.Next(colors.Count)];
                    Coo.Play();
                }

                brownTribble.Move();
                if (brownTribble.Bounds.Top <= 0 || brownTribble.Bounds.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    brownTribble.BounceTopBottom();
                    backgroundColor = colors[generator.Next(colors.Count)];
                    Coo.Play();
                }
                if (brownTribble.Bounds.Left <= 0 || brownTribble.Bounds.Right >= _graphics.PreferredBackBufferWidth)
                {
                    brownTribble.BounceLeftRight();
                    backgroundColor = colors[generator.Next(colors.Count)];
                    Coo.Play();
                }

                creamTribble.Move();
                if (creamTribble.Bounds.Top <= 0 || creamTribble.Bounds.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    creamTribble.BounceTopBottom();
                }
                if (creamTribble.Bounds.Left <= 0 || creamTribble.Bounds.Right >= _graphics.PreferredBackBufferWidth)
                {
                    creamTribble.BounceLeftRight();
                }

                blueTribble.Move();
                if (blueTribble.Bounds.Top <= 0 || blueTribble.Bounds.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    blueTribble.BounceTopBottom();
                }
                if (blueTribble.Bounds.Left <= 0 || blueTribble.Bounds.Right >= _graphics.PreferredBackBufferWidth)
                {
                    blueTribble.BounceLeftRight();
                }

                purpleTribble.Move();
                if (purpleTribble.Bounds.Top <= 0 || purpleTribble.Bounds.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    purpleTribble.BounceTopBottom();
                }
                if (purpleTribble.Bounds.Left <= 0 || purpleTribble.Bounds.Right >= _graphics.PreferredBackBufferWidth)
                {
                    purpleTribble.BounceLeftRight();
                }

                rgbTribble.Move();
                if (rgbTribble.Bounds.Top <= 0 || rgbTribble.Bounds.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    rgbTribble.BounceTopBottom();
                    backgroundColor = colors[generator.Next(colors.Count)];
                    Coo.Play();
                }
                if (rgbTribble.Bounds.Left <= 0 || rgbTribble.Bounds.Right >= _graphics.PreferredBackBufferWidth)
                {
                    rgbTribble.BounceLeftRight();
                    backgroundColor = colors[generator.Next(colors.Count)];
                    Coo.Play();
                }

                orangeTribble.Move();
                if (orangeTribble.Bounds.Top <= 0 || orangeTribble.Bounds.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    orangeTribble.BounceTopBottom();
                }
                if (orangeTribble.Bounds.Left <= 0 || orangeTribble.Bounds.Right >= _graphics.PreferredBackBufferWidth)
                {
                    orangeTribble.BounceLeftRight();
                }
            }

            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (currentScreen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntroTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
                if (mouseState.LeftButton == ButtonState.Pressed)
                    currentScreen = Screen.TribbleYard;
            }
            else if (currentScreen == Screen.TribbleYard)
            {
                greyTribble.Draw(_spriteBatch);

                _spriteBatch.Draw(rgbTribble.Texture, rgbTribble.Bounds, backgroundColor);

                _spriteBatch.Draw(purpleTribble.Texture, purpleTribble.Bounds, Color.Purple);

                _spriteBatch.Draw(blueTribble.Texture, blueTribble.Bounds, Color.Blue);

                brownTribble.Draw(_spriteBatch);

                creamTribble.Draw(_spriteBatch);

                orangeTribble.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
