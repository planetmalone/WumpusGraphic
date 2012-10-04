using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace WumpusGraphic
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        List<PieceSprite> pieces = new List<PieceSprite>();
        SpriteFont font;
        Vector2[] positions;
        Texture2D dot;
        Texture2D moveImage;
        Texture2D shootImage;
        Texture2D quitImage;
        ButtonSprite move;
        ButtonSprite shoot;
        ButtonSprite quit;
        BorderSprite border;

        public SpriteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        // Load content
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            font = Game.Content.Load<SpriteFont>(@"myFont");
            dot = Game.Content.Load<Texture2D>(@"images/dot");
            moveImage = Game.Content.Load<Texture2D>(@"images/move");
            shootImage = Game.Content.Load<Texture2D>(@"images/shoot");
            quitImage = Game.Content.Load<Texture2D>(@"images/quit");

            // Get center of game window
            int x = Game.Window.ClientBounds.Width / 2 - 75 / 2;
            int y = Game.Window.ClientBounds.Height / 2 - 66 / 2;

            // Temporary initialization of array of positions
            Vector2[] temp = {
                new Vector2(x, y + 75),
                new Vector2((float)(x - 75 * Math.Sin(.4 * Math.PI)), (float)(y + 75 * Math.Cos(.4 * Math.PI))),
                new Vector2((float)(x - 75 * Math.Sin(.2 * Math.PI)), (float)(y - 75 * Math.Cos(.2 * Math.PI))),
                new Vector2((float)(x + 75 * Math.Sin(.2 * Math.PI)), (float)(y - 75 * Math.Cos(.2 * Math.PI))),
                new Vector2((float)(x + 75 * Math.Sin(.4 * Math.PI)), (float)(y + 75 * Math.Cos(.4 * Math.PI))),
                new Vector2(x, y - 150),
                new Vector2((float)(x + 150 * Math.Sin(.4 * Math.PI)), (float)(y - 150 * Math.Cos(.4 * Math.PI))),
                new Vector2((float)(x + 150 * Math.Sin(.2 * Math.PI)), (float)(y + 150 * Math.Cos(.2 * Math.PI))),
                new Vector2((float)(x - 150 * Math.Sin(.2 * Math.PI)), (float)(y + 150 * Math.Cos(.2 * Math.PI))),
                new Vector2((float)(x - 150 * Math.Sin(.4 * Math.PI)), (float)(y - 150 * Math.Cos(.4 * Math.PI))),
                new Vector2(x, y - 255),
                new Vector2((float)(x + 255 * Math.Sin(.4 * Math.PI)), (float)(y - 255 * Math.Cos(.4 * Math.PI))),
                new Vector2((float)(x + 255 * Math.Sin(.2 * Math.PI)), (float)(y + 255 * Math.Cos(.2 * Math.PI))),
                new Vector2((float)(x - 255 * Math.Sin(.2 * Math.PI)), (float)(y + 255 * Math.Cos(.2 * Math.PI))),
                new Vector2((float)(x - 255 * Math.Sin(.4 * Math.PI)), (float)(y - 255 * Math.Cos(.4 * Math.PI))),
                new Vector2(x - 98, y - 140),
                new Vector2(x + 98, y - 140),
                new Vector2(x + 160, y + 50),
                new Vector2(x - 160, y + 50),
                new Vector2(x, y + 160)
            };

            // Copy temp to positions
            positions = temp;

            // Add game pieces
            // Inner Pieces
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[0],
                    new Point(75,66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[1]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[1],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[2]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[2],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[3]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[3],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[4]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[4],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[5]
                ));

            // Middle
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[5],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[6]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[6],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[7]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[7],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[8]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[8],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[9]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[9],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[10]
                ));

            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[15],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[16]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[16],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[17]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[17],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[18]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[18],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[19]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[19],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[20]
                ));

            // Outer
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[10],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[11]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[11],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[12]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[12],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[13]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[13],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[14]
                ));
            pieces.Add(new PieceSprite(
                    Game.Content.Load<Texture2D>(@"images/piece"),
                    positions[14],
                    new Point(75, 66),
                    10,
                    new Point(0, 0),
                    new Point(2, 5),
                    Vector2.Zero,
                    font,
                    Board.Map[15]
                ));

            // Draw buttons
            int vPos = Game.Window.ClientBounds.Height - 80;
            move = new ButtonSprite(
                moveImage,
                new Vector2(0, vPos),
                new Point(80,80),
                0,
                new Point(0, 0),
                new Point(1,1),
                Vector2.Zero,
                font
            );

            shoot = new ButtonSprite(
                shootImage,
                new Vector2(90, vPos),
                new Point(80, 80),
                0,
                new Point(0, 0),
                new Point(1, 1),
                Vector2.Zero,
                font
            );

            quit = new ButtonSprite(
                quitImage,
                new Vector2(180, vPos),
                new Point(80, 80),
                0,
                new Point(0, 0),
                new Point(1, 1),
                Vector2.Zero,
                font
            );

            // Add text border
            border = new BorderSprite(
                Game.Content.Load<Texture2D>(@"images/border"),
                new Vector2(Game.Window.ClientBounds.Width - 500, Game.Window.ClientBounds.Height - 100),
                new Point(500, 100),
                0,
                new Point(0, 0),
                new Point(1, 1),
                Vector2.Zero,
                font
            );

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            foreach (Sprite piece in pieces)
            {
                piece.Update(gameTime, Game.Window.ClientBounds);

                // Hover action
                MouseState mouseState = Mouse.GetState();
                if (new Rectangle(mouseState.X, mouseState.Y, 1, 1).Intersects(piece.collisionRect))
                {
                    piece.currentFrame.X = 1;
                }
                else
                {
                    piece.currentFrame.X = 0;
                }

                // Check if player ran into Superbat
                if (Board.Player.Room.Hazard != null)
                {
                    if (Board.Player.Room.Hazard.Type == "superbat")
                    {
                        Board.movePlayerRandom();
                    }
                    else if (Board.Player.Room.Hazard.Type == "pit")
                    {
                        Board.Player.Alive = false;
                    }
                }

                // Check if player ran into Wumpus
                if (Board.Player.Room == Board.Wumpus.Room)
                {
                    Board.Wumpus.Awake = true;
                }

                // Exit if Player clicks door button
                if(mouseState.LeftButton == ButtonState.Pressed
                    && new Rectangle(mouseState.X, mouseState.Y, 1, 1).Intersects(quit.collisionRect))
                {
                    Game.Exit();
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            
            // Draw lines
            // Inner
            drawLine(new Vector2((positions[0].X + 37), positions[0].Y + 33), new Vector2((positions[1].X + 37), positions[1].Y + 33));
            drawLine(new Vector2((positions[1].X + 37), positions[1].Y + 33), new Vector2((positions[2].X + 37), positions[2].Y + 33));
            drawLine(new Vector2((positions[2].X + 37), positions[2].Y + 33), new Vector2((positions[3].X + 37), positions[3].Y + 33));
            drawLine(new Vector2((positions[3].X + 37), positions[3].Y + 33), new Vector2((positions[4].X + 37), positions[4].Y + 33));
            drawLine(new Vector2((positions[4].X + 37), positions[4].Y + 33), new Vector2((positions[0].X + 37), positions[0].Y + 33));

            // Middle
            drawLine(new Vector2((positions[5].X + 37), positions[5].Y + 33), new Vector2((positions[16].X + 37), positions[16].Y + 33));
            drawLine(new Vector2((positions[16].X + 37), positions[16].Y + 33), new Vector2((positions[6].X + 37), positions[6].Y + 33));
            drawLine(new Vector2((positions[6].X + 37), positions[6].Y + 33), new Vector2((positions[17].X + 37), positions[17].Y + 33));
            drawLine(new Vector2((positions[17].X + 37), positions[17].Y + 33), new Vector2((positions[7].X + 37), positions[7].Y + 33));
            drawLine(new Vector2((positions[7].X + 37), positions[7].Y + 33), new Vector2((positions[19].X + 37), positions[19].Y + 33));
            drawLine(new Vector2((positions[19].X + 37), positions[19].Y + 33), new Vector2((positions[8].X + 37), positions[8].Y + 33));
            drawLine(new Vector2((positions[8].X + 37), positions[8].Y + 33), new Vector2((positions[18].X + 37), positions[18].Y + 33));
            drawLine(new Vector2((positions[18].X + 37), positions[18].Y + 33), new Vector2((positions[9].X + 37), positions[9].Y + 33));
            drawLine(new Vector2((positions[9].X + 37), positions[9].Y + 33), new Vector2((positions[15].X + 37), positions[15].Y + 33));
            drawLine(new Vector2((positions[15].X + 37), positions[15].Y + 33), new Vector2((positions[5].X + 37), positions[5].Y + 33));

            // Outer
            drawLine(new Vector2((positions[10].X + 37), positions[10].Y + 33), new Vector2((positions[11].X + 37), positions[11].Y + 33));
            drawLine(new Vector2((positions[11].X + 37), positions[11].Y + 33), new Vector2((positions[12].X + 37), positions[12].Y + 33));
            drawLine(new Vector2((positions[12].X + 37), positions[12].Y + 33), new Vector2((positions[13].X + 37), positions[13].Y + 33));
            drawLine(new Vector2((positions[13].X + 37), positions[13].Y + 33), new Vector2((positions[14].X + 37), positions[14].Y + 33));
            drawLine(new Vector2((positions[14].X + 37), positions[14].Y + 33), new Vector2((positions[10].X + 37), positions[10].Y + 33));

            // Outer and Middle
            drawLine(new Vector2((positions[10].X + 37), positions[10].Y + 33), new Vector2((positions[5].X + 37), positions[5].Y + 33));
            drawLine(new Vector2((positions[11].X + 37), positions[11].Y + 33), new Vector2((positions[6].X + 37), positions[6].Y + 33));
            drawLine(new Vector2((positions[12].X + 37), positions[12].Y + 33), new Vector2((positions[7].X + 37), positions[7].Y + 33));
            drawLine(new Vector2((positions[13].X + 37), positions[13].Y + 33), new Vector2((positions[8].X + 37), positions[8].Y + 33));
            drawLine(new Vector2((positions[14].X + 37), positions[14].Y + 33), new Vector2((positions[9].X + 37), positions[9].Y + 33));

            // Middle and Inner
            drawLine(new Vector2((positions[15].X + 37), positions[15].Y + 33), new Vector2((positions[2].X + 37), positions[2].Y + 33));
            drawLine(new Vector2((positions[16].X + 37), positions[16].Y + 33), new Vector2((positions[3].X + 37), positions[3].Y + 33));
            drawLine(new Vector2((positions[17].X + 37), positions[17].Y + 33), new Vector2((positions[4].X + 37), positions[4].Y + 33));
            drawLine(new Vector2((positions[18].X + 37), positions[18].Y + 33), new Vector2((positions[1].X + 37), positions[1].Y + 33));
            drawLine(new Vector2((positions[19].X + 37), positions[19].Y + 33), new Vector2((positions[0].X + 37), positions[0].Y + 33));

            // Draw the pieces
            foreach (Sprite piece in pieces)
            {
                piece.Draw(gameTime, spriteBatch);
            }

            // Draw buttons
            move.Draw(gameTime, spriteBatch);
            shoot.Draw(gameTime, spriteBatch);
            quit.Draw(gameTime, spriteBatch);

            // Draw border for text
            border.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void drawLine(Vector2 p1, Vector2 p2)
        {
            float angle = (float)Math.Atan2(p1.Y - p2.Y, p1.X - p2.X);
            float distance = Vector2.Distance(p1, p2);

            spriteBatch.Draw(
                dot,
                new Rectangle((int)p2.X, (int)p2.Y, (int)distance, 1),
                null,
                Color.White,
                angle, Vector2.Zero,
                SpriteEffects.None,
                0
            );
        }
    }
}
