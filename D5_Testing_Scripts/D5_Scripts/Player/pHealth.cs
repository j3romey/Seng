using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D5_Scripts.Player
{
    public class pHealth
    {
        private int curHealth;// = 100;
        private int maxHealth;// = 100;
        private bool isDead;// = false;

        public pHealth()
        {
            curHealth = 100;
            maxHealth = 100;
            isDead = false;
        }

        // Getters
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
            // sets the bool if player is alive or not
            if (curHealth <= 0)
                isDead = true;
            else
            {
                isDead = false;
            }

            return isDead;
        }

        public void updateHealth(int hp)
        {
            // user cannot gain hp when he reaches 0
            if (curHealth != 0)
                curHealth += hp;
            // hp should not reach negative values
            if (curHealth < 0)
                curHealth = 0;
            // hp should not go over maxHealth	
            if (curHealth > maxHealth)
                curHealth = maxHealth;
        }

    }
}
