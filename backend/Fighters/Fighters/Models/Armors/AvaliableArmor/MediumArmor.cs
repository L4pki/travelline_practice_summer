﻿namespace Fighters.Models.Armors.AvaliableArmor;

public class MediumArmor : IArmor
{
    public int Armor { get; } = 45;
    public int Speed { get; } = -10;
    public int Dexterity { get; } = -15;
    public string About { get; } = "средних доспехах";
    public string Name { get; } = "Medium";

}

