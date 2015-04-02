using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D5_Scripts.Enemies;

namespace D5_Test
{
    [TestClass]
    public class EnemyHealthTest
    {
        [TestMethod]
        public void TestEnemyStartingHealth()
        {
            EnemyHealth enemHealth = new EnemyHealth();
            int actual = enemHealth.getHealth();
            int expected = 100;
            Assert.AreEqual<int>(expected, actual, "This is not the Enemy's Starting Health");
        }

        [TestMethod]
        public void TestEnemyIfAlive_New()
        {
            EnemyHealth enemHealth = new EnemyHealth();
            bool actual = enemHealth.checkDead();
            bool expected = false;
            Assert.AreEqual<bool>(expected, actual, "Enemy is Already Dead");
        }

        [TestMethod]
        public void TestEnemyIfAlive_Damaged()
        {
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(-25);
            bool actual = enemHealth.checkDead();
            bool expected = false;
            Assert.AreEqual<bool>(expected, actual, "Enemy should not be dead yet");
        }

        [TestMethod]
        public void TestEnemyIfAlive_Dead()
        {
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(enemHealth.getHealth());
            bool actual = enemHealth.checkDead();
            bool expected = true;
            Assert.AreEqual<bool>(expected, actual, "Enemy should  be dead");
        }

        [TestMethod]
        public void TestEnemyHealth_DamageNeg()
        {
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(-25);
            int actual = enemHealth.getHealth();
            int expected = 75;
            Assert.AreEqual<int>(expected, actual, "Enemy not losing health properly");
        }

        [TestMethod]
        public void TestEnemyHealth_DamagePos()
        {
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(25);
            int actual = enemHealth.getHealth();
            int expected = 75;
            Assert.AreEqual<int>(expected, actual, "Enemy should not gain health");
        }

        [TestMethod]
        public void TestEnemyGivePoints_Alive()
        {
            EnemyHealth enemHealth = new EnemyHealth();
            int actual = enemHealth.givePoints();
            int expected = 0;
            Assert.AreEqual<int>(expected, actual, "Enemy should not give points if alive");
        }

        [TestMethod]
        public void TestEnemyGivePoints_Damaged()
        {
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(-25);
            int actual = enemHealth.givePoints();
            int expected = 0;
            Assert.AreEqual<int>(expected, actual, "Enemy should not give points if alive");
        }

        [TestMethod]
        public void TestEnemyGivePoints_Dead()
        {
            EnemyHealth enemHealth = new EnemyHealth();
            enemHealth.updateHealth(-enemHealth.getHealth());
            int actual = enemHealth.givePoints();
            int expected = 100;
            Assert.AreEqual<int>(expected, actual, "Enemy not giving points when dead");
        }


    }
}
