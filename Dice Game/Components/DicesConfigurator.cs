using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game.Components
{
    public class DicesConfigurator
    {
        public void Configurate(string[] args, List<Dice> dices, List<int> process_state)
        {
            if (args == null || args.Length < 3) 
            {
                process_state[0] = 0;
                Console.WriteLine("You need at least 3 dices to play!");
            }
            else 
            {
                foreach (string arg in args)
                {
                    dices.Add(new Dice(arg, process_state));
                }
            }
        }
    }
}
