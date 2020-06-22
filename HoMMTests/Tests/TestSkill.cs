using HoMMProofOfConcept.Heroes;
using HoMMProofOfConcept.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HoMMTests.Tests
{
    public class TestSkill
    {
        [Theory]
        [InlineData(SkillName.Learning)]
        [InlineData(SkillName.Offense)]
        [InlineData(SkillName.Logistics)]
        public void TestSkillFacotry(SkillName s)
        {
           
            Skill expected = null;
            switch (s)
            {
                case SkillName.Learning:
                    expected = new Learning();
                    break;
                case SkillName.Logistics:
                    expected = new Logistics();
                    break;
                case SkillName.Offense:
                    expected = new Offense();
                    break;
            }
            Skill actual = SkillFactory.GetSkill(s);

            Assert.Equal(expected.Name, actual.Name);
        }

        [Fact]
        public void TestGetMultipleSkills()
        {
            SkillFactory sf = new SkillFactory();
            Skill[] expected = { new Offense(), new Learning(), new Logistics() };
            Skill[] actual = sf.GetMultipleSkills(3);

            Assert.NotEqual(expected.Length, actual.Length);
            //Assert.Equal(expected.Contains(new Offense(), actual.Contains(new Offense()));
        }
    }
}
