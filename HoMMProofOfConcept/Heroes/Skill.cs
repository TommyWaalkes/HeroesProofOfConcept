using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Heroes
{
    public enum SkillLevelEnum
    {
        None = 0, 
        Basic, 
        Advanced, 
        Expert,
        Master
    }
    public abstract class Skill
    {
        public const string Name = "Skill";
        public int Level { get; set; } = 1;
        public abstract void ModifyStats(Hero h);

        public abstract void StartTurn(Hero h);

        public abstract void ChangeSpell();
        public virtual void AddSpell()
        {

        }
    }

}
