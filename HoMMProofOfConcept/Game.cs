using HoMMProofOfConcept.Encounters;
using HoMMProofOfConcept.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoMMProofOfConcept
{
    class Game
    {
        public List<int> nums = new List<int>();
        public List<Player> Players { get; set; }
        private int currentTurn = 0;
        private EncounterFactory _Ef;
        public Game()
        {
            Players = new List<Player>();
            Player p1 = new Player("Phil");
          
            p1.IsAi = false;
            Hero h1 = new Hero(p1, "Tommy");
            Console.WriteLine("hi");
          
            //Statup ft = new Statup(p1);
            //ft.RunEvent();
            //ft.RunEvent();
            Player p2 = new Player("Joey");
            p2.IsAi = true;
            Hero h2 = new Hero(p2, "Ogre");


            //Battle e = new Battle(p1, p2);
            Players.Add(p1);
            Players.Add(p2);
           
        }
        public void Run()
        {
            int pick = currentTurn % Players.Count;
            while (true)
            {
                Player current = Players[pick];
                if (current.IsAi)
                {

                }
                else
                {
                    PickTurnAction(current);
                }
                currentTurn++;
            }
        }

        public int CalculatePartyMovement(List<Hero> heroes)
        {
            
            int lowestSpeed = heroes.Min(x => x.Speed);
            Hero slowest = heroes.Where(x => x.Speed == lowestSpeed).First();
            lowestSpeed += slowest.GetSkillLevel(SkillName.Logistics);
            if (lowestSpeed <= 0)
            {
                lowestSpeed = 1;
            }
            return lowestSpeed;
        }

        public void PickTurnAction(Player p)
        {
            Console.WriteLine($"{p.Name}'s turn!");
            //Movement is the speed of the slowest hero
            int moves = CalculatePartyMovement(p.Heroes);
            int num = 0;
            bool done = false;
            while (!done)
            {
                Console.WriteLine($"Turn: {currentTurn}");
                Console.WriteLine($"You have {moves} moves left");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1) Build");
                Console.WriteLine("2) Explore");
                Console.WriteLine("3) Fight");
                Console.WriteLine("4) End Turn");
                try
                {
                    string input = Console.ReadLine();
                    num = int.Parse(input);
                    switch (num)
                    {
                        case 1:
                            Console.WriteLine("Building not implemented yet");
                            break;
                        case 2:
                            if (moves > 0)
                            {
                                Console.WriteLine("Lets go exploring!");
                                Encounter e = EncounterFactory.GetRandomEncounter(p);
                                e.RunEvent();
                                moves--;
                            }
                            break;
                        case 3:
                            if(moves > 0)
                            {
                                Console.WriteLine("Let's go spoiling for a fight");
                                Player enemy = new Player("Evil boyo");
                                Hero badguy = new Hero(enemy, "French Stewart");
                                Encounter e  = new BattleEvent(p, enemy);
                                e.RunEvent();
                                moves--;
                            }
                            break;
                        case 4:
                            Console.WriteLine("Turn is done!");
                            done = true;
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("I didn't understand, let's try that again");
                    continue;
                }
            }

            
        }
    }
}
