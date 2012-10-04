/************************************************************************************************** 
* Game
* 
* Author: Sean Malone
* 
* Description: This class brings all of the other classes together into a single game class. This
*              class has many static properties, so they can be accessed through the class instead
*              of individual instances. 
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusGraphic
{
    class Board
    {
        /******************************************************************************************
         * Attributes
         * 
         * @property map        - Map holding all the rooms.
         * @property wumpus     - The Wumpus
         * @property player     - The Player
         * @property superbats  - 2 Superbats
         * @property pits       - 2 Pits
         * @property randomMove - Was the player randomly moved?
         *****************************************************************************************/
        private static Map map;
        private static Wumpus wumpus;
        private static Player player;
        private static Hazard[] superbats;
        private static Hazard[] pits;
        private static bool randomMove;
        private static string message;

        /******************************************************************************************
         * Constructors
         *****************************************************************************************/
        // No parameters
        public Board()
        {
            map = new Map();
            wumpus = new Wumpus();
            player = new Player();
            superbats = new Hazard[]{
                new Hazard("superbat"),
                new Hazard("superbat"),
            };
            pits = new Hazard[] {
                new Hazard("pit"),
                new Hazard("pit"),
            };

            message = "";

            // Initialize the game pieces
            initBoard();
        }

        /******************************************************************************************
         * Map Property
         * 
         * This property is static to allow for all other classes to get the rooms from the Map
         * object in this class. It is read-only.
         *****************************************************************************************/
        public static Map Map
        {
            get
            {
                return map;
            }

        } // End Map

        /******************************************************************************************
         * Wumpus Property
         * 
         * This property is static to allow for all other classes to access the Wumpus object.
         *****************************************************************************************/
        public static Wumpus Wumpus
        {
            get
            {
                return wumpus;
            }
            set
            {
                wumpus = value;
            }

        } // End Wumpus

        /******************************************************************************************
         * Player Property
         * 
         * This property is static to allow for all other classes to access the Player object.
         *****************************************************************************************/
        public static Player Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }

        } // End Player

        /******************************************************************************************
         * Superbats Property
         * 
         * This property is static to allow for all other classes to access the superbats array.
         *****************************************************************************************/
        public static Hazard[] Superbats
        {
            get
            {
                return superbats;
            }
            set
            {
                superbats = value;
            }

        } // End Superbats

        /******************************************************************************************
         * Pits Property
         * 
         * This property is static to allow for all other classes to access the sits array.
         *****************************************************************************************/
        public static Hazard[] Pits
        {
            get
            {
                return pits;
            }
            set
            {
                pits = value;
            }
        } // End Pits

        /******************************************************************************************
         * Randonly moved Property
         * 
         * Was the player randomly moved? Used for status Board.Messages.
         *****************************************************************************************/
        public static bool RandomMove
        {
            get
            {
                return randomMove;
            }
            set
            {
                randomMove = value;
            }

        } // End Status

        /******************************************************************************************
         * Initialize each game piece
         * 
         * @property random - Random number generator
         * @property room   - Temporary room holder
         * 
         * Initialize each piece in the following order:
         * 1. Wumpus
         * 2. Superbats
         * 3. Pits
         * 4. Player
         * 
         * When a room is chosen, it can not be a room where another game piece resides.
         *****************************************************************************************/
        public static void initBoard()
        {
            Random random = new Random();
            Room room = map[random.Next(1, 20)];
            
            // Add Wumpus
            wumpus.Room = room;
            room.Wumpus = true;

            // Add first Superbat
            while (room.Number == wumpus.Room.Number)
            {
               room = map[random.Next(1,20)];
            }
            superbats[0].Room = room;
            room.Hazard = superbats[0];

            // Add second Superbat
            while (room.Number == wumpus.Room.Number || room.Number == superbats[0].Room.Number)
            {
                room = map[random.Next(1, 20)];
            }
            superbats[1].Room = room;
            room.Hazard = superbats[1];
            
            // Add first pit
            while (room.Number == wumpus.Room.Number || room.Number == superbats[0].Room.Number
                || room.Number == superbats[1].Room.Number)
            {
                room = map[random.Next(1, 20)];
            }
            pits[0].Room = room;
            room.Hazard = pits[0];
            
            // Add second pit
            while (room.Number == wumpus.Room.Number || room.Number == superbats[0].Room.Number
                || room.Number == superbats[1].Room.Number || room.Number == pits[0].Room.Number)
            {
                room = map[random.Next(1, 20)];
            }
            pits[1].Room = room;
            room.Hazard = pits[1];
            
            // Add Player
            while (room.Number == wumpus.Room.Number || room.Number == superbats[0].Room.Number
                || room.Number == superbats[1].Room.Number || room.Number == pits[0].Room.Number
                || room.Number == pits[1].Room.Number)
            {
                room = map[random.Next(1, 20)];
            }
            player.Room = room;
            room.Player = true;
            
        } // End init board

        /******************************************************************************************
         * Move Player Randomly
         * 
         * @property random   - Random number generator
         * @property room     - A random room to move the player
         * 
         * If the player enters a room with a Superbat, the Superbat moves the player to a random
         * room.
         *****************************************************************************************/
        public static void movePlayerRandom()
        {
            // Remove player from current room
            Board.Player.Room.Player = false;

            Random random = new Random();
            Room room = map[random.Next(1, 20)];

            // Keep looping to find a random room that does not contain any other entity. 
            while (room.Number == wumpus.Room.Number || room.Number == superbats[0].Room.Number
                || room.Number == superbats[1].Room.Number || room.Number == pits[0].Room.Number
                || room.Number == pits[1].Room.Number)
            {
                room = map[random.Next(1, 20)];
            }

            player.Room = room;
            room.Player = true;

            randomMove = true;
        } // End move player randomly

        public static void play()
        {
            
        }
    } // End Game
} // End Document
