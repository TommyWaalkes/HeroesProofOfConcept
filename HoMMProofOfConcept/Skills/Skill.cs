using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Skills
{
    public enum SkillLevelEnum
    {
        None = 0, 
        Basic, 
        Advanced, 
        Expert,
        Master
    }

    public enum SkillName
    {
        Offense,
        Logistics, 
        Learning
    }
    public abstract class Skill
    {
        public  SkillName Name { get; set; } 
        public int Level { get; set; } = 1;

        public Skill(SkillName Name)
        {
            this.Name = Name;
        }

        public abstract void ModifyStats(Hero h);

        public abstract void StartTurn(Hero h);

        public abstract void ChangeSpell();
        public virtual void AddSpell()
        {

        }
    }

}
