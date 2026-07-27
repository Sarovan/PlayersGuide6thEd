string tekhelet = "\e[38;2;89;12;131mT\e[39m";
string mauveine = "\e[38;2;143;48;161mM\e[39m";
string amaranth = "\e[38;2;240;24;79mA\e[39m";
string jasmine = "\e[38;2;246;215;141mJ\e[39m";
string keppel = "\e[38;2;70;179;165mK\e[39m";
string bice = "\e[38;2;46;109;146mB\e[39m";

// Console.WriteLine(tekhelet);
// Console.WriteLine(mauveine);
// Console.WriteLine(amaranth);
// Console.WriteLine(jasmine);
// Console.WriteLine(keppel);
// Console.WriteLine(bice);

Henge[] hengeArray = [Henge.Tekhelet, Henge.Mauveine, Henge.Amaranth, Henge.Jasmine, Henge.Keppel, Henge.Bice];

foreach (Henge henge in hengeArray)
{
    (int x, int y, string symbol) = GetInformation(henge);
    Console.SetCursorPosition(x, y);
    Console.WriteLine(symbol);
}

(int, int, string) GetInformation(Henge henge) => henge switch
{
    Henge.Tekhelet => (0b1000, 0b0000, tekhelet),
    Henge.Mauveine => (0b1011, 0b0011, mauveine),
    Henge.Amaranth => (0b0000, 0b0111, amaranth),
    Henge.Jasmine => (0b0011, 0b0011, jasmine),
    Henge.Keppel => (0b0111, 0b0111, keppel),
    Henge.Bice => (0b1110, 0b0111, bice),
};

enum Henge { Tekhelet, Mauveine, Amaranth, Jasmine, Keppel, Bice }

public class Location
{
    public int X { get; set; }
    public int Y { get; set; }
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