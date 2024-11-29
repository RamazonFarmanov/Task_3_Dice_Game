using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game.Components
{
    public class Dice
    {
        public List<int> faces { get; } = new List<int>();
        public Dice(string facesValue, List<int> process_state) 
        {
            foreach(char c in facesValue)
            {
                if(c == ',' || char.GetNumericValue(c) != -1)
                {
                    if (c != ',')
                    {
                        faces.Add((int)char.GetNumericValue(c));
                    }
                }
                else 
                {
                    process_state[0] = 0;
                    Console.WriteLine($"Invalid value in argument: {c}");
                    break;
                }
            }
        }
        public string GetDice()
        {
            string dice = "[";
            for( int i = 0; i < faces.Count; i++)
            {
                if(i == faces.Count - 1)
                {
                    dice = dice + faces[i].ToString() + ']';
                }
                else
                {
                    dice = dice + faces[i].ToString() + ",";
                }
            }
            return dice;
        }
    }
}
