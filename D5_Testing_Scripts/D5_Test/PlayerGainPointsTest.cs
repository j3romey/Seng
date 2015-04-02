using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D5_Scripts.Player;
using D5_Scripts.Enemies;
using D5_Scripts.Others;


namespace D5_Test
{
    [TestClass]
    public class PlayerGainPointsTest
    {

        [TestMethod]
        public void TestPlayerGainPoints_Damage()
        {
            pAttack playerAtt = new pAttack();
            EnemyHealth enemHealth = new EnemyHealth();
            Score scoreKeeper = new Score();

            enemHealth.updateHealth(playerAtt.giveDmg());
            scoreKeeper.updateScore(enemHealth.givePoints());
            int actual = scoreKeeper.returnScore();
            int expected = 0;
            Assert.AreEqual<int>(expected, actual, "Score is wrong");
        }

        [TestMethod]
        public void TestPlayerGainPoints_KillAndDamage()
        {
            pAttack playerAtt = new pAttack();
            EnemyHealth enemHealth1 = new EnemyHealth();
            EnemyHealth enemHealth2 = new EnemyHealth();

            Score scoreKeeper = new Score();

            enemHealth1.updateHealth(playerAtt.giveDmg());
            enemHealth1.updateHealth(playerAtt.giveDmg());
            enemHealth1.updateHealth(playerAtt.giveDmg());
            enemHealth1.updateHealth(playerAtt.giveDmg());
            scoreKeeper.updateScore(enemHealth1.givePoints());


            enemHealth2.updateHealth(playerAtt.giveDmg());
            scoreKeeper.updateScore(enemHealth2.givePoints());

            int actual = scoreKeeper.returnScore();
            int expected = 100;
            Assert.AreEqual<int>(expected, actual, "Score is wrong");
        }

        [TestMethod]
        public void TestPlayerGainPoints_Kill()
        {
            pAttack playerAtt = new pAttack();
            EnemyHealth enemHealth = new EnemyHealth();
            Score scoreKeeper = new Score();
            enemHealth.updateHealth(playerAtt.giveDmg());
            enemHealth.updateHealth(playerAtt.giveDmg());
            enemHealth.updateHealth(playerAtt.giveDmg());
            enemHealth.updateHealth(playerAtt.giveDmg());
            scoreKeeper.updateScore(enemHealth.givePoints());
            int actual = scoreKeeper.returnScore();
            int expected = 100;
            Assert.AreEqual<int>(expected, actual, "Score is wrong");
        }

        [TestMethod]
        public void TestPlayerGainPoints_Killx10()
        {
            Score scoreKeeper = new Score();
            pAttack playerAtt = new pAttack();
            for(int i = 0; i < 10; i++){
               
                EnemyHealth enemHealth = new EnemyHealth();
            
                enemHealth.updateHealth(playerAtt.giveDmg());
                enemHealth.updateHealth(playerAtt.giveDmg());
                enemHealth.updateHealth(playerAtt.giveDmg());
                enemHealth.updateHealth(playerAtt.giveDmg());
                scoreKeeper.updateScore(enemHealth.givePoints());
             }
            int actual = scoreKeeper.returnScore();
            int expected = 1000;
            Assert.AreEqual<int>(expected, actual, "Score is wrong");
        }
    }
}
