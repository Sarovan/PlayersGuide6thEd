int roundNumber = 1;
int damagedStructures = 0;
int damageToUmbra = 0;
int distanceToUmbra = Random.Shared.Next(25, 75);
int range = 0;

while (damagedStructures < 20 && damageToUmbra < 20 && distanceToUmbra > 0)
{
    string display = $"""
---------------- STATUS -----------------
Round: {roundNumber}
Structures Destroyed: {damagedStructures}
Umbra Damage: {damageToUmbra}
A hit will deal {DamageDealtToUmbra(roundNumber)} damage right now.
-----------------------------------------
""";

    Console.WriteLine(display);

    do
    {
        Console.Write("Enter a range to hit (between 0 and 100): ");
        range = int.Parse(Console.ReadLine());
    }
    while (range < 0 || range > 100);

    if (range < distanceToUmbra) Console.WriteLine("That fell short!");
    else if (range > distanceToUmbra) Console.WriteLine("That went too far!");
    else
    {
        Console.WriteLine("That was a direct hit!");
        damageToUmbra += DamageDealtToUmbra(roundNumber);
    }

    roundNumber++;
    damagedStructures++;
    distanceToUmbra -= Random.Shared.Next(1, 3);
}

if (range > 0) Console.WriteLine($"{(damageToUmbra >= 20 ? "Player" : "Umbra")} won!");
else Console.WriteLine("The Umbra smashed your face!");

int DamageDealtToUmbra(int roundNumber)
{
    if (roundNumber % 3 == 0 && roundNumber % 5 == 0) return 5;
    else if (roundNumber % 3 == 0 || roundNumber % 5 == 0) return 3;
    else return 1;
}