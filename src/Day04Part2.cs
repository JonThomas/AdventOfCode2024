public class Day04Part2
{
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public override string ToString() => $"({X}, {Y})";
    }

    public static int xmasBoardWidth = 0;
    public static int xmasBoardHeight = 0;

    public static int Solve()
    {
        var input = File.ReadAllText("input/Day04Input.txt");
        var xmasBoard = InitializeXmasArray(input);
        xmasBoardWidth = xmasBoard[0].Length;
        xmasBoardHeight = xmasBoard.Length;

        PrintBoard(xmasBoard);

        var theAs = LocateTheAsIgnoreEdges(xmasBoard);

        //foreach (var x in theAs)
        //{
        //    Console.WriteLine($"Found A at {x}");
        //}

        var xmasCount = 0;

        foreach (var a in theAs)
        {
            var upLeft = xmasBoard[a.X - 1][a.Y - 1];
            var upRight = xmasBoard[a.X - 1][a.Y + 1];
            var downLeft = xmasBoard[a.X + 1][a.Y - 1];
            var downRight = xmasBoard[a.X + 1][a.Y + 1];

            if(upLeft == 'M' && downRight == 'S' && upRight == 'M' && downLeft == 'S')
            {
                Console.WriteLine($"MAS and MAS for {a}");
                xmasCount++;
            }
            else if (upLeft == 'M' && downRight == 'S' && upRight == 'S' && downLeft == 'M')
            {
                Console.WriteLine($"MAS and SAM for {a}");
                xmasCount++;
            }
            else if (upLeft == 'S' && downRight == 'M' && upRight == 'M' && downLeft == 'S')
            {
                Console.WriteLine($"SAM and MAS for {a}");
                xmasCount++;
            }
            else if (upLeft == 'S' && downRight == 'M' && upRight == 'S' && downLeft == 'M')
            {
                Console.WriteLine($"SAM and SAM for {a}");
                xmasCount++;
            }
        }
        return xmasCount;
    }

    private static List<Point> LocateTheAsIgnoreEdges(char[][] xmasBoard)
    {
        var xmasPoints = new List<Point>();
        for (int i = 1; i < xmasBoardWidth - 1; i++)
        {
            for (int j = 1; j < xmasBoardHeight - 1; j++)
            {
                if (xmasBoard[i][j] == 'A')
                {
                    xmasPoints.Add(new Point(i, j));
                }
            }
        }
        return xmasPoints;
    }

    private static void PrintBoard(char[][] xmasBoard)
    {
        foreach (var line in xmasBoard)
        {
            Console.WriteLine(new string(line));
        }
    }

    private static char[][] InitializeXmasArray(string input)
    {
        var lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
        char[][] ret = new char[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            ret[i] = lines[i].ToArray();
        }
        return ret;
    }
}