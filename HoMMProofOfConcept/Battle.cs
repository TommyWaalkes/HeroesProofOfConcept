using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoMMProofOfConcept
{
    class Battle
    {
        public List<Hero> HumanParty { get; set; }
        public List<Hero> AIParty { get; set; }
        public Player p1 { get; set; }
        public Player p2 { get; set; }
        public Battle(Player p1, Player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.HumanParty = p1.Heroes;
            this.AIParty = p2.Heroes;
            SetupCombat();
        }

        public void SetupCombat()
        {
            List<Hero> Combatants = new List<Hero>();
            Combatants.AddRange(HumanParty);
            Combatants.AddRange(AIParty);

            PlayRound(Combatants);
        }

        public void PlayRound(List<Hero> combatants)
        {
            Console.WriteLine("Combat start!");
            Player winner = null;
            while (AreEnemiesAlive(out winner)) {
                Console.WriteLine("New Round");
                //Put it in here so that speed gets recalculated 
                CreateTurnOrder(combatants);
                foreach (Hero c in combatants)
                {
                    if (c.IsAlive)
                    {
                        Hero target;
                        if (c.Owner == p1)
                        {
                            target = c.PickTarget(AIParty);
                        }
                        else
                        {
                            target = c.PickTarget(HumanParty);
                        }
                        c.DealDamage(target);
                    }
                }
            }

            Console.WriteLine($"{winner.Name} wins combat!!!");
            int xp = 0;
            if(p1 == winner)
            {
               xp = CalculateExperience(p2.Heroes);
            }
            else
            {
                xp = CalculateExperience(p1.Heroes);
            }
            winner.HeroesGainExperience(xp);
           
        }
        public void GetLoot(Player winner)
        {
            throw new NotImplementedException();
        }
        public int CalculateExperience(List<Hero> losers)
        {
            int totalXp = 500;
            foreach(Hero loser in losers)
            {
                int xp = loser.MaxHp * 100 * loser.Level;
                totalXp += xp;
            }

            return totalXp;
        }

        public void CreateTurnOrder(List<Hero> Combatants)
        {
            Combatants.OrderBy(x => x.Speed);
        }

        public bool AreEnemiesAlive(out Player winner)
        {
            bool humanLeft = false;
            bool AiLeft = false;
            foreach(Hero h in HumanParty)
            {
                if (h.IsAlive)
                {
                    humanLeft = true;
                    break;
                }
            }
            foreach (Hero h in AIParty)
            {
                if (h.IsAlive)
                {
                    AiLeft = true;
                    break;
                }
            }
            if (!humanLeft)
            {
                winner = p2;
            }
            else if(!AiLeft)
            {
                winner = p1;
            }
            else
            {
                winner = null;
            }
            return humanLeft && AiLeft;

        }
    }
}
