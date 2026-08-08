
Coordinate first = new Coordinate(2, 3);
Coordinate second = new Coordinate(2, 4);
Coordinate third = new Coordinate(5, 5);

Console.WriteLine(IsAdjacent(first, second));
Console.WriteLine(IsAdjacent(first, third));
Console.WriteLine(IsAdjacent(third, second));


bool IsAdjacent(Coordinate a, Coordinate b)
{
    if (Math.Abs(a.Row - b.Row) > 1) return false;
    if (Math.Abs(a.Column - b.Column) > 1) return false;
    return true;
}

public struct Coordinate
{
    public int Row { get; }
    public int Column { get; }

    public Coordinate(int x, int y)
    {
        Row = x;
        Column = y;
    }
}