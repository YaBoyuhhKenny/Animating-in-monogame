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
        Tribble greyTribble;

        Texture2D tribbleBrownTexture;
        Tribble brownTribble;

        Texture2D tribbleCreamTexture;
        Tribble creamTribble;

        Texture2D tribbleOrangeTexture;
        Tribble orangeTribble;
         

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

            backgroundColor = colors[generator.Next(colors.Count)];

            base.Initialize();
            greyTribble = new Tribble(tribbleGreyTexture, new Rectangle(300, 10, 100, 100), new Vector2(8, 6));
            brownTribble = new Tribble(tribbleBrownTexture, new Rectangle(700, 0, 100, 100), new Vector2(-10, 5));
            creamTribble = new Tribble(tribbleCreamTexture, new Rectangle(400, 10, 100, 100), new Vector2(0, 10));
            orangeTribble = new Tribble(tribbleOrangeTexture, new Rectangle(300, 40, 100, 100), new Vector2(20, 0));
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
            greyTribble.Move();
            if (greyTribble.Bounds.Top <= 0 || greyTribble.Bounds.Bottom >= _graphics.PreferredBackBufferHeight)
            {
                greyTribble.BounceTopBottom();
            }
            if (greyTribble.Bounds.Left <= 0 || greyTribble.Bounds.Right >= _graphics.PreferredBackBufferWidth)
            {
                greyTribble.BounceLeftRight();
            }

            brownTribble.Move();
            if (brownTribble.Bounds.Top <= 0 || brownTribble.Bounds.Bottom >= _graphics.PreferredBackBufferHeight)
            {
                brownTribble.BounceTopBottom();
            }
            if (brownTribble.Bounds.Left <= 0 || brownTribble.Bounds.Right >= _graphics.PreferredBackBufferWidth)
            {
                brownTribble.BounceLeftRight();
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

            orangeTribble.Move();
            if (orangeTribble.Bounds.Top <= 0 || orangeTribble.Bounds.Bottom >= _graphics.PreferredBackBufferHeight)
            {
                orangeTribble.BounceTopBottom();
            }
            if (orangeTribble.Bounds.Left <= 0 || orangeTribble.Bounds.Right >= _graphics.PreferredBackBufferWidth)
            {
                orangeTribble.BounceLeftRight();
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


            _spriteBatch.Draw(greyTribble.Texture, greyTribble.Bounds, Color.White);

            _spriteBatch.Draw(brownTribble.Texture, brownTribble.Bounds, Color.White);

            _spriteBatch.Draw(creamTribble.Texture, creamTribble.Bounds, Color.White);

            _spriteBatch.Draw(orangeTribble.Texture, orangeTribble.Bounds, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
