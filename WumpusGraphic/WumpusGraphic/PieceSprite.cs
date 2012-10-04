using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WumpusGraphic
{
    class PieceSprite: Sprite
    {
        Room room;

        public PieceSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, SpriteFont font, Room room)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize,
            speed, null, font)
        {
            this.room = room;
        }

        public PieceSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, 
            SpriteFont font, Room room)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize,
            speed, millisecondsPerFrame, null, font)
        {
            this.room = room;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            // Clear pieces
            currentFrame = new Point(0, 0);

            // Change player room if adjacent
            foreach (Room adjRoom in Board.Player.Room.AdjRooms)
            {
                if (adjRoom.Number == room.Number)
                {
                    MouseState mouseState = Mouse.GetState();
                    if (mouseState.LeftButton == ButtonState.Pressed
                        && new Rectangle(mouseState.X, mouseState.Y, 1, 1).Intersects(this.collisionRect))
                    {
                        Board.Player.Room.Player = false;
                        room.Player = true;
                        Board.Player.Room = Board.Map[room.Number];
                    }
                }
            }

            if (room.Player)
                currentFrame = new Point(0, 1);
            else if (room.Wumpus)
                currentFrame = new Point(0, 4);
            else if (room.Hazard != null)
            {
                if (room.Hazard.Type == "superbat")
                    currentFrame = new Point(0, 3);
                else if (room.Hazard.Type == "pit")
                    currentFrame = new Point(0, 2);
            }
        }

        // Draw
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
          base.Draw(gameTime, spriteBatch);

          float x = position.X - 7 + frameSize.X / 2;
          float y = position.Y - 7 + frameSize.Y / 2;
          Vector2 fontPosition = new Vector2(x, y);
          spriteBatch.DrawString(font, (room.Number).ToString(), fontPosition, Color.White);

        } // End Draw
    }
}
