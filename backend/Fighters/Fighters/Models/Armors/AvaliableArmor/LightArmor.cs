﻿namespace Fighters.Models.Armors.AvaliableArmor;

public class LightArmor : IArmor
{
    public int Armor { get; } = 20;
    public int Speed { get; } = 0;
    public int Dexterity { get; } = 10;
    public string About { get; } = "легких доспехах";
    public string Name { get; } = "Light";
}

