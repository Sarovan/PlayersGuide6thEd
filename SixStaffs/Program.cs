// Location amaranthLocation = new Location(3, 2);
// Color amaranthColor = new Color(240, 24, 79);
// char amaranthChar = 'A';
// Henge amaranth = new Henge(amaranthLocation, amaranthColor, amaranthChar);

// Location jasmineLocation = new Location(1, 5);
// Color jasmineColor = new Color(246, 215, 141);
// char jasmineChar = 'J';
// Henge jasmine = new Henge(jasmineLocation, jasmineColor, jasmineChar);

// amaranth.Display();
// jasmine.Display();

Henge[] henges = [
    new Henge(new Location(0,0), new Color(89,12,131), 'T'),
    new Henge(new Location(1,0), new Color(143,48,161), 'M'),
    new Henge(new Location(2,0), new Color(240,24,79), 'A'),
    new Henge(new Location(3,0), new Color(246,215,141), 'J'),
    new Henge(new Location(4,0), new Color(70,179,165), 'K'),
    new Henge(new Location(5,0), new Color(40,109,146), 'B')
    ];

Crate[] crates = [
    new Crate(new Location(5, 4)),
    new Crate(new Location(0, 7)),
    new Crate(new Location(2, 8)),
    new Crate(new Location(4, 2))
    ];

Henge current = henges[0];

while (true)
{
    Console.Clear();
    foreach (Crate target in crates)
        if (target.IsIntact)
            target.Display();
    foreach (Henge henge in henges)
        henge.Display();
    ConsoleKey key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.Spacebar)
    {
        foreach (Crate crate in crates)
            if (current.Location.X == crate.Location.X && current.Location.Y == crate.Location.Y)
                crate.IsIntact = false;
    }
    if (key == ConsoleKey.UpArrow && current.Location.Y > 0) current.Location.Y--;
    if (key == ConsoleKey.DownArrow && current.Location.Y < 9) current.Location.Y++;
    if (key == ConsoleKey.RightArrow && current.Location.X < 9) current.Location.X++;
    if (key == ConsoleKey.LeftArrow && current.Location.X > 0) current.Location.X--;
    if (key == ConsoleKey.D1) current = henges[0];
    if (key == ConsoleKey.D2) current = henges[1];
    if (key == ConsoleKey.D3) current = henges[2];
    if (key == ConsoleKey.D4) current = henges[3];
    if (key == ConsoleKey.D5) current = henges[4];
    if (key == ConsoleKey.D6) current = henges[5];
}
public class Location
{
    public int X { get; set; }
    public int Y { get; set; }

    public Location(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Color
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }
}

public class Henge
{
    public Location Location { get; set; }
    public Color Color { get; set; }
    public char Char { get; set; }
    public Henge(Location location, Color color, char representation)
    {
        Location = location;
        Color = color;
        Char = representation;
    }
    public void Display()
    {
        Console.SetCursorPosition(Location.X, Location.Y);
        Console.WriteLine($"\e[38;2;{Color.R};{Color.G};{Color.B}m{Char}");
    }
}

public class Crate(Location location)
{
    public Location Location { get; set; } = location;
    public bool IsIntact { get; set; } = true;

    public void Display()
    {
        Console.SetCursorPosition(Location.X, Location.Y);
        Console.WriteLine($"\e[38;2;255;255;255m*");
    }
}