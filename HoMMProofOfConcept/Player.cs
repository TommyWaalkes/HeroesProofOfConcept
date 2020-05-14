using HoMMProofOfConcept.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept
{
    public class Player
    {
        public string Name { get; set; }
        public int Gold {get; set;}
        public List<Hero> Heroes { get; set; }
        public List<Hero> Garrison { get; set; }
        public bool IsAi { get; set; }

        public Player(string Name)
        {
            this.Name = Name;
            Heroes = new List<Hero>();
            Garrison = new List<Hero>();
            Gold = 20000;
        }
        public void AddHero(Hero h)
        {
            h.IsAi = this.IsAi;
            h.Owner = this;
            this.Heroes.Add(h);
        }

        public void HeroesGainExperience(int xp)
        {
            double xpAdjusted = xp / Heroes.Count;
            foreach(Hero h in Heroes)
            {
                int level = h.GetSkillLevel(SkillName.Learning);
                double modifier = 1 + (level * 0.15);

                h.XP += (int) Math.Ceiling(xpAdjusted * modifier);
            }
        }
    }
}
