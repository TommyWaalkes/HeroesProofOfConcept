﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Encounters
{
    class Statup : Encounter
    {
        public Statup(Player P1) : base(P1)
        {

        }
        public override void RunEvent()
        {
            Console.WriteLine("A buff chad appears in the road. You trade workout tips and glean a few new ideas on how to punch shit");
            Console.WriteLine("Select one of your heroes to get +1 attack!");
            Hero h = SelectAHero();
            h.IncreaseStat(StatEnum.Attack, 1);
        }
    }
}
