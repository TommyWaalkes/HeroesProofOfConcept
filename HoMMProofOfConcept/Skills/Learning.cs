using HoMMProofOfConcept.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Skills
{
    public class Learning : Skill
    {
        public Learning() : base(SkillName.Learning)
        {
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
