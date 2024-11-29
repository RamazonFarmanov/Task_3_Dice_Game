namespace Dice_Game.Components
{
    public class RandomValueGenerator
    {
        public int Generate(int range, int forbidden)
        {
            Random random = new Random();
            int value;
            do
            {
                value = random.Next(0, range);
            } while (value == forbidden);
            return value;
        }
    }
}
