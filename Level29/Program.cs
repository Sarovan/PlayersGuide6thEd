// Sword sword = new Sword(Material.Iron, Gemstone.None, 20, 4);
// Sword special = sword with { material = Material.Steel, gemstone = Gemstone.Sapphire };
// Sword longer = sword with { length = 40, width = 6 };

// Console.WriteLine(sword);
// Console.WriteLine(special);
// Console.WriteLine(longer);

// public record Sword(Material material, Gemstone gemstone, float length, float width);

// public enum Material { Wood, Bronze, Iron, Steel, Binarium }
// public enum Gemstone { Emerald, Amber, Sapphire, Diamond, Bitstone, None }

Arrow a = new Arrow(Arrowhead.Obsidian, Fletching.TurkeyFeathers, 78);
Console.WriteLine($"Arrowhead={a.Arrowhead} Fletching={a.Fletching} Length={a.Length}cm");
public class Arrow(Arrowhead arrowhead, Fletching fletching, float length)
{
    public Arrowhead Arrowhead { get; } = arrowhead;
    public Fletching Fletching { get; } = fletching;
    public float Length { get; } = length;
}
public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }