// Arrow practice = new(ArrowheadType.Wood, FletchingType.Goose, 75);

// Arrow marksman = new(ArrowheadType.Steel, FletchingType.Goose, 65);

// Arrow elite = new(ArrowheadType.Steel, FletchingType.Plastic, 95);


// Console.WriteLine(practice.GetCost());
// Console.WriteLine(marksman.GetCost());
// Console.WriteLine(elite.GetCost());

while (true)
{
    Console.WriteLine("""
    What type of arrowhead?
    1) Steel
    2) Wood
    3) Obsidian
    """);
    int arrowheadChoice = int.Parse(Console.ReadLine());
    ArrowheadType arrowhead = arrowheadChoice switch
    {
        1 => ArrowheadType.Steel,
        2 => ArrowheadType.Wood,
        3 => ArrowheadType.Obsidian
    };

    Console.WriteLine("""
    What type of fletching?
    1) Goose Feathers
    2) Turkey Feathers
    3) Plastic
    """);
    int fletchingChoice = int.Parse(Console.ReadLine());
    FletchingType fletching = fletchingChoice switch
    {
        1 => FletchingType.Goose,
        2 => FletchingType.Turkey,
        3 => FletchingType.Plastic
    };

    Console.Write("What length of arrow shaft? ");
    int length = int.Parse(Console.ReadLine());

    Arrow arrow = new(arrowhead, fletching, length);
    Console.WriteLine($"I created an {arrow.GetType()} tipped arrow with {arrow.GetFletching()} fletching, that is {arrow.GetLength()} cm long. It costs {arrow.GetCost()} cents.");

}

public class Arrow
{
    private ArrowheadType _arrowheadType;
    private FletchingType _fletchingType;
    private float _length;

    public Arrow(ArrowheadType type, FletchingType fletching, float length)
    {
        _arrowheadType = type;
        _fletchingType = fletching;
        _length = length;
    }

    public float GetCost()
    {
        float cost = _arrowheadType switch
        {
            ArrowheadType.Steel => 10,
            ArrowheadType.Wood => 3,
            ArrowheadType.Obsidian => 5
        };

        cost += _fletchingType switch
        {
            FletchingType.Plastic => 10,
            FletchingType.Turkey => 5,
            FletchingType.Goose => 3
        };

        cost += (float)(_length * 0.05);

        return cost;
    }

    public ArrowheadType GetType() => _arrowheadType;
    public FletchingType GetFletching() => _fletchingType;
    public float GetLength() => _length;
}

public enum ArrowheadType { Steel, Wood, Obsidian }
public enum FletchingType { Plastic, Turkey, Goose }