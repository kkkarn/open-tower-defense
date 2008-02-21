using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace towerdefense
{

    public enum dmgType { normal, frost };

    class Projectile
    {
        int speed, damage;
        Vector2 location, destination;
        dmgType ammoType;
        int enemyIndex;

        public Projectile(int newSpeed, int newDamage, dmgType newAmmoType, Vector2 startLoc, Vector2 enemyLoc, int newEnemyIndex)
        {
            speed = newSpeed;
            damage = newDamage;
            ammoType = newAmmoType;
            location = startLoc;
            destination = enemyLoc;
            enemyIndex = newEnemyIndex;
        }

        #region getset
        public void setLocation(Vector2 newLoc)
        {
            this.location = newLoc;
        }

        public Vector2 getLocation()
        {
            return this.location;
        }

        public void setLocX(int newX)
        {
            this.location.X = newX;
        }

        public void setLocY(int newY)
        {
            this.location.Y = newY;
        }

        public void setDestination(Vector2 newDest)
        {
            this.destination = newDest;
        }

        public Vector2 getDestination()
        {
            return this.destination;
        }

        public void setDestX(int newX)
        {
            this.destination.X = newX;
        }

        public void setDestY(int newY)
        {
            this.destination.Y = newY;
        }

        public int getSpeed()
        {
            return this.speed;
        }

        public int getDamage()
        {
            return this.damage;
        }

        public dmgType getDmgType()
        {
            return this.ammoType;
        }

        #endregion

    }
}
