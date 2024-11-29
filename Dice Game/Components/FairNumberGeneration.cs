namespace Dice_Game.Components
{
    public class FairNumberGeneration
    {
        public void Throws(List<Dice> dices, List<int> process_state, ProbabilityCalculation probability)
        {
            HMACGenerator hmac = new HMACGenerator();
            int work_on_it = 0;
            for (int i = 0; i < 2; i++) 
            {
                ComputerChooseNumber(dices, process_state, hmac, ref work_on_it);
                PlayerChooseNumber(dices, process_state, hmac, ref work_on_it, probability);
                if (process_state[0] == 0) { break; }
            }
            if (process_state[0] == 1)
            {
                if (process_state[5] > process_state[6])
                {
                    Console.WriteLine($"{process_state[5]} > {process_state[6]}\nYou won!!!");
                }
                else if (process_state[5] < process_state[6])
                {
                    Console.WriteLine($"{process_state[5]} < {process_state[6]}\nYou lost!");
                }
                else
                {
                    Console.WriteLine($"{process_state[5]} = {process_state[6]}\nIt's draw!");
                }
            }
        }
        private void ComputerChooseNumber(List<Dice> dices, List<int> process_state, HMACGenerator hmac, ref int work_on_it)
        {
            RandomValueGenerator random = new RandomValueGenerator();
            if ((process_state[1] == 1 && process_state[5] == -1) || (process_state[1] == 2 && process_state[6] != -1))
            {
                work_on_it = 2;
                Console.WriteLine("It's time for your throw");
                process_state[4] = random.Generate(dices[process_state[work_on_it]].faces.Count, -1);
                Console.WriteLine($"I generate random value in the range 0 ... {dices[process_state[work_on_it]].faces.Count} (HMAC = {hmac.CalculateHMAC(Convert.ToString(process_state[4]))})");
            }
            else if ((process_state[1] == 1 && process_state[5] != -1) || (process_state[1] == 2 && process_state[6] == -1))
            {
                work_on_it = 3;
                Console.WriteLine("It's time for my throw");
                process_state[4] = random.Generate(dices[process_state[work_on_it]].faces.Count, -1);
                Console.WriteLine($"I generate random value in the range 0 ... {dices[process_state[work_on_it]].faces.Count} (HMAC = {hmac.CalculateHMAC(Convert.ToString(process_state[4]))})");
            }
        }
        private void PlayerChooseNumber(List<Dice> dices, List<int> process_state, HMACGenerator hmac, ref int work_on_it, ProbabilityCalculation probability)
        {
            string selection = "";
            int faces = 0;
            int sum = 0;
            while (true) 
            {
                Console.WriteLine("Choose your number:");
                faces = dices[process_state[work_on_it]].faces.Count;
                for (int i = 0; i < faces; i++)
                {
                    Console.WriteLine($"{i} - {i}");
                }
                Console.WriteLine("X - exit\n? - help\nYour selection: ");
                selection = Convert.ToString(Console.ReadLine());
                if (selection != null)
                {
                    if (int.TryParse(selection, out int result))
                    {
                        if (result < faces && result > -1)
                        {
                            Console.WriteLine($"You chose {result}");
                            Console.WriteLine($"I chose {process_state[4]} (KEY={hmac.key})");
                            sum = result + process_state[4];
                            Console.WriteLine($"{result} + {process_state[4]} = {sum} % {faces} = {sum % faces}");
                            sum = sum % faces;
                            if (work_on_it == 2)
                            {
                                process_state[5] = dices[process_state[work_on_it]].faces.ElementAt(sum);
                                Console.WriteLine($"Your throw is {process_state[5]}");
                            }
                            else
                            {
                                process_state[6] = dices[process_state[work_on_it]].faces.ElementAt(sum);
                                Console.WriteLine($"My throw is {process_state[6]}");
                            }
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
