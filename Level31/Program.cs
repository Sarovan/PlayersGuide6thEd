
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
        if (fountain.IsOn)
        {
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
            Console.WriteLine("You win!");
            break;
        }
        Console.WriteLine("You see light coming from the cavern entrance.");
    }
    else if (player.Point == fountain.Point)
    {
        if (fountain.IsOn)
        {
            Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
        }
        else
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
    }
    Console.Write("What do you want to do? ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "east":
        case "west":
        case "north":
        case "south":
            player.Move(choice);
            break;
        case "enable":
            fountain.IsOn = true;
            break;
    }
}

public class Player(int row, int column)
{
    public Point Point { get; set; } = new Point(row, column);

    public void Move(string direction)
    {
        if (direction == "east" && Point.Column < 3)
        {
            Point = Point with { Column = Point.Column + 1 };
        }
        else if (direction == "west" && Point.Column > 0)
        {
            Point = Point with { Column = Point.Column - 1 };
        }
        else if (direction == "north" && Point.Row > 0)
        {
            Point = Point with { Row = Point.Row - 1 };
        }
        else if (direction == "south" && Point.Row < 3)
        {
            Point = Point with { Row = Point.Row + 1 };
        }
    }
}

public class Fountain(int row, int column)
{
    public Point Point { get; set; } = new Point(row, column);
    public bool IsOn { get; set; } = false;
}

public record Point(int Row, int Column);