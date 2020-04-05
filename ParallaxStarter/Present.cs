using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game3
{
    public class Present : ISprite
    {
        /// <summary>
        /// A spritesheet containing a present image
        /// </summary>
        Texture2D spritesheet;

        /// <summary>
        /// The portion of the spritesheet that is the presenr
        /// </summary>
        public Rectangle sourceRect = new Rectangle
        {
            X = 0,
            Y = 0,
            Width = 100,
            Height = 104
        };

        /// <summary>
        /// The origin of the present sprite
        /// </summary>
        Vector2 origin = new Vector2(50, 1);

        /// <summary>
        /// The present's position in the world
        /// </summary>
        public Vector2 Position { get; set; }

        public Random random;

        /// <summary>
        /// Constructs a player
        /// </summary>
        /// <param name="spritesheet">The present's spritesheet</param>
        public Present(Texture2D spritesheet)
        {
            this.spritesheet = spritesheet;
            this.random = new Random();
            spawnNewLocation();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime)
        {
            
        }

        /// <summary>
        /// Draws the present sprite
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // Render the santa
            spriteBatch.Draw(spritesheet, Position, sourceRect, Color.White, 0, origin, 1f, SpriteEffects.None, 0.7f);
        }

        public void spawnNewLocation()
        {
            Position = new Vector2(
                (float)random.Next(200, 2900),
                (float)random.Next(0, 600)
                );
        }
    }
}
