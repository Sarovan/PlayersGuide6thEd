// Point a = new Point(2, 3);
// Point b = new Point(-4, 0);
// Point c = new Point();

// Console.WriteLine($"{a.X}, {a.Y}");
// Console.WriteLine($"{b.X}, {b.Y}");
// Console.WriteLine($"{c.X}, {c.Y}");

// class Point
// {
//     public int X { get; set; }
//     public int Y { get; set; }

//     public Point(int x, int y)
//     {
//         X = x;
//         Y = y;
//     }

//     public Point()
//     {
//         X = 0;
//         Y = 0;
//     }
// }

Color a = new Color(123, 43, 78);
Color b = Color.Purple;

Console.WriteLine($"Color a is {a.R}, {a.G}, {a.B}");
Console.WriteLine($"Color b is {b.R}, {b.G}, {b.B}");

class Color
{
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }

    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Green { get; } = new Color(0, 255, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Orange { get; } = new Color(255, 165, 255);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Purple { get; } = new Color(128, 128, 128);

    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

}