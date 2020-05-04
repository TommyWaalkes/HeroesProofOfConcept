using HoMMProofOfConcept.Encounters;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept
{
    class Game
    {
        public List<Player> Players { get; set; }
        
        public Game()
        {
            Player p1 = new Player("Phil");
            p1.IsAi = false;
            Hero h1 = new Hero(p1, "Tommy");

            Statup ft = new Statup(p1);
            ft.RunEvent();

            Player p2 = new Player("Joey");
            p2.IsAi = true;
            Hero h2 = new Hero(p2, "Ogre");

            Battle e = new Battle(p1, p2);
        }

        
    }
}
