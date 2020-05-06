using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Encounters
{
    public class EncounterFactory
    {
        public List<Encounter> PossibleEncounters { get; set; }
        public EncounterFactory(List<Encounter> PossibleEncounters)
        {
            this.PossibleEncounters = PossibleEncounters;
        }

        public Encounter CreateRandomEncounter(Player p)
        {
            Random r = new Random();
            int pick = r.Next(0, PossibleEncounters.Count);
            return PossibleEncounters[pick];
        }

        public static Encounter GetRandomEncounter(Player p)
        {
            Random r = new Random();
            int pick = r.Next(0, 3);
            switch (pick)
            {
                case 0:
                    return new FindTreasure(p);
                case 1:
                    return new Statup(p);
                case 2:
                    Player enemy = new Player("Evil boyo");
                    Hero badguy = new Hero(enemy, "French Stewart");
                    Encounter e = new BattleEvent(p, enemy);
                    return e;
                default:
                    return new FindTreasure(p);
            }
        }
        public static Encounter GetEncounter(string select, Player p)
        {
            switch (select.Trim().ToLower())
            {
                case "treasure":
                    return new FindTreasure(p);
                case "statup":
                    return new Statup(p);
                case "battle":
                    return new BattleEvent(p, new Player("Evil boyo"));
                default:
                    return new FindTreasure(p);
            }
        }
    }
}
