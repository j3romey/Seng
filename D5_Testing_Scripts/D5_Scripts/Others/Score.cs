using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D5_Scripts.Others
{
    public class Score
    {
        private int score = 0;

        public void updateScore(int add)
        {
            score += add;
        }

        public int returnScore()
        {
            return score;
        }
    }
}
