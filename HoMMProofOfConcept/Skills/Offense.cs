using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Skills
{
    public class Offense : Skill
    {
        public Offense() :base(SkillName.Offense)
        {
            Name = SkillName.Offense;
        }
        public override void ChangeSpell()
        {
            throw new NotImplementedException();
        }

        public override void ModifyStats(Hero h)
        {
            throw new NotImplementedException();
        }

        public override void StartTurn(Hero h)
        {
            throw new NotImplementedException();
        }
    }
}
