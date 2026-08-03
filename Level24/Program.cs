// THE POINT

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

// THE COLOR

// Color a = new Color(123, 43, 78);
// Color b = Color.Purple;

// Console.WriteLine($"Color a is {a.R}, {a.G}, {a.B}");
// Console.WriteLine($"Color b is {b.R}, {b.G}, {b.B}");

// class Color
// {
//     public int R { get; set; }
//     public int G { get; set; }
//     public int B { get; set; }

//     public static Color White { get; } = new Color(255, 255, 255);
//     public static Color Black { get; } = new Color(0, 0, 0);
//     public static Color Red { get; } = new Color(255, 0, 0);
//     public static Color Green { get; } = new Color(0, 255, 0);
//     public static Color Blue { get; } = new Color(0, 0, 255);
//     public static Color Orange { get; } = new Color(255, 165, 255);
//     public static Color Yellow { get; } = new Color(255, 255, 0);
//     public static Color Purple { get; } = new Color(128, 128, 128);

//     public Color(int r, int g, int b)
//     {
//         R = r;
//         G = g;
//         B = b;
//     }

// }

// THE CARD

// for (int i = 0; i < 4; i++)
// {
//     for (int j = 0; j < 13; j++)
//     {
//         Card card = new Card((Ranks)j, (Colors)i);
//         Console.WriteLine($"The {card.Cardcolor} {card.Cardrank}");
//     }
// }

// Card a = new Card(Ranks.Nine, Colors.Green);
// Console.WriteLine(a.Cardcolor);
// Console.WriteLine(a.Cardrank);
// Console.WriteLine(a.IsFace());
// Console.WriteLine(a.IsNumber());

// public enum Ranks { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Dollar, Percentage, Caret, Ampersand }

// public enum Colors { Red, Green, Blue, Yellow }

// class Card
// {
//     public Ranks Cardrank { get; set; }
//     public Colors Cardcolor { get; set; }

//     public Card(Ranks rank, Colors color)
//     {
//         Cardrank = rank;
//         Cardcolor = color;
//     }

//     public bool IsNumber() { return (int)Cardrank < 9; }
//     public bool IsFace() { return (int)Cardrank >= 9; }
// }

// THE LOCKED DOOR

// Console.Write("Enter a code for the door: ");
// int input = Convert.ToInt32(Console.ReadLine());
// Door door = new Door(input);

// while (true)
// {
//     Console.WriteLine($"The door is {door.State.ToString().ToLower()}.");
//     Console.Write("What do you want to do? ");
//     string choice = Console.ReadLine();
//     if (choice == "q") return;
//     switch (choice)
//     {
//         case "unlock":
//             door.Unlock();
//             break;
//         case "lock":
//             door.Lock();
//             break;
//         case "open":
//             door.Open();
//             break;
//         case "close":
//             door.Close();
//             break;
//         case "change":
//             door.ChangeCode();
//             break;
//     }
// }

// public class Door
// {
//     public State State { get; set; } = State.Closed;
//     public int Code { get; set; }

//     public Door(int code)
//     {
//         Code = code;
//     }

//     public void Open()
//     {
//         if (State == State.Closed) State = State.Open;
//     }

//     public void Close()
//     {
//         if (State == State.Open) State = State.Closed;
//     }

//     public void Lock()
//     {
//         if (State == State.Closed) State = State.Locked;
//     }

//     public void Unlock()
//     {
//         if (State == State.Locked)
//         {
//             Console.Write("Enter the code to unlock: ");
//             int input = Convert.ToInt32(Console.ReadLine());
//             if (input == Code) State = State.Closed;
//             else Console.WriteLine("Wrong code!");
//         }
//     }

//     public void ChangeCode()
//     {
//         Console.Write("Enter old code: ");
//         int input = Convert.ToInt32(Console.ReadLine());
//         if (input == Code)
//         {
//             Console.Write("Enter new code: ");
//             int newCode = Convert.ToInt32(Console.ReadLine());
//             Code = newCode;
//             Console.WriteLine("Code changed successfully.");
//         }
//         else Console.WriteLine("Wrong code!");
//     }
// }

// public enum State { Locked, Closed, Open }

// THE PASSWORD VALIDATOR

// while (true)
// {
//     Console.Write("Enter a password: ");
//     bool result = PasswordValidator.Validate(Console.ReadLine());
//     if (result)
//     {
//         Console.WriteLine("This password is valid.");
//     }
//     else Console.WriteLine("This is an INVALID password.");
// }

// public class PasswordValidator
// {
//     public static bool Validate(string password)
//     {
//         bool upper = false, lower = false, digit = false;
//         if (password.Length < 6 || password.Length > 13) return false;
//         foreach (char letter in password)
//         {
//             if (letter == 'T' || letter == '&') return false;
//             if (char.IsUpper(letter)) upper = true;
//             if (char.IsLower(letter)) lower = true;
//             if (char.IsDigit(letter)) digit = true;
//         }
//         return upper && lower && digit;
//     }
// }

// TIC TAC TOE

Game game = new Game();

while (true)
{
    Console.WriteLine("Player X, enter a move.");
    game.LogMove('X');
    string check = game.CheckWin();
    if (check == "won")
    {
        game.Display();
        Console.WriteLine("Player X won!");
        break;
    }
    else if (check == "draw")
    {
        game.Display();
        Console.WriteLine("It was a draw.");
        break;
    }
    Console.WriteLine("Player O, enter a move.");
    game.LogMove('O');
    if (game.CheckWin() == "won")
    {
        game.Display();
        Console.WriteLine("Player O won!");
        break;
    }
    else if (check == "draw")
    {
        game.Display();
        Console.WriteLine("It was a draw.");
        break;
    }
}

public class Game
{
    public char[] Locations { get; set; } = [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '];
    public int Turn { get; set; } = 0;

    public void Display()
    {
        Console.WriteLine($"""
         {Locations[0]} | {Locations[1]} | {Locations[2]}
        ---+---+---
         {Locations[3]} | {Locations[4]} | {Locations[5]}
        ---+---+---
         {Locations[6]} | {Locations[7]} | {Locations[8]}
        """);
    }

    public void LogMove(char symbol)
    {
        int location;
        do
        {
            Display();
            location = Convert.ToInt32(Console.ReadLine()) - 1;
        }
        while (Locations[location] != ' ');
        Locations[location] = symbol;
        Turn++;
    }

    public string CheckWin()
    {
        if ((Locations[0] == Locations[1] && Locations[1] == Locations[2] && Locations[0] != ' ') ||
        (Locations[3] == Locations[4] && Locations[4] == Locations[5] && Locations[3] != ' ') ||
        (Locations[6] == Locations[7] && Locations[7] == Locations[8] && Locations[6] != ' ') ||
        (Locations[0] == Locations[3] && Locations[3] == Locations[6] && Locations[0] != ' ') ||
        (Locations[1] == Locations[4] && Locations[4] == Locations[7] && Locations[1] != ' ') ||
        (Locations[2] == Locations[5] && Locations[5] == Locations[8] && Locations[2] != ' ') ||
        (Locations[0] == Locations[4] && Locations[4] == Locations[8] && Locations[0] != ' ') ||
        (Locations[2] == Locations[4] && Locations[4] == Locations[6] && Locations[2] != ' '))
        {
            return "won";
        }
        else if (Turn == 9) return "draw";
        else return "continue";
    }
}