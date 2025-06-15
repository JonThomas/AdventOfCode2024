public class Day04Part1
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

        var xs = LocateTheXs(xmasBoard);

        //foreach (var x in xs)
        //{
        //    Console.WriteLine($"Found X at {x}");
        //}

        var xmasCount = 0;

        foreach (var x in xs)
        {
            if (CountRight(xmasBoard[x.X], x))
            {
                Console.WriteLine($"Found XMAS looking right, starting at {x}");
                xmasCount++;
            }
            if (CountDown(xmasBoard, x))
            {
                Console.WriteLine($"Found XMAS looking down, starting at {x}");
                xmasCount++;
            }
            if (CountLeft(xmasBoard[x.X], x))
            {
                Console.WriteLine($"Found XMAS looking left, starting at {x}");
                xmasCount++;
            }
            if (CountUp(xmasBoard, x))
            {
                Console.WriteLine($"Found XMAS looking up, starting at {x}");
                xmasCount++;
            }
            if (CountRightDown(xmasBoard, x))
            {
                Console.WriteLine($"Found XMAS looking right-down, starting at {x}");
                xmasCount++;
            }
            if (CountRightUp(xmasBoard, x))
            {
                Console.WriteLine($"Found XMAS looking right-up, starting at {x}");
                xmasCount++;
            }
            if (CountLeftDown(xmasBoard, x))
            {
                Console.WriteLine($"Found XMAS looking left-down, starting at {x}");
                xmasCount++;
            }
            if (CountLeftUp(xmasBoard, x))
            {
                Console.WriteLine($"Found XMAS looking left-up, starting at {x}");
                xmasCount++;
            }
        }
        return xmasCount;
    }

    private static bool CountLeftUp(char[][] xmasBoard, Point x)
    {
        if (x.Y < 3)
            return false;
        if (x.X < 3)
            return false;
        return xmasBoard[x.X - 1][x.Y - 1] == 'M'
            && xmasBoard[x.X - 2][x.Y - 2] == 'A'
            && xmasBoard[x.X - 3][x.Y - 3] == 'S';
    }

    private static bool CountLeftDown(char[][] xmasBoard, Point x)
    {
        if (x.Y < 3)
            return false;
        if (x.X > xmasBoardHeight - 4)
            return false;
        return xmasBoard[x.X + 1][x.Y - 1] == 'M'
            && xmasBoard[x.X + 2][x.Y - 2] == 'A'
            && xmasBoard[x.X + 3][x.Y - 3] == 'S';
    }

    private static bool CountRightUp(char[][] xmasBoard, Point x)
    {
        if (x.Y > xmasBoardWidth - 4)
            return false;
        if (x.X < 3)
            return false;
        return xmasBoard[x.X - 1][x.Y + 1] == 'M'
            && xmasBoard[x.X - 2][x.Y + 2] == 'A'
            && xmasBoard[x.X - 3][x.Y + 3] == 'S';
    }

    private static bool CountRightDown(char[][] xmasBoard, Point x)
    {
        if (x.X > xmasBoardHeight - 4)
            return false;
        if (x.Y > xmasBoardWidth - 4)
            return false;
        return xmasBoard[x.X + 1][x.Y + 1] == 'M'
            && xmasBoard[x.X + 2][x.Y + 2] == 'A'
            && xmasBoard[x.X + 3][x.Y + 3] == 'S';
    }

    private static bool CountUp(char[][] xmasBoard, Point x)
    {
        if (x.X < 3)
            return false;
        return xmasBoard[x.X - 1][x.Y] == 'M'
            && xmasBoard[x.X - 2][x.Y] == 'A'
            && xmasBoard[x.X - 3][x.Y] == 'S';
    }

    public static bool CountLeft(char[] xmasRow, Point x)
    {
        if (x.Y < 3)
            return false;
        return xmasRow[x.Y - 1] == 'M' && xmasRow[x.Y - 2] == 'A' && xmasRow[x.Y - 3] == 'S';
    }

    public static bool CountDown(char[][] xmasBoard, Point x)
    {
        if (x.X > xmasBoardHeight - 4)
            return false;
        return xmasBoard[x.X + 1][x.Y] == 'M' 
            && xmasBoard[x.X + 2][x.Y] == 'A' 
            && xmasBoard[x.X + 3][x.Y] == 'S';
    }

    public static bool CountRight(char[] xmasRow, Point x)
    {
        if (x.Y > xmasBoardWidth - 4)
            return false;
        return xmasRow[x.Y + 1] == 'M' && xmasRow[x.Y + 2] == 'A' && xmasRow[x.Y + 3] == 'S';
    }

    private static List<Point> LocateTheXs(char[][] xmasBoard)
    {
        var xmasPoints = new List<Point>();
        for (int i = 0; i < xmasBoardWidth; i++)
        {
            for(int j = 0; j < xmasBoardHeight; j++)
            {
                if(xmasBoard[i][j] == 'X')
                {
                    xmasPoints.Add(new Point(i, j));
                }
            }
        }
        return xmasPoints;
    }

    private static void PrintBoard(char[][] xmasBoard)
    {
        foreach(var line in xmasBoard)
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