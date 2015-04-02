using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D5_Scripts.Enemies
{
    public class EnemyAttack
    {
        // variables related to enemy attack
        private int damage = -5;


        // code that returns damage, as long as 
        // attack is not on cooldown
        public int giveDmg()
        {
            return damage;
        }
    }
}