using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D5_Scripts.Enemies;
using D5_Scripts.Player;


namespace D5_Test
{
    [TestClass]
    public class EnemyAttackPlayerTest
    {
        [TestMethod]
        public void TestEnemyDamagePlayer_Full()
        {
            EnemyAttack enemAttack = new EnemyAttack();
            pHealth playerHealth = new pHealth();
            playerHealth.updateHealth(enemAttack.giveDmg());
            int actual = playerHealth.getHealth();
            int expected = 95;
            Assert.AreEqual<int>(expected, actual, "Player health not lowering properly");
        }

        [TestMethod]
        public void TestEnemyDamagePlayer_Damaged()
        {
            EnemyAttack enemAttack = new EnemyAttack();
            pHealth playerHealth = new pHealth();
            playerHealth.updateHealth(enemAttack.giveDmg());
            playerHealth.updateHealth(enemAttack.giveDmg());
            playerHealth.updateHealth(enemAttack.giveDmg());
            int actual = playerHealth.getHealth();
            int expected = 85;
            Assert.AreEqual<int>(expected, actual, "Player health not lowering properly");
        }

        [TestMethod]
        public void TestEnemyDamagePlayer_Dead()
        {
            EnemyAttack enemAttack = new EnemyAttack();
            pHealth playerHealth = new pHealth();
            int i = (playerHealth.getHealth() / enemAttack.giveDmg());
            int totalDamage = Math.Abs(i) * enemAttack.giveDmg();
            playerHealth.updateHealth(totalDamage);
            int actual = playerHealth.getHealth();
            int expected = 0;
            Assert.AreEqual<int>(expected, actual, "Player should have 0 health");
        }

        [TestMethod]
        public void TestEnemyDamagePlayer_Overkill()
        {
            EnemyAttack enemAttack = new EnemyAttack();
            pHealth playerHealth = new pHealth();
            playerHealth.updateHealth(-playerHealth.getHealth());
            playerHealth.updateHealth(enemAttack.giveDmg());
            int actual = playerHealth.getHealth();
            int expected = 0;
            Assert.AreEqual<int>(expected, actual, "Player should not have less than 0 health");
        }

        [TestMethod]
        public void TestEnemyKillPlayer_Damaged()
        {
            EnemyAttack enemAttack = new EnemyAttack();
            pHealth playerHealth = new pHealth();
            playerHealth.updateHealth(enemAttack.giveDmg());
            playerHealth.updateHealth(enemAttack.giveDmg());
            playerHealth.updateHealth(enemAttack.giveDmg());
            bool actual = playerHealth.checkDead();
            bool expected = false;
            Assert.AreEqual<bool>(expected, actual, "Player should not be dead yet");
        }

        [TestMethod]
        public void TestEnemyKillPlayer_Dead()
        {
            EnemyAttack enemAttack = new EnemyAttack();
            pHealth playerHealth = new pHealth();
            int i = (playerHealth.getHealth() / enemAttack.giveDmg());
            int totalDamage = Math.Abs(i) * enemAttack.giveDmg();
            playerHealth.updateHealth(totalDamage);
            bool actual = playerHealth.checkDead();
            bool expected = true;
            Assert.AreEqual<bool>(expected, actual, "Player should be dead");
        }
    }
}