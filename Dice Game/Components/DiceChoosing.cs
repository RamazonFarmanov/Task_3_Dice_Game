using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game.Components
{
    public class DiceChoosing
    {
        public void Choose(List<Dice> dices, List<int> process_state, ProbabilityCalculation probability)
        {
            if (process_state[1] == 1)
            {
                PlayerChooseDice(dices, process_state, probability);
                if (process_state[0] == 1)
                {
                    ComputerChooseDice(dices, process_state);
                }
            }
            else
            {
                ComputerChooseDice(dices, process_state);
                PlayerChooseDice(dices, process_state, probability);
            }
        }
        public static void ComputerChooseDice(List<Dice> dices, List<int> process_state)
        {
            RandomValueGenerator random = new RandomValueGenerator();
            process_state[3] = random.Generate(dices.Count, process_state[2]);
            Console.WriteLine($"I chose {dices[process_state[3]].GetDice()} dice");
        }
        public static void PlayerChooseDice(List<Dice> dices, List<int> process_state, ProbabilityCalculation probability)
        {
            while (true)
            {
                Console.WriteLine("Choose your dice:");
                for (int i = 0; i < dices.Count; i++)
                {
                    if (i == process_state[3])
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{i} - {dices[i].GetDice()}");
                    }
                }
                Console.WriteLine("X - exit\n? - help\nYour selection: ");
                string selection = Convert.ToString(Console.ReadLine());
                if (selection != null)
                {
                    if (int.TryParse(selection, out int result))
                    {
                        if (result < dices.Count && result > -1 && result != process_state[3])
                        {
                            process_state[2] = result;
                            Console.WriteLine($"You chose {dices[process_state[2]].GetDice()} dice");
                            break;
                        }
                        else if (result == process_state[3])
                        {
                            Console.WriteLine("That dice already have been choosen, choose another one!");
                        }
                        else { Console.WriteLine("Incorrect input. Try again!"); }
                    }
                    else if (selection == "x" || selection == "X")
                    {
                        process_state[0] = 0;
                        break;
                    }
                    else if (selection == "?") { probability.table.Generate(); }
                    else { Console.WriteLine("Incorrect input. Try again!"); }
                }
            }
        }
    }
}
