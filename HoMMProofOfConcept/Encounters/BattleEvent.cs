using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Encounters
{
    public class BattleEvent : Encounter
    {
        public Player Opponent { get; set; }
        public BattleEvent(Player P1, Player Opponent) : base(P1)
        {
            this.Opponent = Opponent;
        }

        public override void RunEvent()
        {
            Console.WriteLine("You run into a group of enemies! A fight starts!");
            Battle b = new Battle(P1, Opponent);
        }
    }
}
