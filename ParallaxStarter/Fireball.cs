using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game3
{
    public class Fireball : ISprite
    {
        /// <summary>
        /// A spritesheet containing a fireball image
        /// </summary>
        Texture2D spritesheet;

        /// <summary>
        /// The portion of the spritesheet that is the fireball
        /// </summary>
        public Rectangle sourceRect = new Rectangle
        {
            X = 0,
            Y = 0,
            Width = 200,
            Height = 80
        };

        /// <summary>
        /// The origin of the fireball sprite
        /// </summary>
        Vector2 origin = new Vector2(100, 1);

        /// <summary>
        /// The fireball's position in the world
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Speed of the fireball
        /// </summary>
        int speed = 350;

        /// <summary>
        /// Random for fireballs spawn
        /// </summary>
        public Random random;

        Vector2 direction = new Vector2(-1, 0);

        /// <summary>
        /// Constructs a fireball
        /// </summary>
        /// <param name="spritesheet">The present's spritesheet</param>
        public Fireball(Texture2D spritesheet)
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
            Position += (float)gameTime.ElapsedGameTime.TotalSeconds * speed * direction;
            checkOutOfBounds();
        }

        /// <summary>
        /// Draws the fire sprite
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
                3400,
                (float)random.Next(0, 600)
                );
        }

        private void checkOutOfBounds()
        {
            if (Position.X < 0)
            {
                spawnNewLocation();
            }
        }
    }
}
