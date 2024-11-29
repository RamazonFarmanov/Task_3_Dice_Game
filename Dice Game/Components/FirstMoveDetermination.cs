using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game.Components
{
    public class FirstMoveDetermination
    {
        public void Determination(List<int> process_state, ProbabilityCalculation probability)
        {
            int value = 0;
            string selection = "";
            RandomValueGenerator random = new RandomValueGenerator();
            HMACGenerator hmac = new HMACGenerator();
            string _hmac = "";
            value = random.Generate(2, -1);
            _hmac = hmac.CalculateHMAC(Convert.ToString(value));
            Console.WriteLine($"I wished for a number. (HMAC={_hmac})");
            while (true)
            {
                Console.WriteLine("Try to guess my selection.");
                for (int i = 0; i <= 1; i++)
                {
                    Console.WriteLine($"{i} - {i}");
                }
                Console.WriteLine("X - exit\n? - help\nYour selection: ");
                selection = Convert.ToString(Console.ReadLine());
                if (selection != null)
                {
                    if (int.TryParse(selection, out int result))
                    {
                        if (result == value && result <= 1 && result > -1)
                        {
                            Console.WriteLine($"You guessed the right number! You make the first moove! (KEY={hmac.key})");
                            process_state[1] = 1;
                            break;
                        }
                        else if (result != value && result <= 1 && result > -1)
                        {
                            Console.WriteLine($"You lost! My selection was {value}. (KEY={hmac.key}). I make the first move");
                            process_state[1] = 2;
                            break;
                        }
                        else { Console.WriteLine("Incorrect input. Try again!"); }
                    }
                    else if (selection.ToLower() == "x")
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
