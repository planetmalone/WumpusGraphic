/************************************************************************************************** 
* Wumpus
* 
* Author: Sean Malone
* 
* Description: This class contains the attributes and behavior for the Wumpus.
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusGraphic
{
    class Wumpus
    {
        /******************************************************************************************
         * Attributes
         * 
         * @property room       - Current room of Wumpus
         * @property awake      - Is the Wumpus awake?
         * @property alive      - Is the Wumpus alive?
         *****************************************************************************************/
        private Room room;
        private bool awake;
        private bool alive;

        /******************************************************************************************
         * Constructors
         *****************************************************************************************/
        //No parameters
        public Wumpus() 
        {
            room = null;
            awake = false;
            alive = true;
        }

        // Room
        public Wumpus(Room room)
        {
            this.room = room;
            awake = false;
            alive = true;
        }

        // Room and Sleep state
        public Wumpus(Room room, bool state)
        {
            this.room = room;
            awake = state;
            alive = true;
        }

        /******************************************************************************************
         * Room Property
         * 
         * Room where the Wumpus resides
         *****************************************************************************************/
        public Room Room
        {
            get
            {
                return room;
            }
            set
            {
                room = value;
            }

        } // End Room

        /******************************************************************************************
         * Awake Property
         * 
         * Is the Wumpus awake?
         *****************************************************************************************/
        public bool Awake
        {
            get
            {
                return awake;
            }
            set
            {
                awake = value;
            }

        } // End Awake

        /******************************************************************************************
         * Alive Property
         * 
         * Is the Wumpus alive?
         *****************************************************************************************/
        public bool Alive
        {
            get
            {
                return alive;
            }
            set
            {
                alive = value;
            }

        } // End Alive

        /******************************************************************************************
         * Move Wumpus
         * 
         * @property random - Random number generator
         * 
         * Once awake, the Wumpus has a 75% chance of moving each turn
         *****************************************************************************************/
        public void move()
        {
            Random random = new Random();

            // Move Wumpus
            if (random.Next(1, 100) >= 25)
            {
                Room oldRoom = room;
                room = room.randomRoom();
                oldRoom.Wumpus = false;
                room.Wumpus = true;
            }

            // Check to see if killed player
            if (room.Number == Board.Player.Room.Number)
            {
                Board.Player.Alive = false;
            }

        } // End move
    } // End Wumpus
} // End Document
