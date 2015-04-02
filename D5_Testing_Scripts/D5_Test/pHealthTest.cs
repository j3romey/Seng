using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D5_Scripts.Player;

namespace D5_Test
{
    [TestClass]
    public class pHealthTest
    {
        [TestMethod]
        public void TestPlayerStartingHealth()
        {
            pHealth playerHealth = new pHealth();
            int actual = playerHealth.getHealth();
            int expected = 100;
            Assert.AreEqual<int>(expected, actual, "This is not the Player's Starting Health");
        }

        [TestMethod]
        public void TestPlayerMaxHealth()
        {
            pHealth playerHealth = new pHealth();
            int actual = playerHealth.getMax();
            int expected = 100;
            Assert.AreEqual<int>(expected, actual, "This is not the Player's MaxHealth");
        }

        [TestMethod]
        public void TestPlayerIfAlive()
        {
            pHealth playerHealth = new pHealth();
            bool actual = playerHealth.checkDead();
            bool expected = false;
            Assert.AreEqual<bool>(expected, actual, "Player is already Dead");
        }

        public void TestPlayerIfDead()
        {
            pHealth playerHealth = new pHealth();
            playerHealth.updateHealth(-playerHealth.getHealth());
            bool actual = playerHealth.checkDead();
            bool expected = true;
            Assert.AreEqual<bool>(expected, actual, "Player is still alive");
        }

        [TestMethod]
        public void TestPlayerMoreThanMaxHealth()
        {
            pHealth playerHealth = new pHealth();
            playerHealth.updateHealth(100);
            int actual = playerHealth.getHealth();
            int expected = 100;
            Assert.AreEqual<int>(expected, actual, "Player Health above maxHealth");
        }

        [TestMethod]
        public void TestPlayerHealthBelowZero()
        {
            pHealth playerHealth = new pHealth();
            playerHealth.updateHealth(-200);
            int actual = playerHealth.getHealth();
            int expected = 0;
            Assert.AreEqual<int>(expected, actual, "Player Health is negative");
        }

        [TestMethod]
        public void TestPlayerHealthLowersAsExpected()
        {
            // Player intial health set at 100
            pHealth playerHealth = new pHealth();
            playerHealth.updateHealth(-25);
            int actual = playerHealth.getHealth();
            int expected = 75;
            Assert.AreEqual<int>(expected, actual, "Player Health is negative");
        }

        [TestMethod]
        public void TestPlayerHealthIncreasesAsExpected()
        {
            // if player gets more health will it add up properly
            pHealth playerHealth = new pHealth();
            playerHealth.updateHealth(-50);
            playerHealth.updateHealth(25);
            int actual = playerHealth.getHealth();
            int expected = 75;
            Assert.AreEqual<int>(expected, actual, "Player Health is negative");
        }

        [TestMethod]
        public void TestPlayerStayDeadAfterHeal()
        {
            // if player gets more health will it add up properly
            pHealth playerHealth = new pHealth();
            playerHealth.updateHealth(-playerHealth.getHealth());
            playerHealth.updateHealth(25);
            int actual = playerHealth.getHealth();
            int expected = 0;
            Assert.AreEqual<int>(expected, actual, "Player is a ZOMBIE D;");
        }
    }
}
