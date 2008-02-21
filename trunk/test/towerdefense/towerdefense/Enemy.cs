using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace towerdefense
{
    class Enemy
    {
       
        private Vector2 location;
        private Vector2 destination;
        private int health;
        private int speed;
        private int managerIndex;


        public Enemy(int newhealth, int newspeed, int index)
        {

            managerIndex = index;
            health = newhealth;
            speed = newspeed;
        }

        #region getset
        public int getSpeed()
        {
            return this.speed;
        }

        public void setLocation(Vector2 newLoc)
        {
            this.location = newLoc;
        }

        public void setDestination(Vector2 newDest)
        {
            this.destination = newDest;
        }

        public float getLocX()
        {
            return this.location.X;
        }

        public float getLocY()
        {
            return this.location.Y;
        }

        public Vector2 getLoc()
        {
            return this.location;
        }

        public float getDestX()
        {
            return this.destination.X;
        }

        public float getDestY()
        {
            return this.destination.Y;
        }

        public int getManagerIndex()
        {
            return this.managerIndex;
        }
        #endregion

    }
}
