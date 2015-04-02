using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D5_Scripts.Enemies;
using D5_Scripts.Player;

namespace D5_Test
{
    [TestClass]
    public class PlayerAttackEnemyTest
    {
        [TestMethod]
        public void TestPlayerDamageEnem_New()
        {
            pAttack playerAtt = new pAttack();
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(playerAtt.giveDmg());
            int actual = enemHealth.getHealth();
            int expected = 75;
            Assert.AreEqual<int>(expected, actual, "Enemy health not lowering properly");
        }

         [TestMethod]
        public void TestPlayerDamageEnem_Damaged()
        {
            pAttack playerAtt = new pAttack();
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(playerAtt.giveDmg());
            enemHealth.updateHealth(playerAtt.giveDmg());
            enemHealth.updateHealth(playerAtt.giveDmg());
            int actual = enemHealth.getHealth();
            int expected = 25;
            Assert.AreEqual<int>(expected, actual, "Enemy health not lowering properly");
        }

         [TestMethod]
        public void TestPlayerDamageEnem_Dead()
        {
            pAttack playerAtt = new pAttack();
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(enemHealth.getHealth());
            int actual = enemHealth.getHealth();
            int expected = 0;
            Assert.AreEqual<int>(expected, actual, "Enemy still losing health when dead");
        }

         [TestMethod]
        public void TestPlayerKillEnem_Damage()
        {
            pAttack playerAtt = new pAttack();
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(playerAtt.giveDmg());
            bool actual = enemHealth.checkDead();
            bool expected = false;
            Assert.AreEqual<bool>(expected, actual, "Enemy considered dead when it shouldnt be");
        }

         [TestMethod]
        public void TestPlayerKillEnem_Dead()
        {
            pAttack playerAtt = new pAttack();
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(playerAtt.giveDmg());
            enemHealth.updateHealth(playerAtt.giveDmg());
            enemHealth.updateHealth(playerAtt.giveDmg());
            enemHealth.updateHealth(playerAtt.giveDmg());
            bool actual = enemHealth.checkDead();
            bool expected = true;
            Assert.AreEqual<bool>(expected, actual, "Enemy not considered dead when should be");
        }


    }
}
