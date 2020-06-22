using HoMMProofOfConcept;
using HoMMProofOfConcept.Skills;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HoMMTests.Tests
{
    public class HeroTest
    {
        Hero h = new Hero(new Player("Phil"), "Maximus");

        [Fact]
        public void TestHasSkillFalse()
        {
            bool actual = h.HasSkill(HoMMProofOfConcept.Skills.SkillName.Learning);
            bool expected = false;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddSkill()
        {
            h.AddSkill(SkillName.Learning);
            bool actual = h.HasSkill(SkillName.Learning);
            bool expected = true;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetSkill()
        {
            //Added Skill should return 1
            h.AddSkill(SkillName.Learning);
            int actual = h.GetSkillLevel(SkillName.Learning);
            int expected = 1;
            Assert.Equal(expected, actual);

            //Unadded skill should get 0
            int actual2 = h.GetSkillLevel(SkillName.Logistics);
            int expected2 = 0;
            Assert.Equal(expected2, actual2);
        }

        [Theory]
        [InlineData(StatEnum.Attack)]
        [InlineData(StatEnum.Defense)]
        [InlineData(StatEnum.SpellPower)]
        [InlineData(StatEnum.Knowledge)]
        [InlineData(StatEnum.Speed)]
        [InlineData(StatEnum.Charisma)]
        public void TestIncreaseStat(StatEnum Name)
        {

            h.IncreaseStat(Name, 1);
            int actual = h.GetStat(Name);
            int expected;
            if(Name == StatEnum.Speed)
            {
                if(h.FavoredStat == Name)
                {
                    expected = 7;
                }
                else
                {
                    expected = 6;
                }
            }
            else if (h.FavoredStat == Name)
            {
                expected = 3;
            }
            else
            {
                expected = 2;
            }
            Assert.Equal(expected, actual);
        }
    }
}
