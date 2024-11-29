using ConsoleTables;

namespace Dice_Game.Components
{
    public class TableGenerator
    {
        ConsoleTable table;
        public TableGenerator(double[,] probabilities, List<Dice> dices)
        {
            var headers = new List<string> { "Dice" }; // Заголовок для первой колонки
            for (int j = 0; j < dices.Count; j++)
            {
                headers.Add($"Dice {j + 1}");
            }
            table = new ConsoleTable(headers.ToArray());
            // Добавляем строки с данными
            for (int i = 0; i < dices.Count; i++)
            {
                var row = new List<string> { $"Dice {i + 1}" };
                for (int j = 0; j < dices.Count; j++)
                {
                    row.Add(j == i ? "-" : $"{probabilities[i, j]:P2}");
                }
                table.AddRow(row.ToArray());
            }
        }
        public void Generate() 
        {
            table.Write(Format.Alternative);
        }
    }
}
