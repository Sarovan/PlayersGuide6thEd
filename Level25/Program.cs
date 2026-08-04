Pack pack = new Pack(3, 8, 10);
Console.Clear();

while (true)
{
    Console.WriteLine($"""
    1) Arrow (Weight 0.1, Volume 0.05)
    2) Bow (Weight 1, Volume 4)
    3) Rope (Weight 1, Volume 1.5)
    4) Water (Weight 2, Volume 3)
    5) Food (Weight 1, Volume 0.5)
    6) Sword (Weight 5, Volume 3)

    The pack can carry {pack.MaxItems} items, {pack.MaxWeight} weight, and {pack.MaxVolume} volume.
    It currently has {pack.TotalItems} item{(pack.TotalItems == 1 ? "" : "s")}, weighs {pack.TotalWeight}, and has {pack.TotalVolume} volume.
    """);
    Console.Write("Add an item or enter 0 to quit: ");
    int choice = Convert.ToInt32(Console.ReadLine());
    if (choice == 0) break;
    else switch (choice)
        {
            case 1:
                pack.Add(new Arrow());
                break;
            case 2:
                pack.Add(new Bow());
                break;
            case 3:
                pack.Add(new Rope());
                break;
            case 4:
                pack.Add(new Water());
                break;
            case 5:
                pack.Add(new Food());
                break;
            case 6:
                pack.Add(new Sword());
                break;
        }
}

public class InventoryItem
{
    public double Weight { get; set; }
    public double Volume { get; set; }

    public InventoryItem(double weight, double volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05) { }
}

public class Bow : InventoryItem
{
    public Bow() : base(1, 4) { }
}
public class Rope : InventoryItem
{
    public Rope() : base(1, 1.5) { }
}
public class Water : InventoryItem
{
    public Water() : base(2, 3) { }
}
public class Food : InventoryItem
{
    public Food() : base(1, 0.5) { }
}
public class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }
}

public class Pack
{
    public InventoryItem[] Items { get; set; } = [];
    public int MaxItems { get; private set; }
    public double MaxWeight { get; private set; }
    public double MaxVolume { get; private set; }
    public int TotalItems => Items.Length;
    public double TotalWeight
    {
        get
        {
            double total = 0;
            foreach (InventoryItem item in Items)
            {
                total += item.Weight;
            }
            return total;
        }
    }

    public double TotalVolume
    {
        get
        {
            double total = 0;
            foreach (InventoryItem item in Items)
            {
                total += item.Volume;
            }
            return total;
        }
    }

    public Pack(int total, double maxWeight, double maxVolume)
    {
        MaxItems = total;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
    }

    public bool Add(InventoryItem item)
    {
        if (TotalItems + 1 > MaxItems || TotalWeight + item.Weight > MaxWeight || TotalVolume + item.Volume > MaxVolume)
        {
            Console.Clear();
            Console.WriteLine("You cannot add that item.");
            Console.WriteLine();
            return false;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Item was added.");
            Console.WriteLine();
            Items = [.. Items, item];
        }
        return true;
    }
}