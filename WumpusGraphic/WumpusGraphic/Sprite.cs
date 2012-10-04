using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WumpusGraphic
{
    abstract class Sprite
    {
        protected Texture2D image;
        protected Point frameSize;
        public Point currentFrame;
        Point sheetSize;
        protected SpriteFont font;

        // Position
        protected Vector2 position;

        // Collisions
        int collisionOffset;

        // Framerate data
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame;
        const int defaultMillisecondsPerFrame = 16;

        // Collision Cue
        public string collisionCueName { get; private set; }

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, string collisionCueName, SpriteFont font)
            : this(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize,
            speed, defaultMillisecondsPerFrame, collisionCueName, font)
        {
        }

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame,
            string collisionCueName, SpriteFont font)
        {
            this.image = textureImage;
            this.position = position;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.millisecondsPerFrame = millisecondsPerFrame;
            this.collisionCueName = collisionCueName;
            this.font = font;
        }
        
        // Update
        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
        } // End Update

        // Draw
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                image,
                position,
                new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y),
                Color.White,
                0,
                Vector2.Zero,
                1f,
                SpriteEffects.None,
                0
            );
        } // End Draw

        // Collision rectangle
        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                    (int)position.X + collisionOffset,
                    (int)position.Y + collisionOffset,
                    frameSize.X - (collisionOffset * 2),
                    frameSize.Y - (collisionOffset * 2)
                );
            }
        }
    }
}
