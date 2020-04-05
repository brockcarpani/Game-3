using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    /// <summary>
    /// Text Sprite class for layers
    /// </summary>
    public class Text : ISprite
    {
        /// <summary>
        /// Font for text
        /// </summary>
        SpriteFont font;

        /// <summary>
        /// Score of game
        /// </summary>
        int score;

        /// <summary>
        /// Lives of game
        /// </summary>
        int lives;

        /// <summary>
        /// Constructor for Text class
        /// </summary>
        /// <param name="font"></param>
        public Text(SpriteFont font, int score, int lives)
        {
            this.font = font;
            this.score = score;
            this.lives = lives;
        }

        /// <summary>
        /// Update for the text
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime, int score, int lives)
        {
            this.score = score;
            this.lives = lives;
        }

        /// <summary>
        /// Draw function from Interface
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(font, "Score: " + score, new Vector2(50, 0), Color.White);
            spriteBatch.DrawString(font, "Lives: " + lives, new Vector2(50, 50), Color.White);
        }
    }
}
