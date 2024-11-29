using Dice_Game.Components;
using Org.BouncyCastle.Utilities;
class Program
{
    public static void Main(string[] args)
    {
        var dices = new List<Dice>();
        var process_state = new List<int>() { 1, 0, -1, -1, 0, -1, -1 };
        DicesConfigurator configurator = new DicesConfigurator();
        configurator.Configurate(args, dices, process_state);
        if (process_state[0] == 0)
        {
            Console.WriteLine("- Your arguments input must contain of only integer numbers, which will be faces of dices" +
                "\n- Each number (face) must be separated from other with ','" +
                "\n- Each dice must be separated with ' ' (space)" +
                "\n- Dices could be with different amount of faces" +
                "\n- You need at least 3 dices to play" +
                "\n- Example of correct input: 1,2,3,4,5,6 1,2,3,4,5,6,7,8 7,3,1,");
        }
        while (process_state[0] == 1)
        {
            Console.WriteLine("-----------------------------------------------------------NEW GAME-----------------------------------------------------------");
            ProbabilityCalculation probability = new ProbabilityCalculation();
            probability.CalculateProbabilities(dices);
            FirstMoveDetermination firstMove = new FirstMoveDetermination();
            FairNumberGeneration final = new FairNumberGeneration();
            DiceChoosing diceChoosing = new DiceChoosing();
            firstMove.Determination(process_state, probability);
            if (process_state[0] == 0) { break; }
            diceChoosing.Choose(dices, process_state, probability);
            if (process_state[0] == 0) { break; }
            final.Throws(dices, process_state, probability);
            if (process_state[0] == 0) { break; }
            process_state = new List<int> { 1, 0, -1, -1, 0, -1, -1 };
        }
    }
}