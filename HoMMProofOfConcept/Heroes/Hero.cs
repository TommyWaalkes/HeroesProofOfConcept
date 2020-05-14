using HoMMProofOfConcept;
using HoMMProofOfConcept.Heroes;
using System;
using System.Collections.Generic;

namespace HoMMProofOfConcept
{
	public class Hero
	{
		public string Name { get; set; }
		public int Level { get; set; }
		public int XP { get { return _xp; } set { GainExperience(value); } }
		private int _xp = 0;
		public int XPNextLevel { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int MaxHp { get; set; }
		public int Hp { get; set; }
		public int SpellPower { get; set; }
		public int Knowledge { get; set; }
		public int Speed { get; set; }
		public int Charisma { get; set; }
		public int SpellPointsMax { get; set; } 
		public int SpellPoints { get; set; } 
		public StatEnum FavoredStat { get; set; } = StatEnum.Attack;
		public bool IsAlive { get; set; } = true;
		public bool IsAi { get; set; }
		public Player Owner { get; set; }

		public List<Skill> Skills = new List<Skill>();
		public Hero(Player Owner, string Name)
		{
			this.Name = Name;
			Level = 1;
			//This line is causing a stack overflow
			XPNextLevel = CalculateXpToNextLevel();
			XP = 0;
			Attack = 1;
			Defense = 1;
			MaxHp = 10;
			Hp = MaxHp;
			SpellPower = 1;
			Knowledge = 1;
			Speed = 5;
			Charisma = 1;
			SpellPointsMax = CalculateMaxSpellPoints();
			SpellPoints = SpellPointsMax;
			this.Owner = Owner;
			this.IsAi = Owner.IsAi;
			Owner.Heroes.Add(this);
		}

		public void StartTurn()
		{

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
			Hp += 10 + (5 * Defense);
			bool done = false;
			while (!done)
			{
				PrintStats();
				Console.WriteLine("Select a stat you would like to increase");
				StatEnum[] stats= (StatEnum[]) Enum.GetValues(typeof(StatEnum));

				for(int i = 0; i < stats.Length; i++)
				{
					Console.WriteLine($"{i}: {stats[i]}");
				}
				try
				{
					string input = Console.ReadLine();
					int num = int.Parse(input);

					if(num >=0 && num <= 6)
					{
						StatEnum stat = (StatEnum)Enum.Parse(typeof(StatEnum), num.ToString());
						IncreaseStat(stat, 1);
					}
					else
					{
						throw new Exception("Input was out of range lets try that again");
					}
					done = true;
				}
				catch (FormatException)
				{
					Console.WriteLine("I didn't understand that let's try again");
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message); 
				}
			}
			SpellPointsMax = CalculateMaxSpellPoints();
		}

		public void AddSkill(Skill s)
		{
			if(Skills.Count < 8)
			{

			}
		}

		public void SetSpellPoints(int gain)
		{
			SpellPoints += gain;
			if(SpellPoints > SpellPointsMax)
			{
				SpellPoints = SpellPointsMax;
			}
		}

		public int CalculateMaxSpellPoints()
		{
			int Max = Knowledge * 10;
			return Max;
		}

		public void GainExperience(int XP)
		{
			_xp += XP;
			if (_xp >= XPNextLevel)
			{
				LevelUp();
			}
		}

		public int CalculateXpToNextLevel()
		{
			int output = (Level)* 1500;
			return output;
		}

		public void IncreaseStat(StatEnum stat, int amount)
		{
			if(stat == FavoredStat)
			{
				amount++;
			}

			switch (stat)
			{
				case StatEnum.Attack:
					Attack += amount;
					break;
				case StatEnum.Defense:
					Defense += amount;
					break;
				case StatEnum.SpellPower:
					SpellPower += amount;
					break;
				case StatEnum.Knowledge:
					Knowledge += amount;
					break;
				case StatEnum.Charisma:
					Charisma += amount;
					break;
				case StatEnum.Speed:
					Speed += amount;
					break;
			}
			Console.WriteLine($"{stat.ToString()} has increased by {amount}!");
			SpellPointsMax = CalculateMaxSpellPoints();
		}

		public bool HasSkill(SkillName skill)
		{
			foreach(Skill s in Skills)
			{
				if(s.Name == skill)
				{
					return true;
				}
			}

			return false;
		}

		public int GetSkillLevel(SkillName name)
		{
			int level = 0;
			if (HasSkill(name))
			{
				foreach(Skill s in Skills)
				{
					if(s.Name == name)
					{
						level = s.Level;
					}
				}
			}
				return level;
		}

		public void AddSkill(SkillName name)
		{
			if (!HasSkill(name))
			{
				Skill s = SkillFactory.GetSkill(name);
				Skills.Add(s);
			}
			else
			{
				Console.WriteLine($"{Name} already knows {name}");
			}
		}

		public void DealDamage(Hero target)
		{
			int min = this.Attack + (this.Level * 2);
			int max = this.Attack + (this.Level * 5);
			
			Random r = new Random();
			if (HasSkill(SkillName.Offense))
			{
				int skillLevel = GetSkillLevel(SkillName.Offense);
				double bonus = 1 + (skillLevel * .1);
				min = (int) Math.Ceiling(min * bonus);
				max = (int)Math.Ceiling(max * bonus);
			}
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
			Console.WriteLine($"Charisma: {Charisma}");
			Console.WriteLine($"Speed: {Speed}");
		}
	}
}