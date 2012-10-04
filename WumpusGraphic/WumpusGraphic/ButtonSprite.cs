using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WumpusGraphic
{
    class ButtonSprite: Sprite
    {
        public ButtonSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, SpriteFont font)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize,
            speed, null, font)
        {
            
        }

        public ButtonSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, 
            SpriteFont font)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize,
            speed, millisecondsPerFrame, null, font)
        {
            
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            base.Update(gameTime, clientBounds);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
