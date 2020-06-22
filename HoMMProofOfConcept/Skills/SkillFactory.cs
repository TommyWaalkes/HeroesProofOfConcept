using HoMMProofOfConcept.Skills;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HoMMProofOfConcept.Heroes
{
    public class SkillFactory
    {
        public Skill GetSkillRandom()
        {
            Random r = new Random();
            int max = Enum.GetNames(typeof(SkillName)).Length;
            int pick = r.Next(0, max);
            SkillName s = (SkillName)pick;
            return GetSkill(s);
        }

        public Skill[] GetMultipleSkills(int number)
        {
            int max = Enum.GetNames(typeof(SkillName)).Length;
            Skill[] output;
            if(number > max)
            {
                Console.WriteLine($"Sorry you are for more skill than there are in the game {max}");
                output = new Skill[0];
            }
            else
            {
                output = new Skill[max];
                for(int i =0; i < output.Length; i++)
                {

                }
            }
            return output;
        }

        public Skill[] GetNewSkills(Hero h)
        {
            Skill[] rawSkills = (Skill[]) Enum.GetValues(typeof(SkillName));
            List<Skill> skills = rawSkills.ToList();

            foreach(Skill s in h.Skills)
            {
                skills.Remove(s);
            }

            Random r = new Random();
            int pick1 = r.Next(0, skills.Count);
            Skill skill1 = skills[pick1];
            skills.Remove(skill1);

            int pick2 = r.Next(0, skills.Count);
            Skill skill2 = skills[pick1];
            skills.Remove(skill2);

            Skill[] output = { skill1, skill2 };
            return output;
        }
        public static Skill GetSkill(SkillName s)
        {
            if (s == SkillName.Offense)
            {
                return new Offense();
            }
            else if(s == SkillName.Learning)
            {
                return new Learning();
            }
            else if(s == SkillName.Logistics)
            {
                return new Logistics();
            }

            return new Offense();
        }
    }
}
