Point[,] grid = new Point[4, 4];

for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        grid[i, j] = new Point(i, j);
    }
}

Point Entrance = new Point(0, 0);
Player player = new Player(0, 0);
Fountain fountain = new Fountain(0, 2);

while (true)
{
    Console.WriteLine($"You are in the room at (Row={player.Point.Row}, Column={player.Point.Column}).");
    if (player.Point == Entrance)
    {
        Console.WriteLine("You see light coming from the cavern entrance.");
    }
    Console.Write("What do you want to do? ");
    string choice = Console.ReadLine();
}

public class Player(int row, int column)
{
    public Point Point { get; set; } = new Point(row, column);
}

public class Fountain(int row, int column)
{
    public Point Point { get; set; } = new Point(row, column);
    public bool IsOn { get; set; } = false;
}

public record Point(int Row, int Column);