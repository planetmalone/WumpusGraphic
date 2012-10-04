using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WumpusGraphic
{
    class BorderSprite: Sprite
    {
        Room prevRoom;
        int bumped;

       public BorderSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, SpriteFont font)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize,
            speed, null, font)
        {
            bumped = 0;
        }

        public BorderSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, 
            SpriteFont font)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize,
            speed, millisecondsPerFrame, null, font)
        {
            bumped = 0;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            float x = position.X  + 10;
            float y = position.Y + 10;
            Vector2 fontPosition = new Vector2(x, y);

            spriteBatch.DrawString(font, getMessage(), fontPosition, Color.White);
        }

        private string getMessage()
        {
            string message = "";

            if (WGame.Status == "Start")
            {
                message = "Welcome";
            }
            else if (WGame.Status == "Play")
            {
                message = "Shoot, Move, or Quit?";
            }
            else if (WGame.Status == "Superbat")
            {
                message = "Zap! -- Superbat snatch! Elsewhereville for you!\n";
                message += "Shoot, Move, or Quit?";
            }
            else if (WGame.Status == "Pit")
            {
                message = "YYYIIIIEEEEE... fell in a pit!\n";
            }
            else if (WGame.Status == "Bumped")
            {
                message = "Bumped a Wumpus\n";
                message += "Shoot, Move, or Quit?";
            }
            else if (WGame.Status == "Eaten")
            {
                message = "Nom Nom! The Wumpus ate you!\n";
            }

            return message;
        }
    }
}
