using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Encounters
{
    public class FindTreasure : Encounter
    {
        public FindTreasure(Player p ) : base(p)
        {

        }
        public override void RunEvent()
        {
            Console.WriteLine("An Old Man saunters up to you and makes a donation to you, 'For the homefront!!!'");
            Console.WriteLine("1000 Gold gained!");
            P1.Gold += 1000;
        }
    }
}
