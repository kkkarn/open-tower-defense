using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace towerdefense
{
    public enum towerType { regular, ice };

    class Tower
    {
        private Vector2 location;
        private int rof; //rate of fire
        private int range;
        private Enemy curTarget;
        private towerType thisType;
        

        public Tower(Vector2 newLocation, int newrof, int newrange)
        {
            location = newLocation;
            rof = newrof;
            range = newrange;
            curTarget = null;

        }

        public Tower(Vector2 newLocation, int type)
        {
            location = newLocation;
            switch (type)
            {
                case (int)towerType.regular:
                    thisType = towerType.regular;
                    rof = 1;
                    range = 100;
                    break;
                case (int)towerType.ice:
                    thisType = towerType.ice;
                    rof = 3;
                    range = 75;
                    break;
            }

        }

        public Vector2 getLoc()
        {
            return location;
        }

        public towerType getType()
        {
            return thisType;
        }

    }
}
