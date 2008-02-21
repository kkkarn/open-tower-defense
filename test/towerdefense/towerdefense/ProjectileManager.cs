using System;
using System.Collections;
using System.Text;
using Microsoft.Xna.Framework;


namespace towerdefense
{
    class ProjectileManager
    {
        private ArrayList projectiles;

        public ProjectileManager()
        {
            projectiles = new ArrayList();
        }

        public ArrayList getProjLost()
        {
            return this.projectiles;
        }

        public void moveProjectiles()
        {
            Projectile curProj;
            float dx, dy;

            for (int i = 0; i < projectiles.ToArray().Length; i++)
            {
                curProj = (Projectile)(projectiles.ToArray().GetValue(i));

                dx = curProj.getLocation().X - curProj.getDestination().X;
                dy = curProj.getLocation().Y - curProj.getDestination().Y;

                curProj.setLocation(new Vector2(curProj.getLocation().X - (curProj.getSpeed() * dx / (Math.Abs(dx) + Math.Abs(dy))),
                    curProj.getLocation().Y - (curProj.getSpeed() * dy / (Math.Abs(dx) + Math.Abs(dy)))));

            }
        }

        public void spawnProjectile(Vector2 origin, Vector2 target, dmgType type, int speed, int damage, int enemyIndex)
        {
            projectiles.Add(new Projectile(speed, damage, type, origin, target, enemyIndex));
        }

        

    }
}
