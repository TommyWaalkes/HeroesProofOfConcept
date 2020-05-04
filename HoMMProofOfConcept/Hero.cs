using HoMMProofOfConcept;
using System;
using System.Collections.Generic;

namespace HoMMProofOfConcept
{
	public class Hero
	{
		public string Name { get; set; }
		public int Level { get; set; }
		public int XP { get { return XP; } set { GainExperience(value); } }
		public int XPNextLevel { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int MaxHp { get; set; }
		public int Hp { get; set; }
		public int SpellPower { get; set; }
		public int Knowledge { get; set; }
		public int Speed { get; set; }
		public int Charisma { get; set; }
		public bool IsAlive { get; set; }
		public bool IsAi { get; set; }
		public Player Owner { get; set; }
		public Hero(Player Owner, string Name)
		{
			this.Name = Name;
			Level = 1;
			XP = 0;
			XPNextLevel = CalculateXpToNextLevel();
			Attack = 1;
			Defense = 1;
			MaxHp = 10;
			Hp = MaxHp;
			SpellPower = 1;
			Knowledge = 1;
			Speed = 5;
			Charisma = 1;
			IsAlive = true;
			this.Owner = Owner;
			this.IsAi = Owner.IsAi;
			Owner.Heroes.Add(this);
		}

		public Hero PickTarget(List<Hero> enemies)
		{
			if (!IsAi)
			{
				Console.WriteLine("Please select a target by inputting a number");
				for (int i = 0; i < enemies.Count; i++)
				{
					Console.WriteLine($"{i}: {enemies[i].Name}");
				}
				string input = Console.ReadLine();
				int pick = int.Parse(input);

				return enemies[pick];
			}
			else
			{
				//TO DO - Make AI more complex rn it just picks at random
				Random r = new Random();
				int pick = r.Next(0, enemies.Count);

				return enemies[pick];
			}
		}

		public void LevelUp()
		{
			Console.WriteLine($"{Name} has leveled up!!");
			XPNextLevel = CalculateXpToNextLevel();
			Level++;

			bool done = false;
			while (!done)
			{
				Console.WriteLine("Select a stat you would like to increase");
				Console.WriteLine("1) Attack");
				Console.WriteLine("2) Defense");
				Console.WriteLine("3) Spell Power");
				Console.WriteLine("4) Knowledge");
				Console.WriteLine("5) Charisma");
				Console.WriteLine("6) Speed");
				string input = Console.ReadLine();
				int num = int.Parse(input);
			}
		}

		public void GainExperience(int XP)
		{
			this.XP += XP;
			if (XP >= XPNextLevel)
			{
				LevelUp();
			}
		}

		public int CalculateXpToNextLevel()
		{
			int output = (Level)* 1500;
			return output;
		}
		public void DealDamage(Hero target)
		{
			int min = this.Attack + (this.Level);
			int max = this.Attack + (this.Level * 5);
			Random r = new Random();

			int damage = r.Next(min, max)-target.Defense;
			if(damage< 1)
			{
				damage = 1;
			}
			target.Hp -= damage;
			Console.WriteLine($"{this.Name} deals {damage} to {target.Name} who now has {target.Hp} hit point left.");

			if(target.Hp < 1)
			{
				target.IsAlive = false;
				Console.WriteLine($"{target.Name} is defeated!!!");
			}
		}

		public void PrintStats()
		{
			Console.WriteLine($"Here are {Name}'s stats:");
			Console.WriteLine($"Attack: {Attack}");
			Console.WriteLine($"Spell Power: {SpellPower}");
			Console.WriteLine($"Knowledge: {Knowledge}");
		}
	}
}