using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept
{
    public abstract class Encounter
    {
        protected Player P1 { get; set; }
        protected string Message { get; set; }
        public Encounter(Player P1)
        {
            this.P1 = P1;
        }
        public Encounter(Player P1, string Message)
        {
            this.P1 = P1;
            this.Message = Message;
        }

        public Hero GetRandomHero()
        {
            int min = 0;
            int max = P1.Heroes.Count - 1;
            Random r = new Random();
            int index = r.Next(min, max);
            return P1.Heroes[index];
        }

        public virtual Hero SelectAHero()
        {
            int i = 0;
            foreach(Hero h in P1.Heroes)
            {
                Console.WriteLine($"{i}: {h.Name}");
                i++;
            }
            Hero output;
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    int pick = int.Parse(input);
                    output = P1.Heroes[pick];
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Please input a number");
                    Console.WriteLine("Lets try again");
                    continue;
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine($"Please select a number from 0 to {P1.Heroes.Count -1}");
                    Console.WriteLine("Lets try again");
                    continue;

                }

                return output;
            }
        }

        public abstract void RunEvent();
    }
}
