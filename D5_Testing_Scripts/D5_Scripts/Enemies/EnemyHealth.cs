using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D5_Scripts.Enemies
{
    public class EnemyHealth
    {
        private int curHealth;
        private int maxHealth;
        private int points;
        private bool isDead;

        public EnemyHealth()
        {
            curHealth = 100;
            maxHealth = 100;
            isDead = false;
            points = 100;
        }

        // getters
        public int getMax()
        {
            return maxHealth;
        }

        public int getHealth()
        {
            return curHealth;
        }

        public bool checkDead()
        {
            if (curHealth <= 0)
                isDead = true;
            else
                isDead = false;

            return isDead;
        }

        public int givePoints()
        {
            if (checkDead())
            {
                return points;
            }
            else
            {
                return 0;
            }
        }


        // used to update the health of enemy 
        // (when attacked by player)
        public void updateHealth(int hp)
        {

            if (hp > 0)
                hp = hp * -1;

            curHealth += hp;

            if (curHealth < 0)
                curHealth = 0;

            if (curHealth > maxHealth)
                curHealth = maxHealth;
        }
    }
}