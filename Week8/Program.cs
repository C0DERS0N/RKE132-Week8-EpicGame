string FolderPath = @"D:\Stuff";

string HeroFile = "Heroes.txt";
string VillainFile = "Villains.txt";
string WeaponFile = "Weapons.txt";

string[] Heroes = File.ReadAllLines(Path.Combine(FolderPath, HeroFile));
string[] Villains = File.ReadAllLines(Path.Combine(FolderPath, VillainFile));
string[] Weapons = File.ReadAllLines(Path.Combine(FolderPath, WeaponFile));

string Hero = RandomValueFromArray(Heroes);
string HeroWeapon = RandomValueFromArray(Weapons);
int HeroHP = CharacterHP(Hero);
int HeroStrength = HeroHP;
Console.WriteLine($"Today {Hero} ({HeroHP}HP) suffers a lot. The only weapon left to use was {HeroWeapon}.");

string Villain = RandomValueFromArray(Villains);
string VillainWeapon = RandomValueFromArray(Weapons);
int VillainHP = CharacterHP(Villain);
int VillainStrength = VillainHP;
Console.WriteLine($"Today {Villain} ({VillainHP}HP) is seriously messed up in their head. The fight with {VillainWeapon} was overwhelming.");

while (HeroHP > 0 && VillainHP > 0)
{
    HeroHP = HeroHP - Hit(Villain, VillainStrength);
    VillainHP = VillainHP - Hit(Hero, HeroStrength);
}

Console.WriteLine($"{Hero} has {HeroHP}HP left.");
Console.WriteLine($"{Villain} has {VillainHP}HP left.");

if (HeroHP > 0)
{
    Console.WriteLine($"{Hero} is still alive!");
}
else if (VillainHP > 0)
{
    Console.WriteLine($"There is no hope, we will be goners!");
}
else
{
    Console.WriteLine($"The suffering will continue!");
}

static string RandomValueFromArray(string[] AnyArray)
{
    Random rnd = new Random();
    int RandomIndex = rnd.Next(0, AnyArray.Length);
    string RandomStringFromArray = AnyArray[RandomIndex];
    return RandomStringFromArray;
}

static int CharacterHP(string Name)
{
    if (Name.Length < 10)
    {
        return 10;
    }
    else
    {
        return Name.Length;
    }
}

static int Hit(string CharacterName, int CharacterHP)
{
    Random rnd = new Random();
    int Strike = rnd.Next(0, CharacterHP);

    if (Strike == 0)
    {
        Console.WriteLine($"{CharacterName} missed the target. ");
    }
    else if (Strike == CharacterHP - 1)
    {
        Console.WriteLine($"{CharacterName} made a critical hit.");
    }
    else
    {
        Console.WriteLine($"{CharacterName} hit {Strike}");
    }
    return Strike;
}