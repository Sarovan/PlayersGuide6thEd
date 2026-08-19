// INIT

Map map;
Point[] pits;
Point entrance;
Player player;
Fountain fountain;

// GAME STARTS

Console.Write("Do you want to play a small, medium (default), or large game? ");
string size = Console.ReadLine();
switch (size)
{
    case "small":
        map = new Map(4, 4);
        pits = [new Point(2, 3)];
        entrance = new Point(0, 0);
        player = new Player(0, 0);
        fountain = new Fountain(0, 2);
        break;
    case "large":
        map = new Map(8, 8);
        pits = [new Point(3, 4), new Point(1, 2), new Point(6, 7), new Point(5, 4)];
        entrance = new Point(3, 7);
        player = new Player(3, 7);
        fountain = new Fountain(4, 2);
        break;
    default:
        map = new Map(6, 6);
        pits = [new Point(3, 4), new Point(1, 2)];
        entrance = new Point(5, 0);
        player = new Player(5, 0);
        fountain = new Fountain(2, 4);
        break;
}

while (true)
{
    Console.WriteLine($"You are in the room at (Row={player.Point.Row}, Column={player.Point.Column}).");
    if (isDead())
    {
        Console.WriteLine("You fell into a pit! You're dead.");
        break;
    }
    if (player.Point == entrance)
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
    if (sensePit())
    {
        Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
    }
    Console.Write("What do you want to do? ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "east":
        case "west":
        case "north":
        case "south":
            map.Move(choice, player);
            break;
        case "enable":
            fountain.IsOn = true;
            break;
    }
}

bool sensePit()
{
    foreach (Point pit in pits)
    {
        if (Math.Abs(player.Point.Row - pit.Row) <= 1 && Math.Abs(player.Point.Column - pit.Column) <= 1)
        {
            return true;
        }
    }
    return false;
}

bool isDead()
{
    foreach (Point pit in pits)
    {
        if (player.Point == pit)
        {
            return true;
        }
    }
    return false;
}

// DEFS

public class Map
{
    public Point[,] Rooms { get; set; }

    public Map(int rows, int columns)
    {
        Rooms = new Point[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Rooms[i, j] = new Point(i, j);
            }
        }
    }

    public void Move(string direction, Player player)
    {
        if (direction == "east" && player.Point.Column < Rooms.GetLength(1) - 1)
        {
            player.Point = player.Point with { Column = player.Point.Column + 1 };
        }
        else if (direction == "west" && player.Point.Column > 0)
        {
            player.Point = player.Point with { Column = player.Point.Column - 1 };
        }
        else if (direction == "north" && player.Point.Row > 0)
        {
            player.Point = player.Point with { Row = player.Point.Row - 1 };
        }
        else if (direction == "south" && player.Point.Row < Rooms.GetLength(0) - 1)
        {
            player.Point = player.Point with { Row = player.Point.Row + 1 };
        }
    }
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