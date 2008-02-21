using System;
using System.Collections;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;


namespace towerdefense
{
    class EnemyManager
    {
        private ArrayList enemies;

        private const int defaultEnemyHealth = 10;
        private const int defaultEnemySpeed = 2;

        public EnemyManager()
        {
            enemies = new ArrayList();
        }


        public ArrayList getEnemyList()
        {
            return this.enemies;
        }

        public void moveEnemies()
        {
            Enemy curEnemy;
            float dx, dy;

            for (int i = 0; i < enemies.ToArray().Length; i++)
            {
                curEnemy = (Enemy)(enemies.ToArray().GetValue(i));

                dx = curEnemy.getLocX() - curEnemy.getDestX();
                dy = curEnemy.getLocY() - curEnemy.getDestY();

                curEnemy.setLocation(new Vector2(curEnemy.getLocX() - (curEnemy.getSpeed() * dx / (Math.Abs(dx) + Math.Abs(dy))),
                    curEnemy.getLocY() - (curEnemy.getSpeed() * dy / (Math.Abs(dx) + Math.Abs(dy)))));

            }

        }

        public void spawnEnemies(int numEnemiesToSpawn, Rectangle areaToSpawn)
        {
            Enemy curEnemy;
            //spawn enemies one by one in specified rectangle
            for (int i = 0; i < numEnemiesToSpawn; i++)
            {
                addEnemy();
                curEnemy = (Enemy)enemies.ToArray().GetValue(i);
                //fix this for area in a rectangle
                //curEnemy.setLocation(areaToSpawn);                
                curEnemy.setDestination(new Vector2(685, 260));
                
            }

        }

        public void spawnEnemies(int numEnemiesToSpawn, Vector2 areaToSpawn)
        {
            Enemy curEnemy;
            Random rand = new Random();

            //spawn enemies at or around the given Vector2
            for (int i = 0; i < numEnemiesToSpawn; i++)
            {
                addEnemy();
                curEnemy = (Enemy)enemies.ToArray().GetValue(i);
                curEnemy.setLocation(new Vector2(areaToSpawn.X + rand.Next(30), areaToSpawn.Y + rand.Next(30)));
                curEnemy.setDestination(new Vector2(685,260));
                
            }
        }

        public void removeEnemy(int index)
        {
            enemies.RemoveAt(index);
        }

        public void addEnemy()
        {
            //add an enemy to end of arraylist with default health, default speed, and manager index of 1 + last enemy's manager index in the arraylist
            //** MIGHT HAVE PROBLEM IF ARRAY IS ZERO BASED AND USING LENGTH GIVES OUT OF BOUND EXCEPTION **//
            if (enemies.ToArray().Length == 0)
            {
                enemies.Add(new Enemy(defaultEnemyHealth, defaultEnemySpeed, 0));
            }
            else {
                enemies.Add(new Enemy(defaultEnemyHealth, defaultEnemySpeed,
                    ((Enemy)(enemies.ToArray().GetValue((enemies.ToArray().Length - 1)))).getManagerIndex() + 1));
            }
        }

    }
}
