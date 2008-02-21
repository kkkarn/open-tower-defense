
#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Collections;
#endregion

namespace towerdefense
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ContentManager content;
        SpriteBatch spriteBatch;
        private ArrayList towers;
        private EnemyManager em;
        private bool isLMBdown, isRMBdown;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            content = new ContentManager(Services);
            towers = new ArrayList();
            em = new EnemyManager();
            isLMBdown = false;
            isRMBdown = false;
            IsMouseVisible = true;
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            em.spawnEnemies(5, new Vector2(325, 20));
            Console.WriteLine("spawned the enemies");

            base.Initialize();
        }


        /// <summary>
        /// Load your graphics content.  If loadAllContent is true, you should
        /// load content from both ResourceManagementMode pools.  Otherwise, just
        /// load ResourceManagementMode.Manual content.
        /// </summary>
        /// <param name="loadAllContent">Which type of content to load.</param>
        protected override void LoadGraphicsContent(bool loadAllContent)
        {
            if (loadAllContent)
            {
                // TODO: Load any ResourceManagementMode.Automatic content
                spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            }

            // TODO: Load any ResourceManagementMode.Manual content
        }


        /// <summary>
        /// Unload your graphics content.  If unloadAllContent is true, you should
        /// unload content from both ResourceManagementMode pools.  Otherwise, just
        /// unload ResourceManagementMode.Manual content.  Manual content will get
        /// Disposed by the GraphicsDevice during a Reset.
        /// </summary>
        /// <param name="unloadAllContent">Which type of content to unload.</param>
        protected override void UnloadGraphicsContent(bool unloadAllContent)
        {
            if (unloadAllContent == true)
            {
                content.Unload();
            }
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the default game to exit on Xbox 360 and Windows
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            MouseState mouse = Mouse.GetState();
            KeyboardState keystate = Keyboard.GetState();

            Tower curTower;
            Vector2 curMouseLoc = new Vector2(mouse.X, mouse.Y);

            if (!isLMBdown && mouse.LeftButton == ButtonState.Pressed)
            {
                isLMBdown = true;
                /*for (int i = 0; i < towers.ToArray().GetLength(); i++)
                {
                    curTower = ((Tower)(towers.ToArray().GetValue(i)));
                    
                }*/ //add check for mouse inside list of all tower bounding boxes, if collision, dont add tower.
                //also check that mouse is inside player clickable space (see border bounds below)
                towers.Add(new Tower(curMouseLoc, (int)towerType.regular));
            }

            if (mouse.LeftButton == ButtonState.Released)
                isLMBdown = false;
                        
            if (!isRMBdown && mouse.RightButton == ButtonState.Pressed)
            {
                isRMBdown = true;
                towers.Add(new Tower(new Vector2(mouse.X, mouse.Y), (int)towerType.ice));
            }

            if (mouse.RightButton == ButtonState.Released)
                isRMBdown = false;
            
            // TODO: Add your update logic here

            em.moveEnemies();

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Tower curTower;
            
            graphics.GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);

            //draw borders
            //current logical border is (35,25),(685,585)
            spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\blackSquare"), new Rectangle(35, 25, 10, 225), Color.White);
            spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\blackSquare"), new Rectangle(35, 25, 275, 10), Color.White);

            spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\blackSquare"), new Rectangle(35, 325, 10, 250), Color.White);
            spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\blackSquare"), new Rectangle(35, 575, 275, 10), Color.White);

            spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\blackSquare"), new Rectangle(400, 25, 275, 10), Color.White);
            spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\blackSquare"), new Rectangle(675, 25, 10, 225), Color.White);

            spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\blackSquare"), new Rectangle(400, 575, 275, 10), Color.White);
            spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\blackSquare"), new Rectangle(675, 325, 10, 260), Color.White);


            //draw towers from array
            for (int i = 0; i < towers.ToArray().Length; i++)
            {
                curTower = (Tower)(towers.ToArray().GetValue(i));
                switch (curTower.getType())
                {
                    case towerType.regular:
                        spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\regtower"), curTower.getLoc(), Color.White);
                        break;

                    case towerType.ice:
                        spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\icetower"), curTower.getLoc(), Color.White);
                        break;
                }


            }

            for (int i = 0; i < em.getEnemyList().ToArray().Length; i++)
            {
                spriteBatch.Draw(this.content.Load<Texture2D>(@"resources\textures\enemy"),
                    ((Enemy)(em.getEnemyList().ToArray().GetValue(i))).getLoc(), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}