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
        public Encounter GetEncounter(string select, Player p)
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
