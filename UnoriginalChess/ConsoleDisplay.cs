namespace UnoriginalChess;

class ConsoleDisplay : IDisplayBoard
{
    public void DisplayBoard(Board board)
    {
        for (int row = 0; row < board.Cells.GetLength(0); row++)
        {
            for (int column = 0; column < board.Cells.GetLength(1); column++)
            {
                Console.Write("- ");
            }
            Console.WriteLine();
        }
    }
}