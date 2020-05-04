using System;

public class Hero
{
	public int Attack { get; set; }
	public int Defense { get; set; }
	public int Hp { get; set; }
	public int SpellPower { get; set; }
	public int Knowledge { get; set; }
	public int Speed { get; set; }
	public int Charisma { get; set; }
	public Hero()
	{
		Attack = 1;
		Defense = 1;
		Hp = 10;
		SpellPower = 1;
		Knowledge = 1;
		Speed = 5;
		Charisma = 1;
	}
}
