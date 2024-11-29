using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game.Components
{
    public class ProbabilityCalculation
    {
        public double[,] probabilities;
        public TableGenerator table;
        public void CalculateProbabilities(List<Dice> dices)
        {
            int n = dices.Count;
            probabilities = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        probabilities[i, j] = CalculateWinProbability(dices[i], dices[j]);
                    }
                    else
                    {
                        probabilities[i, j] = 0;
                    }
                }
            }
            table = new TableGenerator(probabilities, dices);
        }
        private double CalculateWinProbability(Dice diceA, Dice diceB)
        {
            int wins = 0;
            int totalRolls = diceA.faces.Count * diceB.faces.Count;

            foreach (int faceA in diceA.faces)
            {
                foreach (int faceB in diceB.faces)
                {
                    if (faceA > faceB)
                    {
                        wins++;
                    }
                }
            }

            return (double)wins / totalRolls;
        }
    }
}
