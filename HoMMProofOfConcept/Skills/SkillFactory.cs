using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Heroes
{
    class SkillFactory
    {
        public static Skill GetSkill(SkillName s)
        {
            if (s == SkillName.Offense)
            {
                return new Offense();
            }

            return new Offense();
        }
    }
}
